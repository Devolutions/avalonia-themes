[![image](https://github.com/user-attachments/assets/6a7bca22-bd0c-45cc-b847-8ea0b7776a6f)](https://devolutions.net/)

Custom Avalonia Themes developed by [Devolutions](https://devolutions.net/)

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build Status](https://github.com/Devolutions/avalonia-extensions/actions/workflows/build-package.yml/badge.svg?branch=master)](https://github.com/Devolutions/avalonia-extensions/actions/workflows/build-package.yml)
[![NuGet Version](https://img.shields.io/nuget/vpre/Devolutions.AvaloniaTheme.DevExpress)](https://www.nuget.org/packages/Devolutions.AvaloniaTheme.DevExpress)
![NuGet Downloads](https://img.shields.io/nuget/dt/Devolutions.AvaloniaTheme.DevExpress)

## DevExpress Theme [Work in Progress]

This theme is currently based
on [Avalonia.Themes.Fluent](https://github.com/AvaloniaUI/Avalonia/tree/759facea182b7771ce07baf173c52529f4871004/src/Avalonia.Themes.Fluent),
both as a fallback for any controls not covered yet and as starting point for our (somewhat simplified)
style definitions targeting DevExpress Winforms look.

While we are prioritizing controls
for [Devolutions Remote Desktop Manager](https://devolutions.net/remote-desktop-manager/), we welcome contributions from
the Avalonia community to add more DevExpress-style controls.

- [Installation](#installation)
- [Styled Controls](#styled-controls)
  - ✅ Available in the current build
    - [Button](#button)
    - [ButtonSpinner](#buttonspinner)
    - [CheckBox](#checkbox)
    - [ComboBox](#combobox)
      - [ComboBoxItem](#comboboxitem)
    - [DataGrid](#datagrid)
    - [NumericUpDown](#numericupdown)
      - [ButtonSpinner](#buttonspinner)
    - [ScrollViewer](#scrollviewer)
      - [ScrollBar](#scrollbar)
    - [TabControl](#tabcontrol)
      - [TabItem](#tabitem)
    - [TextBox](#textbox)
    - [TreeView](#treeview)
      - [TreeViewItem](#treeviewitem)
    - [Window](#window)
   - 🚧 In progress ...
    - small improvements & fixes, some code cleanup
    - ContextMenu
    - SplitButton
    - EditableComboBox [Custom control](https://github.com/Devolutions/avalonia-extensions/blob/master/src/Devolutions.AvaloniaControls/README.md)
  - 🔮 Next on the road map ...
    - DatePicker

## Installation

Install the Devolutions.AvaloniaTheme.DevExpress package
via [NuGet](https://www.nuget.org/packages/Devolutions.AvaloniaTheme.DevExpress):

``` bash
Install-Package Devolutions.AvaloniaTheme.DevExpress
```

or .NET

```bash
dotnet add package Devolutions.AvaloniaTheme.DevExpress
```

In your App.axaml, replace the existing theme (e.g. `<FluentTheme />` or `<SimpleTheme />`) with the DevExpress theme:

``` xaml
<Application ...>
  <Application.Styles>
     <StyleInclude Source="avares://Devolutions.AvaloniaTheme.DevExpress/DevExpressTheme.axaml" />
  </Application.Styles>
</Application>
```

## Styled Controls

|||
|-----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|
|||
|| <h3>AdornerLayer</h3> |
|||
|| <h3>AutoCompleteBox</h3> |
|||
|✅ | <h3>Button</h3> |
||  <img src="https://github.com/user-attachments/assets/58571893-927e-4e4a-92b3-7d0b7ced4f68" alt="Button demo" style="width: 182px; max-width: 100%;" /> |
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
|| <img src="https://github.com/user-attachments/assets/5faea9f6-3cf9-433f-86f5-fd8f75ad05f6" alt="CheckBox demo" style="width: 810px; max-width: 100%;" /> |
|✅ | <h3>ComboBox</h3> <h4>ComboBoxItem</h4> |
|| <img src="https://github.com/user-attachments/assets/f0e107c0-a4b2-4eec-bc0b-789e0f90cad6" alt="ComboBox demo" style="width: 232px; max-width: 100%;" /> |
|🚧 | <h3>ContextMenu</h3> |
|||
|✅ | <h3>DataGrid</h3> |
|| <img src="https://github.com/user-attachments/assets/409f433f-497b-4747-bf1f-ab81224463fb" alt="DataGrid demo" style="width: 834px; max-width: 100%;" /> <br /><img src="https://github.com/user-attachments/assets/07523a68-18cc-4ed3-9353-00f8ccacce7f" alt="Grouped DataGrid demo" style="width: 936px; max-width: 100%;" /> |
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
|| <h3>GridSplitter</h3> |
|||
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
|| <h3>Menu</h3> |
|||
|| <h3>MenuFlyoutPresenter</h3> |
|||
|| <h3>MenuItem</h3> |
|||
|| <h3>MenuScrollViewer</h3> |
|||
|| <h3>NotificationCard</h3> |
|||
|✅ | <h3>NumericUpDown</h3> <h4>ButtonSpinner</h4> |
|| <img src="https://github.com/user-attachments/assets/57f30484-dd75-452b-9d52-d6b2fce1a1ac" alt="NumericUpDown demo" style="width: 215px; max-width: 100%;" /> <br /><img src="https://github.com/user-attachments/assets/30666c61-2929-427b-9347-ae4e8e4fe2a6" alt="NumericUpDown demo (darkmode)" style="width: 225px; max-width: 100%;" /> |
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
|| <img src="https://github.com/user-attachments/assets/9a431dc0-dcd8-4abd-9a80-360578c2d9be" alt="ScrolBar demo" style="width: 288px; max-width: 100%;" /> <br /><img src="https://github.com/user-attachments/assets/145da20e-dc7e-414a-9831-1b1020d1d9f9" alt="ScrollViewer demo" style="width: 419px; max-width: 100%;" /> |
|| <h3>SelectableTextBlock</h3> |
|||
|| <h3>Separator</h3> |
|||
|| <h3>Slider</h3> |
|||
|| <h3>SplitButton</h3> |
|||
|| <h3>SplitView</h3> |
|||
|✅ | <h3>TabControl</h3> <h4>TabItem<h4> |
|| <img src="https://github.com/user-attachments/assets/21864dbb-1058-4656-99dd-c24fde76d4e4" alt="TabControl demo" style="width: 585px; max-width: 100%;" /> |
|| <h3>TabStrip</h3> |
|||
|| <h3>TabStripItem</h3> |
|||
|✅ | <h3>TextBox</h3> |
|| <img src="https://github.com/user-attachments/assets/9eab4003-be77-488e-9a58-f3ad38e3fe39"  alt="TextBox demo" style="width: 322px; max-width: 100%;" /> |
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
|| <h3>ToolTip</h3> |
|||
|| <h3>TransitioningContentControl</h3> |
|||
|✅ | <h3>TreeView</h3> <h4>TreeViewItem<h4> |
|| <img src="https://github.com/user-attachments/assets/068dbad3-5dd1-45a6-b7d0-80aa3fe70556" alt="TreeView demo" style="width: 368px; max-width: 100%;" /> |
|✅ | <h3>Window</h3> |
|| Controls inherit basic DevEx-specific Fore-/Background & Font styling (or EmbeddableControlRoot) |
|| <h3>WindowNotificationManager</h3> |
|||

