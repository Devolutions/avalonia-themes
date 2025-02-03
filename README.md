[![image](https://github.com/user-attachments/assets/6a7bca22-bd0c-45cc-b847-8ea0b7776a6f)](https://devolutions.net/)


# avalonia-themes
Custom Avalonia Themes developed by [Devolutions](https://devolutions.net/)

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build Status](https://github.com/Devolutions/avalonia-themes/actions/workflows/build-package.yml/badge.svg?branch=master)](https://github.com/Devolutions/avalonia-themes/actions/workflows/build-package.yml)
[![NuGet Version](https://img.shields.io/nuget/vpre/MacOS.Avalonia.Theme)](https://www.nuget.org/packages/MacOS.Avalonia.Theme)
![NuGet Downloads](https://img.shields.io/nuget/dt/MacOS.Avalonia.Theme)


## MacOS Theme [Work in Progress]
(Inspired by [@MikeCodesDotNET's earlier draft](https://github.com/AvaloniaUI/Avalonia/issues/14880#issuecomment-1985425341))

![image](https://github.com/user-attachments/assets/33d9a103-936f-4db3-b5cc-520a5ccdaf60)


This theme is currently based on [Avalonia.Themes.Fluent](https://github.com/AvaloniaUI/Avalonia/tree/759facea182b7771ce07baf173c52529f4871004/src/Avalonia.Themes.Fluent), 
both as a fallback for any controls not covered yet and as starting point for our (somewhat simplified) 
style definitions targeting AppKit macOS look.

While we are prioritizing controls for [Devolutions Remote Desktop Manager](https://devolutions.net/remote-desktop-manager/) initially,
the goal is to create a theme that helps all of the Avalonia community to bring a native look to their macOS apps. 

- [Installation](#installation)
- [Styled Controls](#styled-controls)
  - ✅ Available in the current build
    - [Button](#button)
    - [CheckBox](#checkbox)
    - [ComboBox](#combobox)
      - [ComboBoxItem](#comboboxitem)
    - [ContextMenu](#contextmenu)
    - [DataGrid](#datagrid)
    - [GridSplitter](#gridsplitter)
    - [Menu](#menu)
    - [MenuFlyoutPresenter](#menuflyoutpresenter)
    - [MenuItem](#menuitem)
    - [ScrollViewer](#scrollviewer)
      - [ScrollBar](#scrollbar)
    - [Separator](#separator) 
    - [TabControl](#tabcontrol)
      - [TabItem](#tabitem)
    - [TextBox](#textbox)
    - [TreeView](#treeview)
      - [TreeViewItem](#treeviewitem)
    - Very basic dark mode support
  - 🚧 In progress
    - Dark mode
    - Menu
    - ScrollBar
    - GridSplitter
  - 🔮 Next on the road map ...
    - ToolTip
    


## Installation
Install the MacOS.Avalonia.Theme package via [NuGet](https://www.nuget.org/packages/MacOS.Avalonia.Theme):
``` bash
Install-Package MacOS.Avalonia.Theme
```
or .NET
```bash
dotnet add package MacOS.Avalonia.Theme
```
In your App.axaml, replace the existing theme (e.g. `<FluentTheme />` or `<SimpleTheme />`) with the macOS theme:
``` xaml
<Application ...>
  <Application.Styles>
     <StyleInclude Source="avares://MacOS.Avalonia.Theme/MacOSTheme.axaml" />
  </Application.Styles>
</Application>
```

## Styled Controls

||                                                                                                   | Notes |
|-----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|-------|
||||
|| <h3>AdornerLayer</h3> ||
||||
|| <h3>AutoCompleteBox</h3> ||
||||
|✅ | <h3>Button</h3> ||
|| <img src="https://github.com/user-attachments/assets/49093553-a8b6-4cbe-b7a5-7c8f6a8ead3b" alt="Buttons demo" max-width="300"> ||
|| <h3>ButtonSpinner</h3> ||
||||
|| <h3>Calendar</h3> ||
||||
|| <h3>CalendarButton</h3> ||
||||
|| <h3>CalendarDatePicker</h3> ||
||||
|| <h3>CalendarDayButton</h3> ||
||||
|| <h3>CalendarItem</h3> ||
||||
|| <h3>CaptionButtons</h3> ||
||||
|| <h3>Carousel</h3> ||
||||
|✅ | <h3>CheckBox</h3> ||
|| <img src="https://github.com/user-attachments/assets/30182450-b339-49d4-9aab-96cef627d0ca" alt="CheckBox demo" max-width="723"> ||
|✅ | <h3>ComboBox</h3> ||
|| <img src="https://github.com/user-attachments/assets/7a8ed69e-1e1c-4218-9b97-591f5b7baaba" alt="ComboBox demo" max-width="461"> |  |
|| <h3>ComboBoxItem</h3> ||
||||
|✅ | <h3>ContextMenu</h3> ||
|| <img src="https://github.com/user-attachments/assets/72a2c409-da86-4ff9-8bac-2be7c0ef2b7d" alt="ComboBox demo" max-width="316"> ||
|✅ | <h3>DataGrid</h3> ||
|| <img src="https://github.com/user-attachments/assets/5acca5bd-1232-419e-bcae-828616d8004b" alt="DataGrid demo" max-width="552">   | The editable field still has an issue, forcing the row to be slightly higher than the others |
|| <h3>DataValidationErrors</h3> ||
||||
|| <h3>DatePicker</h3> ||
||||
|| <h3>DateTimePickerShared</h3> ||
||||
|| <h3>DropDownButton</h3> ||
||||
|| <h3>EmbeddableControlRoot</h3> ||
||||
|| <h3>Expander</h3> ||
||||
|| <h3>FluentControls</h3> ||
||||
|| <h3>FlyoutPresenter</h3> ||
||||
|✅ | <h3>GridSplitter</h3> ||
|| <img src="https://github.com/user-attachments/assets/df3b0ff0-9f71-4a06-b579-4411949bee1a" alt="GridSplitter" max-width="513"> ||
|| <h3>HeaderedContentControl</h3> ||
||||
|| <h3>HyperlinkButton</h3> ||
||||
|| <h3>ItemsControl</h3> ||
||||
|| <h3>Label</h3> ||
||||
|| <h3>ListBox</h3> ||
||||
|| <h3>ListBoxItem</h3> ||
||||
|| <h3>ManagedFileChooser</h3> ||
||||
|✅ | <h3>Menu</h3> ||
|| <img max-width="264" alt="Main menu" src="https://github.com/user-attachments/assets/d3b70c05-9bdc-4437-ba8f-9e098b7b7123" /><br /><img max-width="341" alt="Large toolbar" src="https://github.com/user-attachments/assets/791a9d1c-3272-4229-9db4-4bf20399a0d0" /><br /><img max-width="155" alt="Small toolbar" src="https://github.com/user-attachments/assets/2f433c00-7965-4ffa-a3c5-1fc5712b2f48" /><br /><img max-width="236" alt="Bottom toolbar" src="https://github.com/user-attachments/assets/bfc4a22a-6a12-4197-aef5-cc044ba3e7a4" /> | Use: <ul><li>`Classes="MacOS_Theme_MenuOpensAbove"` for bottom-placed menus</li><li>`Classes="MacOS_Theme_MenuLabelBelowIcon"` for toolbar-style menus</li><li>`Classes="MacOS_Theme_MenuItemIconOnly"` to hide labels completely</li></ul> |
|✅ | <h3>MenuFlyoutPresenter</h3> ||
|| <img src="https://github.com/user-attachments/assets/085eca28-d703-44e4-9392-35bb7b0ffc57" alt="MenuFlyout demo" max-width="586"><br /><img src="https://github.com/user-attachments/assets/fccf7dac-6b17-49ad-ad59-c7393f97532b" alt="MenuFlyout demo" max-width="586"> ||
|✅ | <h3>MenuItem</h3> ||
|| See [Menu](#menu), [MenuFlyoutPresenter](#menuflyoutpresenter), [ContextMenu](#contextmenu) ||
|| <h3>MenuScrollViewer</h3> ||
||||
|| <h3>NotificationCard</h3> ||
||||
|| <h3>NumericUpDown</h3> ||
||||
|| <h3>OverlayPopupHost</h3> ||
||||
|| <h3>PathIcon</h3> ||
||||
|| <h3>PopupRoot</h3> ||
||||
|| <h3>ProgressBar</h3> ||
||||
|| <h3>RadioButton</h3> ||
||||
|| <h3>RefreshContainer</h3> ||
||||
|| <h3>RefreshVisualizer</h3> ||
||||
|| <h3>RepeatButton</h3> ||
||||
|✅ | <h3>ScrollViewer</h3> <h3>ScrollBar</h3> ||
|| Default:<br /><img max-width="415" alt="ScrollViewer - default" src="https://github.com/user-attachments/assets/71bbd1ea-c2ec-44b6-a943-6f51dd0a3e65" /><br />`AllowAutoHide="False"`:<br /><img max-width="418" alt="ScrollViewer - AllowAutoHide false" src="https://github.com/user-attachments/assets/60116d7d-90a0-49b2-9736-f9d7715e89e8" /><br />`BorderThickness="0" Background="Transparent"`:<br /><img max-width="414" alt="ScrollViewer - transparent" src="https://github.com/user-attachments/assets/72736b28-7890-49e2-b566-5e31a0b6b994" /> ||
|| <h3>SelectableTextBlock</h3> ||
||||
|✅ | <h3>Separator</h3> ||
|| See [Menu](#menu), [MenuFlyoutPresenter](#menuflyoutpresenter), [ContextMenu](#contextmenu) ||
|| <h3>Slider</h3> ||
||||
|| <h3>SplitButton</h3> ||
||||
|| <h3>SplitView</h3> ||
||||
|✅ | <h3>TabControl</h3> <h4>TabItem<h4> ||
|| <img src="https://github.com/user-attachments/assets/4f88ce2c-59f9-4f85-b2db-a47fe0301472" alt="TabControl demo" max-width="515"> |Vertical tabs may still need some work|
|| <h3>TabStrip</h3> ||
||||
|| <h3>TabStripItem</h3> ||
||||
|✅ | <h3>TextBox</h3> ||
|| <img src="https://github.com/user-attachments/assets/47930d85-ec80-44b4-802d-6fe72d81bee4" alt="TextBox demo" max-width="332"> | There appears to be no easy way for styling the caret thickness and margin    |
|| <h3>TextSelectionHandle</h3> ||
||||
|| <h3>ThemeVariantScope</h3> ||
||||
|| <h3>TimePicker</h3> ||
||||
|| <h3>TitleBar</h3> ||
||||
|| <h3>ToggleButton</h3> ||
||||
|| <h3>ToggleSwitch</h3> ||
||||
|| <h3>ToolTip</h3> ||
||||
|| <h3>TransitioningContentControl</h3> ||
||||
|✅ | <h3>TreeView</h3> <h4>TreeViewItem<h4> ||
|| <img src="https://github.com/user-attachments/assets/0f1981ae-d001-49f9-8ee3-fda47ec2a461" alt="TabControl demo" max-width="515"> | Use `Classes="MacOS_Theme_AlternatingRowColor" to achieve striped background.  (Cannot currently be rendered with rounded corners & breaks when default TreeViewItem height is altered (see comment in ThemeResources.axaml))|
|| <h3>Window</h3> ||
||||
|| <h3>WindowNotificationManager</h3> ||
||||

