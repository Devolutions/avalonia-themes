namespace Devolutions.AvaloniaControls.Controls;

using System.Collections;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.VisualTree;

// ReSharper disable MemberHidesStaticFromOuterClass
public partial class EditableComboBox
{
    [TemplatePart("PART_TextBoxPresenter", typeof(ContentPresenter), IsRequired = true)]
    [TemplatePart("PART_Popup", typeof(Popup), IsRequired = true)]
    [TemplatePart("PART_InnerLeftContent", typeof(ItemsControl), IsRequired = true)]
    [TemplatePart("PART_InnerRightContent", typeof(ItemsControl), IsRequired = true)]
    [PseudoClasses(":dropdown-open-from-top", ":dropdown-overflow-left", ":dropdown-overflow-right", ":is-split-between-screens")]
    public sealed class InnerComboBox : ComboBox, INavigableContainer
    {
        public static readonly StyledProperty<Thickness> FocusedBorderThicknessProperty = AvaloniaProperty.Register<InnerComboBox, Thickness>(
            nameof(FocusedBorderThickness),
            Application.Current?.FindResource("TextControlBorderThemeThicknessFocused") as Thickness? ?? new Thickness(2));

        public static readonly DirectProperty<InnerComboBox, IEnumerable> InnerLeftContentProperty =
            AvaloniaProperty.RegisterDirect<InnerComboBox, IEnumerable>(
                nameof(InnerLeftContent),
                static o => o.InnerLeftContent,
                static (o, v) => o.InnerLeftContent = v);

        public static readonly DirectProperty<InnerComboBox, IEnumerable> InnerRightContentProperty =
            AvaloniaProperty.RegisterDirect<InnerComboBox, IEnumerable>(
                nameof(InnerRightContent),
                static o => o.InnerRightContent,
                static (o, v) => o.InnerRightContent = v);

        public static readonly StyledProperty<double> MaxDropDownWidthProperty =
            AvaloniaProperty.Register<InnerComboBox, double>(nameof(MaxDropDownWidth));

        public static readonly StyledProperty<Thickness> PopupBorderMaskMarginProperty =
            AvaloniaProperty.Register<InnerComboBox, Thickness>(nameof(PopupBorderMaskMargin));

        public static readonly StyledProperty<double> PopupBorderMaskWidthProperty =
            AvaloniaProperty.Register<InnerComboBox, double>(nameof(PopupBorderMaskWidth));

        public static readonly StyledProperty<bool> ValueFilterDropdownProperty =
            AvaloniaProperty.Register<InnerComboBox, bool>(nameof(ValueFilterDropdown));

        private readonly EditableComboBox parent;

        private ItemsControl? innerLeftContentControl;

        private ItemsControl? innerRightContentControl;

        private IDisposable? popupChildBoundSubscription;

        private IDisposable? popupChildSubscription;

        private ContentPresenter? textboxContentPresenter;

        public InnerComboBox(EditableComboBox parent, InnerTextBox innerTextBox)
        {
            this.parent = parent;
            this._innerTextBox = innerTextBox;

            this.GetObservable(FocusedBorderThicknessProperty).Subscribe(v => this.CalculatePopupBorderMask(v, null));
            this.GetObservable(BoundsProperty)
                .Subscribe(v =>
                {
                    this.CalculatePopupBorderMask(null, v);
                    this.UpdateDropdownOverflowPseudoClass(v, null);
                });
        }

        public InnerTextBox _innerTextBox { get; init; }

        public Popup? _popup { get; private set; }

        public Thickness FocusedBorderThickness
        {
            get => this.GetValue(FocusedBorderThicknessProperty);
            set => this.SetValue(FocusedBorderThicknessProperty, value);
        }

        public IEnumerable InnerLeftContent { get; set; } = new AvaloniaList<Control>();

        public IEnumerable InnerRightContent { get; set; } = new AvaloniaList<Control>();

        public double MaxDropDownWidth
        {
            get => this.GetValue(MaxDropDownWidthProperty);
            set => this.SetValue(MaxDropDownWidthProperty, value);
        }

        public Thickness PopupBorderMaskMargin
        {
            get => this.GetValue(PopupBorderMaskMarginProperty);
            private set => this.SetValue(PopupBorderMaskMarginProperty, value);
        }

        public double PopupBorderMaskWidth
        {
            get => this.GetValue(PopupBorderMaskWidthProperty);
            private set => this.SetValue(PopupBorderMaskWidthProperty, value);
        }

        public bool ValueFilterDropdown
        {
            get => this.GetValue(ValueFilterDropdownProperty);
            set => this.SetValue(ValueFilterDropdownProperty, value);
        }

        public IInputElement? GetControl(NavigationDirection direction, IInputElement? from, bool wrap)
        {
            return direction switch
            {
                NavigationDirection.Previous => this.GetPreviousControl(from),
                NavigationDirection.Next => this.GetNextControl(from),
                _ => null,
            };
        }

        protected override void ClearContainerForItemOverride(Control element)
        {
            base.ClearContainerForItemOverride(element);
            if (element is EditableComboBoxItem editableComboBoxItem) editableComboBoxItem.Value = string.Empty;
        }

        protected override void ContainerForItemPreparedOverride(Control container, object? item, int index)
        {
            base.ContainerForItemPreparedOverride(container, item, index);
            if (container is EditableComboBoxItem editableComboBoxItem)
            {
                if (this.ValueFilterDropdown)
                {
                    editableComboBoxItem.Bind(EditableComboBoxItem.FilterHighlightTextProperty,
                        AvaloniaObjectExtensions.GetObservable(this.parent, (AvaloniaProperty)ValueProperty).ToBinding());
                }
                else
                {
                    editableComboBoxItem.ClearValue(EditableComboBoxItem.FilterHighlightTextProperty);
                    editableComboBoxItem.FilterHighlightText = null;
                }
            }
        }

        protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey) =>
            new EditableComboBoxItem
            {
                Value = item?.ToString() ?? string.Empty,
            };

        protected override bool NeedsContainerOverride(object? item, int index, out object? recycleKey) =>
            this.NeedsContainer<EditableComboBoxItem>(item, out recycleKey);

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            this.innerLeftContentControl = e.NameScope.Get<ItemsControl>("PART_InnerLeftContent");
            this.innerRightContentControl = e.NameScope.Get<ItemsControl>("PART_InnerRightContent");

            this.textboxContentPresenter = e.NameScope.Get<ContentPresenter>("PART_TextBoxPresenter");
            this.textboxContentPresenter.Content = this._innerTextBox;

            if (this._popup != null)
            {
                this._popup.Opened -= this._popup_OnOpened;
                this._popup.Closed -= this._popup_OnClosed;

                if (this.popupChildBoundSubscription != null)
                {
                    this.popupChildBoundSubscription.Dispose();
                    this.popupChildBoundSubscription = null;
                }

                if (this.popupChildSubscription != null)
                {
                    this.popupChildSubscription.Dispose();
                    this.popupChildSubscription = null;
                }
            }

            this._popup = e.NameScope.Get<Popup>("PART_Popup");
            this._popup.Focusable = false;
            this._popup.IsTabStop = false;
            this._popup.PlacementTarget = this.parent;
            this._popup.Opened += this._popup_OnOpened;
            this._popup.Closed += this._popup_OnClosed;

            this.popupChildSubscription = this._popup.GetObservable(Popup.ChildProperty)
                .Subscribe(child =>
                {
                    if (this.popupChildBoundSubscription != null)
                    {
                        this.popupChildBoundSubscription.Dispose();
                        this.popupChildBoundSubscription = null;
                    }

                    this.popupChildBoundSubscription = child?.GetObservable(BoundsProperty).Subscribe(b =>
                    {
                        this.UpdateDropdownOverflowPseudoClass(null, b);
                    });
                });
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.CalculatePopupBorderMask(null, null);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.IsDropDownOpen) return;

            // TODO: Respect/implement all `KeyboardNavigation.TabNavigation` variants;
            //       for now, we only specifically handle `Continue`, otherwise we don't handle the event and bubble up.
            //       - sbergerondrouin 2025-05-21
            var direction = e.Key.ToNavigationDirection(e.KeyModifiers);
            if (direction is NavigationDirection dir && (dir == NavigationDirection.Previous || dir == NavigationDirection.Next))
            {
                var topLevel = TopLevel.GetTopLevel(this)!;
                var focus = topLevel.FocusManager;
                var focused = focus?.GetFocusedElement();

                var nextControl = GetNextControl(this, dir, focused, false);
                if (nextControl is not null)
                {
                    e.Handled = true;
                    nextControl.Focus(NavigationMethod.Tab, e.KeyModifiers);
                    return;
                }

                Visual? containerChild = this.parent;
                while (containerChild.FindAncestorOfType<INavigableContainer>() is { } container &&
                       (containerChild = container as Visual) != null)
                {
                    nextControl = GetNextControl(container, dir, this.parent, false);
                    if (nextControl is not null)
                    {
                        e.Handled = true;
                        nextControl.Focus(NavigationMethod.Tab, e.KeyModifiers);
                        return;
                    }
                }

                while (containerChild?.FindAncestorOfType<Grid>() is { } grid)
                {
                    var index = -1;
                    if (containerChild is Control control) index = grid.Children.IndexOf(control);

                    var increment = dir == NavigationDirection.Previous ? -1 : 1;
                    index += increment;
                    for (; 0 <= index && index < grid.Children.Count; index += increment)
                    {
                        nextControl = grid.Children[index];
                        if (nextControl is { Focusable: true, IsEffectivelyVisible: true, IsEffectivelyEnabled: true })
                        {
                            e.Handled = true;
                            nextControl.Focus(NavigationMethod.Tab, e.KeyModifiers);
                            return;
                        }
                    }

                    containerChild = grid;
                }
            }

            // Passthrough the rest instead of base, to handle on EditableComboBox instead
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            // Pointer interactions handled by EditableComboBox
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            // Pointer interactions handled by EditableComboBox
        }

        protected override void PrepareContainerForItemOverride(Control container, object? item, int index)
        {
            base.PrepareContainerForItemOverride(container, item, index);
            if (container != item)
                if (container is EditableComboBoxItem editableComboBoxItem)
                    // FIXME: Verify if we shouldn't maybe bind instead ?
                    editableComboBoxItem.Value = (item as EditableComboBoxItem)?.Value ?? item?.ToString() ?? string.Empty;
        }

        private static bool IsSplitBetweenScreen(Visual visual)
        {
            if (TopLevel.GetTopLevel(visual) is not { } topLevel) return false;

            var topLeftPoint = visual.PointToScreen(new Point(0, 0));
            var bottomRightPoint = visual.PointToScreen(new Point(visual.Bounds.Width, visual.Bounds.Height));
            var screen1 = topLevel.Screens?.ScreenFromPoint(topLeftPoint);
            var screen2 = topLevel.Screens?.ScreenFromPoint(bottomRightPoint);
            return screen1 is not null && screen2 is not null && screen1 != screen2;
        }

        private void _popup_OnClosed(object? sender, EventArgs e)
        {
            this.PseudoClasses.Remove(":dropdown-open-from-top");
            this.PseudoClasses.Remove(":dropdown-overflow");

            if (this._popup?.Child?.GetVisualRoot() is PopupRoot popupRoot) popupRoot.PositionChanged -= this.PopupRoot_OnPositionChanged;
        }

        private void _popup_OnOpened(object? sender, EventArgs e)
        {
            if (this._popup?.Child == null) return;

            this.UpdatePseudoClasses();

            if (this._popup.Child?.GetVisualRoot() is PopupRoot popupRoot) popupRoot.PositionChanged += this.PopupRoot_OnPositionChanged;
        }

        private int? CalculateOffsetLeft()
        {
            if (this._popup?.Child == null) return null;

            return this.PointToScreen(new Point(0, 0)).X - this._popup.Child.PointToScreen(new Point(0, 0)).X;
        }

        private void CalculatePopupBorderMask(Thickness? newFocusBorderThickness, Rect? newBounds, int? offsetLeft = null)
        {
            var focusBorderThickness = newFocusBorderThickness ?? this.FocusedBorderThickness;
            var bounds = newBounds ?? this.Bounds;

            this.PopupBorderMaskMargin = new Thickness(focusBorderThickness.Left, 0, 0, 0);
            this.PopupBorderMaskWidth = bounds.Width - focusBorderThickness.Left - focusBorderThickness.Right;

            if (this._popup?.Child?.IsAttachedToVisualTree() != true) return;

            var isSplitBetweenScreens = IsSplitBetweenScreen(this);
            this.PseudoClasses.Set(":is-split-between-screens", isSplitBetweenScreens);

            if (isSplitBetweenScreens)
            {
                this.PopupBorderMaskWidth = 0;
            }
            else
            {
                offsetLeft ??= this.CalculateOffsetLeft();
                this.PopupBorderMaskMargin = new Thickness(
                    this.PopupBorderMaskMargin.Left + (int)offsetLeft!,
                    this.PopupBorderMaskMargin.Top,
                    this.PopupBorderMaskMargin.Right,
                    this.PopupBorderMaskMargin.Bottom);
            }
        }

        private IInputElement? GetNextControl(IInputElement? from)
        {
            var foundCurrent = Equals(from, this._innerTextBox);

            if (this.innerLeftContentControl != null)
                foreach (var item in this.innerLeftContentControl.Items)
                {
                    if (!foundCurrent)
                    {
                        foundCurrent = Equals(from, item);
                        continue;
                    }

                    var itemControl = item != null ? this.innerLeftContentControl.ContainerFromItem(item) : null;
                    if (itemControl?.Focusable == true && itemControl.IsEnabled) return itemControl;
                }

            if (this.innerRightContentControl != null)
                foreach (var item in this.innerRightContentControl.Items)
                {
                    if (!foundCurrent)
                    {
                        foundCurrent = Equals(from, item);
                        continue;
                    }

                    var itemControl = item != null ? this.innerRightContentControl.ContainerFromItem(item) : null;
                    if (itemControl?.Focusable == true && itemControl.IsEnabled) return itemControl;
                }

            return null;
        }

        private IInputElement? GetPreviousControl(IInputElement? from)
        {
            if (Equals(from, this._innerTextBox) || Equals(from, this) || Equals(from, this.parent)) return null;

            var foundCurrent = false;

            if (this.innerRightContentControl != null)
                foreach (var item in this.innerRightContentControl.Items.Reverse())
                {
                    if (!foundCurrent)
                    {
                        foundCurrent = Equals(from, item);
                        continue;
                    }

                    var itemControl = item != null ? this.innerRightContentControl.ContainerFromItem(item) : null;
                    if (itemControl?.Focusable == true && itemControl.IsEnabled) return itemControl;
                }

            if (this.innerLeftContentControl != null)
                foreach (var item in this.innerLeftContentControl.Items.Reverse())
                {
                    if (!foundCurrent)
                    {
                        foundCurrent = Equals(from, item);
                        continue;
                    }

                    var itemControl = item != null ? this.innerLeftContentControl.ContainerFromItem(item) : null;
                    if (itemControl?.Focusable == true && itemControl.IsEnabled) return itemControl;
                }

            if (foundCurrent) return this._innerTextBox;

            return null;
        }

        private void PopupRoot_OnPositionChanged(object? sender, PixelPointEventArgs e)
        {
            this.UpdatePseudoClasses();
        }

        private void UpdateDropdownOpenFromTop()
        {
            if (Design.IsDesignMode || this._popup?.Child == null) return;

            this.PseudoClasses.Set(":dropdown-open-from-top",
                this.PointToScreen(new Point(0, 0)).Y > this._popup.Child.PointToScreen(new Point(0, 0)).Y);
        }

        private void UpdateDropdownOverflowPseudoClass(Rect? newDropdownBounds, Rect? newPopupBounds, int? offsetLeft = null)
        {
            if (this._popup?.Child?.IsAttachedToVisualTree() != true) return;

            offsetLeft ??= this.CalculateOffsetLeft();

            var dropdownWidth = (newDropdownBounds ?? this.Bounds).Width;
            var popupWidth = (newPopupBounds ?? this._popup.Child.Bounds).Width;

            this.PseudoClasses.Set(":dropdown-overflow-right", popupWidth - offsetLeft > dropdownWidth);
            this.PseudoClasses.Set(":dropdown-overflow-left", offsetLeft > 0);
        }

        private void UpdatePseudoClasses()
        {
            if (this._popup?.Child?.IsAttachedToVisualTree() != true) return;

            var offsetLeft = (int)this.CalculateOffsetLeft()!;
            this.UpdateDropdownOpenFromTop();
            this.CalculatePopupBorderMask(null, null, offsetLeft);
            this.UpdateDropdownOverflowPseudoClass(null, null, offsetLeft);
        }
    }
}

// ReSharper enable MemberHidesStaticFromOuterClass