[![image](https://github.com/user-attachments/assets/6a7bca22-bd0c-45cc-b847-8ea0b7776a6f)](https://devolutions.net/)

Custom Avalonia Themes developed by [Devolutions](https://devolutions.net/)

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build Status](https://github.com/Devolutions/avalonia-extensions/actions/workflows/build-package.yml/badge.svg?branch=master)](https://github.com/Devolutions/avalonia-extensions/actions/workflows/build-package.yml)
[![NuGet Version](https://img.shields.io/nuget/vpre/Devolutions.AvaloniaTheme.MacOS)](https://www.nuget.org/packages/Devolutions.AvaloniaTheme.MacOS)
![NuGet Downloads](https://img.shields.io/nuget/dt/Devolutions.AvaloniaTheme.MacOS)

## MacOS Theme [Work in Progress]

(Inspired
by [@MikeCodesDotNET's earlier draft](https://github.com/AvaloniaUI/Avalonia/issues/14880#issuecomment-1985425341))

![image](https://github.com/user-attachments/assets/33d9a103-936f-4db3-b5cc-520a5ccdaf60)

This theme is currently based
on [Avalonia.Themes.Fluent](https://github.com/AvaloniaUI/Avalonia/tree/759facea182b7771ce07baf173c52529f4871004/src/Avalonia.Themes.Fluent),
both as a fallback for any controls not covered yet and as starting point for our (somewhat simplified)
style definitions targeting AppKit macOS look.

While we are prioritizing controls
for [Devolutions Remote Desktop Manager](https://devolutions.net/remote-desktop-manager/) initially,
the goal is to create a theme that helps all of the Avalonia community to bring a native look to their macOS apps.

- [Installation](#installation)
- [Styled Controls](#styled-controls)
  - ✅ Available in the current build
    - [Button](#button)
    - [ButtonSpinner](#buttonspinner)
    - [CheckBox](#checkbox)
    - [ComboBox](#combobox)
      - [ComboBoxItem](#comboboxitem)
    - [ContextMenu](#contextmenu)
    - [DataGrid](#datagrid)
    - [GridSplitter](#gridsplitter)
    - [Menu](#menu)
    - [MenuFlyoutPresenter](#menuflyoutpresenter)
    - [MenuItem](#menuitem)
    - [NumericUpDown](#numericupdown)
      - [ButtonSpinner](#buttonspinner)
    - [ScrollViewer](#scrollviewer)
      - [ScrollBar](#scrollbar)
    - [Separator](#separator)
    - [TabControl](#tabcontrol)
      - [TabItem](#tabitem)
    - [TextBox](#textbox)
    - [ToolTip](#tooltip)
    - [TreeView](#treeview)
      - [TreeViewItem](#treeviewitem)
    - [Window](#window)
    - Dark mode support
    - Limited inactive window behaviour (Accent colours switch to subdued look)
  - 🚧 In progress ...
    - small improvements & fixes, some code cleanup
    - SplitButton
    - EditableComboBox [Custom control](https://github.com/Devolutions/avalonia-extensions/blob/master/src/Devolutions.AvaloniaControls/README.md)
  - 🔮 Next on the road map ...
    - DatePicker

## Installation

Install the Devolutions.AvaloniaTheme.MacOS package
via [NuGet](https://www.nuget.org/packages/Devolutions.AvaloniaTheme.MacOS):

``` bash
Install-Package Devolutions.AvaloniaTheme.MacOS
```

or .NET

```bash
dotnet add package Devolutions.AvaloniaTheme.MacOS
```

In your App.axaml, replace the existing theme (e.g. `<FluentTheme />` or `<SimpleTheme />`) with the macOS theme:

``` xaml
<Application ...>
  <Application.Styles>
     <DevolutionsMacOsTheme />
  </Application.Styles>
</Application>
```

## Styled Controls

||| 
|-----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|
|||
|| <h3>AdornerLayer</h3> |
|||
|➡️ | <h3>AutoCompleteBox</h3> |
|| See [EditableComboBox](#editablecombobox) in our [custom controls](https://github.com/Devolutionsavalonia-extensions/blob/master/src/Devolutions.AvaloniaControls/README.md)|
|✅ | <h3>Button</h3> |
|| <img src="https://github.com/user-attachments/assets/49093553-a8b6-4cbe-b7a5-7c8f6a8ead3b" alt="Buttonsdemo" style="width: 300px; max-width: 100%;"> |
|| <h3>Calendar</h3> |
|||
|| <h3>CalendarButton</h3> |
|||
|| <h3>CalendarDatePicker</h3> |
|||
|| <h3>CalendarDayButton</h3> |
|||
|| <h3>CalendarItem</h3> |
|||
|| <h3>CaptionButtons</h3> |
|||
|| <h3>Carousel</h3> |
|||
|✅ | <h3>CheckBox</h3> |
|| <img src="https://github.com/user-attachments/assets/30182450-b339-49d4-9aab-96cef627d0ca" alt="CheckBox demo" style="width: 723px; max-width: 100%;" /> |
|✅ | <h3>ComboBox</h3> <h4>ComboBoxItem</h4> |
|| <img src="https://github.com/user-attachments/assets/7a8ed69e-1e1c-4218-9b97-591f5b7baaba" alt="ComboBox demo" style="width: 461px; max-width: 100%;" /> |
|✅ | <h3>ContextMenu</h3> |
|| <img src="https://github.com/user-attachments/assets/72a2c409-da86-4ff9-8bac-2be7c0ef2b7d" alt="ContextMenu demo" style="width: 316px; max-width: 100%;" /> |
|✅ | <h3>DataGrid</h3> |
|| <img src="https://github.com/user-attachments/assets/2810997d-3bfb-4ba0-9d7e-19f483733fd4" alt="DataGrid demo" style="width: 955px; max-width: 100%;" /> <br />The editable field still has an issue, forcing the row to be slightly higher than the others <br /><br /><strong>Grouped Data</strong><br /><img src="https://github.com/user-attachments/assets/0b1f3dfc-79bc-477a-8418-fda1258c2d1d" alt="Grouped DataGrid demo" style="width: 1047px; max-width: 100%;" />   |
|| <h3>DataValidationErrors</h3> |
|||
|| <h3>DatePicker</h3> |
|||
|| <h3>DateTimePickerShared</h3> |
|||
|| <h3>DropDownButton</h3> |
|||
|🚧 | <h3>EditableComboBox</h3> |
|| [Custom control](https://github.com/Devolutions/avalonia-extensions/blobmaster/src/Devolutions.AvaloniaControls/README.md) |
|| <h3>EmbeddableControlRoot</h3> |
|||
|| <h3>Expander</h3> |
|||
|| <h3>FluentControls</h3> |
|||
|| <h3>FlyoutPresenter</h3> |
|||
|✅ | <h3>GridSplitter</h3> |
|| <img src="https://github.com/user-attachments/assets/df3b0ff0-9f71-4a06-b579-4411949bee1a" alt="GridSplitter" style="width: 513px; max-width: 100%;" /> |
|| <h3>HeaderedContentControl</h3> |
|||
|| <h3>HyperlinkButton</h3> |
|||
|| <h3>ItemsControl</h3> |
|||
|| <h3>Label</h3> |
|||
|| <h3>ListBox</h3> |
|||
|| <h3>ListBoxItem</h3> |
|||
|| <h3>ManagedFileChooser</h3> |
|||
|✅ | <h3>Menu</h3> |
|| <img alt="Main menu" src="https://github.com/user-attachments/assets/d3b70c05-9bdc-4437-ba8f-9e098b7b7123" style="width: 266px; max-width: 100%;" /><br /><br />`Classes="MacOS_Theme_MenuLabelBelowIcon"` for toolbar-style menus<br /><img alt="Large toolbar" src="https://github.com/user-attachments/assets/791a9d1c-3272-4229-9db4-4bf20399a0d0" style="width: 341px; max-width: 100%;" /><br /><img alt="Small toolbar" src="https://github.com/user-attachments/assets/2f433c00-7965-4ffa-a3c5-1fc5712b2f48" style="width: 155px; max-width: 100%;" /><br /><br />`Classes="MacOS_Theme_MenuItemIconOnly"` to hide labels completely<br />`Classes="MacOS_Theme_MenuOpensAbove"` for bottom-placed menus<br /><img alt="Bottom toolbar" src="https://github.com/user-attachments/assets/bfc4a22a-6a12-4197-aef5-cc044ba3e7a4" style="width: 236px; max-width: 100%;" /> |
|✅ | <h3>MenuFlyoutPresenter</h3> |
|| <img src="https://github.com/user-attachments/assets/085eca28-d703-44e4-9392-35bb7b0ffc57" alt="MenuFlyout demo" style="width: 629px; max-width: 100%;" /><br /><img src="https://github.com/user-attachments/assets/fccf7dac-6b17-49ad-ad59-c7393f97532b" alt="MenuFlyout demo" style="width: 629px; max-width: 100%;" /> |
|✅ | <h3>MenuItem</h3> |
|| See [Menu](#menu), [MenuFlyoutPresenter](#menuflyoutpresenter), [ContextMenu](#contextmenu) |
|| <h3>MenuScrollViewer</h3> |
|||
|| <h3>NotificationCard</h3> |
|||
|✅ | <h3>NumericUpDown</h3> <h4>ButtonSpinner</h4> |
|| <img src="https://github.com/user-attachments/assets/a58375d7-1987-4182-b7f2-03f2bf499193" alt="NumericUpDown demo" style="width: 172px; max-width: 100%;" /> |
|| <h3>OverlayPopupHost</h3> |
|||
|| <h3>PathIcon</h3> |
|||
|| <h3>PopupRoot</h3> |
|||
|| <h3>ProgressBar</h3> |
|||
|| <h3>RadioButton</h3> |
|||
|| <h3>RefreshContainer</h3> |
|||
|| <h3>RefreshVisualizer</h3> |
|||
|| <h3>RepeatButton</h3> |
|||
|✅ | <h3>ScrollViewer</h3> <h4>ScrollBar</h4> |
|| Default:<br /><img alt="ScrollViewer - default" src="https://github.com/user-attachments/assets/71bbd1ea-c2ec-44b6-a943-6f51dd0a3e65" style="width: 415px; max-width: 100%;" /><br />`AllowAutoHide="False"`:<br /><img alt="ScrollViewer - AllowAutoHide false" src="https://github.com/user-attachments/assets/60116d7d-90a0-49b2-9736-f9d7715e89e8" style="width: 418px; max-width: 100%;" /> <br /><br />Note that even with `AllowAutoHide="True"` the scrollbars won't completely hide. This is intentional, since scrolling events will not trigger a 'show' (only moving the pointer directly over the track area will) - so completely hiding would be confusing. <br /><br />Mousing over one of the track areas will make the thumb bar grow wider and darker and the track appears. To suppress this behaviour (e.g. on images) use `Classes="MacOS_TransparentTrack"` |
|| <h3>SelectableTextBlock</h3> |
|||
|✅ | <h3>Separator</h3> |
|| See [Menu](#menu), [MenuFlyoutPresenter](#menuflyoutpresenter), [ContextMenu](#contextmenu) |
|| <h3>Slider</h3> |
|||
|| <h3>SplitButton</h3> |
|||
|| <h3>SplitView</h3> |
|||
|✅ | <h3>TabControl</h3> <h4>TabItem<h4> |
|| <img src="https://github.com/user-attachments/assets/4f88ce2c-59f9-4f85-b2db-a47fe0301472" alt="TabControl demo" style="width: 515px; max-width: 100%;" /> <br />Vertical tabs may still need some work |
|| <h3>TabStrip</h3> |
|||
|| <h3>TabStripItem</h3> |
|||
|✅ | <h3>TextBox</h3> |
|| <img src="https://github.com/user-attachments/assets/47930d85-ec80-44b4-802d-6fe72d81bee4" alt="TextBoxdemo" style="width: 343px; max-width: 100%;" /> <br />There appears to be no easy way for styling the caret thickness and margin |
|| <h3>TextSelectionHandle</h3> |
|||
|| <h3>ThemeVariantScope</h3> |
|||
|| <h3>TimePicker</h3> |
|||
|| <h3>TitleBar</h3> |
|||
|| <h3>ToggleButton</h3> |
|||
|| <h3>ToggleSwitch</h3> |
|||
|✅ | <h3>ToolTip</h3> |
|| <img src="https://github.com/user-attachments/assets/92d9e28e-c955-4643-9d50-ee785f19bbb9" alt="ToolTipdemo - light" style="width: 300px; max-width: 100%;" /><br /><img src="https://github.com/user-attachments/assets/1de29b7a-25e8-4f41-985d-fb2e4f687c1b" alt="ToolTip demo - dark" style="width: 300px; max-width: 100%;" /> |
|| <h3>TransitioningContentControl</h3> |
|||
|✅ | <h3>TreeView</h3> <h4>TreeViewItem<h4> |
|| <img src="https://github.com/user-attachments/assets/0f1981ae-d001-49f9-8ee3-fda47ec2a461" alt="TabControl demo" style="width: 608px; max-width: 100%;" /> <br />Use `Classes="MacOS_Theme_AlternatingRowColor"` to achieve striped background.  (Cannot currently be rendered with rounded corners & breaks when default TreeViewItem height is altered (see comment in ThemeResources.axaml))|
|✅ | <h3>Window</h3> |
|| Controls inherit basic MacOS-specific Fore-/Background & Font styling from Window (or EmbeddableControlRoot)|
|| <h3>WindowNotificationManager</h3> |
|||

