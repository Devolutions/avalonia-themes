using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace SampleApp.DemoPages;

public partial class MenuFlyoutDemo : UserControl
{
  public MenuFlyoutDemo()
  {
    InitializeComponent();
    AttachRightClickHandler();

    void AttachRightClickHandler()
    {
      var targetItem = this.FindControl<TextBlock>("MenuTrigger");
      if (targetItem != null) targetItem.PointerPressed += TextBlock_PointerPressed;
    }

    void TextBlock_PointerPressed(object sender, PointerPressedEventArgs e)
    {
      var ctl = sender as Control;
      if (ctl != null) FlyoutBase.ShowAttachedFlyout(ctl);
      // if (e.GetCurrentPoint(null).Properties.IsRightButtonPressed)
      // {
      //   Console.WriteLine("Right-clicked on Level 3.2");
      //   e.Handled = true;
      // }
    }
  }
}