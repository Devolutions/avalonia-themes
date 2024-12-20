# avalonia-themes
Custom Avalonia Themes developed by Devolutions

## MacOS Theme [Work in Progress]
(Inspired by [@MikeCodesDotNET's earlier draft](https://github.com/AvaloniaUI/Avalonia/issues/14880#issuecomment-1985425341))

This theme is currently based on [Avalonia.Themes.Fluent](https://github.com/AvaloniaUI/Avalonia/tree/759facea182b7771ce07baf173c52529f4871004/src/Avalonia.Themes.Fluent), 
both as a fallback for any controls not covered yet and as starting point for our (somewhat simplified) 
style definitions targeting AppKit macOS look.

While we are currently prioritizing controls for [Devolutions Remote Desktop Manager](https://devolutions.net/remote-desktop-manager/),
the goal is to create a theme that helps all of the Avalonia community to bring a native look to their macOS apps. 

- [Installation](#installation)
- [Styled Controls](#styled-controls)
  - ✅ Available in the current build
    - [Button](#button)
    - [CheckBox](#checkbox)
    - [ComboBox](#combobox)
      - [ComboBoxItem](#comboboxitem)
    - [TabControl](#tabcontrol)
      - [TabItem](#tabitem)
    - [TextBox](#textbox) 
  - 🚧 In progress
    - TreeView
    - TreeViewItem
  - 🔮 Next on the road map ...
    - DataGrid
    - Menu
    - Dark mode


## Installation
Install the Devolutions.MacOS.Avalonia.Theme package via [NuGet](https://www.nuget.org/packages/Devolutions.MacOS.Avalonia.Theme):
``` bash
Install-Package Devolutions.MacOS.Avalonia.Theme
```
In your App.axaml, replace the existing theme (e.g., <FluentTheme /> or <SimpleTheme />) with the macOS theme:
``` xaml
<Application ...>
  <Application.Styles>
     <StyleInclude Source="avares://Devolutions.MacOS.Avalonia.Theme/MacOSTheme.axaml" />
  </Application.Styles>
</Application>
```

## Styled Controls

| |                                                                                                   |       |
|-----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|-------|
||||
| <a name="#adornerlayer"></a>            | <h3>AdornerLayer</h3>                                                                                                         |       |
||||
| <a name="#autocompletebox"></a>         | <h3>AutoCompleteBox</h3>                                                                                                      |       |
||||
|✅ <a name="#button"></a>                 | <h3>Button</h3>                                                                                                               |       |
|                                         | <img src="https://github.com/user-attachments/assets/49093553-a8b6-4cbe-b7a5-7c8f6a8ead3b" alt="Buttons demo" width="300">    |       |
| <a name="#buttonspinner"></a>           | <h3>ButtonSpinner</h3>                                                                                                        |       |
||||
| <a name="#calendar"></a>                | <h3>Calendar</h3>                                                                                                             |       |
||||
| <a name="#calendarbutton"></a>          | <h3>CalendarButton</h3>                                                                                                       |       |
||||
| <a name="#calendardatepicker"></a>      | <h3>CalendarDatePicker</h3>                                                                                                   |       |
||||
| <a name="#calendardaybutton"></a>       | <h3>CalendarDayButton</h3>                                                                                                    |       |
||||
| <a name="#calendaritem"></a>            | <h3>CalendarItem</h3>                                                                                                         |       |
||||
| <a name="#captionbuttons"></a>          | <h3>CaptionButtons</h3>                                                                                                       |       |
||||
| <a name="#carousel"></a>                | <h3>Carousel</h3>                                                                                                             |       |
||||
|✅ <a name="#checkbox"></a>               | <h3>CheckBox</h3>                                                                                                             |       |
|                                         | <img src="https://github.com/user-attachments/assets/30182450-b339-49d4-9aab-96cef627d0ca" alt="CheckBox demo" width="723">   |       |
|✅ <a name="#combobox"></a> | <h3>ComboBox</h3>                                                                                                             |       |
| | <img src="https://github.com/user-attachments/assets/7a8ed69e-1e1c-4218-9b97-591f5b7baaba" alt="ComboBox demo" width="461">   |       |
| <a name="#comboboxitem"></a>            | <h3>ComboBoxItem</h3>                                                                                                         |       |
||||
| <a name="#contextmenu"></a>             | <h3>ContextMenu</h3>                                                                                                          |       |
||||
| <a name="#datavalidationerrors"></a>    | <h3>DataValidationErrors</h3>                                                                                                 |       |
||||
| <a name="#datepicker"></a>              | <h3>DatePicker</h3>                                                                                                           |       |
||||
| <a name="#datetimepickershared"></a>    | <h3>DateTimePickerShared</h3>                                                                                                 |       |
||||
| <a name="#dropdownbutton"></a>          | <h3>DropDownButton</h3>                                                                                                       |       |
||||
| <a name="#embeddablecontrolroot"></a>   | <h3>EmbeddableControlRoot</h3>                                                                                                |       |
||||
| <a name="#expander"></a>                | <h3>Expander</h3>                                                                                                             |       |
||||
| <a name="#fluentcontrols"></a>          | <h3>FluentControls</h3>                                                                                                       |       |
||||
| <a name="#flyoutpresenter"></a>         | <h3>FlyoutPresenter</h3>                                                                                                      |       |
||||
| <a name="#gridsplitter"></a>            | <h3>GridSplitter</h3>                                                                                                         |       |
||||
| <a name="#headeredcontentcontrol"></a>  | <h3>HeaderedContentControl</h3>                                                                                               |       |
||||
| <a name="#hyperlinkbutton"></a>         | <h3>HyperlinkButton</h3>                                                                                                      |       |
||||
| <a name="#itemscontrol"></a>            | <h3>ItemsControl</h3>                                                                                                         |       |
||||
| <a name="#label"></a>                   | <h3>Label</h3>                                                                                                                |       |
||||
| <a name="#listbox"></a>                 | <h3>ListBox</h3>                                                                                                              |       |
||||
| <a name="#listboxitem"></a>             | <h3>ListBoxItem</h3>                                                                                                          |       |
||||
| <a name="#managedfilechooser"></a>      | <h3>ManagedFileChooser</h3>                                                                                                   |       |
||||
| <a name="#menu"></a>                    | <h3>Menu</h3>                                                                                                                 |       |
||||
| <a name="#menuflyoutpresenter"></a>     | <h3>MenuFlyoutPresenter</h3>                                                                                                  |       |
||||
| <a name="#menuitem"></a>                | <h3>MenuItem</h3>                                                                                                             |       |
||||
| <a name="#menuscrollviewer"></a>        | <h3>MenuScrollViewer</h3>                                                                                                     |       |
||||
| <a name="#notificationcard"></a>        | <h3>NotificationCard</h3>                                                                                                     |       |
||||
| <a name="#numericupdown"></a>           | <h3>NumericUpDown</h3>                                                                                                        |       |
||||
| <a name="#overlaypopuphost"></a>        | <h3>OverlayPopupHost</h3>                                                                                                     |       |
||||
| <a name="#pathicon"></a>                | <h3>PathIcon</h3>                                                                                                             |       |
||||
| <a name="#popuproot"></a>               | <h3>PopupRoot</h3>                                                                                                            |       |
||||
| <a name="#progressbar"></a>             | <h3>ProgressBar</h3>                                                                                                          |       |
||||
| <a name="#radiobutton"></a>             | <h3>RadioButton</h3>                                                                                                          |       |
||||
| <a name="#refreshcontainer"></a>        | <h3>RefreshContainer</h3>                                                                                                     |       |
||||
| <a name="#refreshvisualizer"></a>       | <h3>RefreshVisualizer</h3>                                                                                                    |       |
||||
| <a name="#repeatbutton"></a>            | <h3>RepeatButton</h3>                                                                                                         |       |
||||
| <a name="#scrollbar"></a>               | <h3>ScrollBar</h3>                                                                                                            |       |
||||
| <a name="#scrollviewer"></a>            | <h3>ScrollViewer</h3>                                                                                                         |       |
||||
| <a name="#selectabletextblock"></a>     | <h3>SelectableTextBlock</h3>                                                                                                  |       |
||||
| <a name="#separator"></a>               | <h3>Separator</h3>                                                                                                            |       |
||||
| <a name="#slider"></a>                  | <h3>Slider</h3>                                                                                                               |       |
||||
| <a name="#splitbutton"></a>             | <h3>SplitButton</h3>                                                                                                          |       |
||||
| <a name="#splitview"></a>               | <h3>SplitView</h3>                                                                                                            |       |
||||
|✅ <a name="#tabcontrol"></a>             | <h3>TabControl</h3> <h4>TabItem<h4>                                                                                                 |       |
|                                 <a name="#tabitem"></a>        | <img src="https://github.com/user-attachments/assets/4f88ce2c-59f9-4f85-b2db-a47fe0301472" alt="TabControl demo" width="515"> |       |
| <a name="#tabstrip"></a>                | <h3>TabStrip</h3>                                                                                                             |       |
||||
| <a name="#tabstripitem"></a>            | <h3>TabStripItem</h3>                                                                                                         |       |
||||
|✅ <a name="#textbox"></a>                 | <h3>TextBox</h3>                                                                                                              |       |
|                    | <img src="https://github.com/user-attachments/assets/4c14fdcd-f41d-41f0-aa39-1b37d7f5ab26" alt="TextBox demo" width="332">    |       |
| <a name="#textselectionhandle"></a>     | <h3>TextSelectionHandle</h3>                                                                                                  |       |
||||
| <a name="#themevariantscope"></a>       | <h3>ThemeVariantScope</h3>                                                                                                    |       |
||||
| <a name="#timepicker"></a>              | <h3>TimePicker</h3>                                                                                                           |       |
||||
| <a name="#titlebar"></a>                | <h3>TitleBar</h3>                                                                                                             |       |
||||
| <a name="#togglebutton"></a>            | <h3>ToggleButton</h3>                                                                                                         |       |
||||
| <a name="#toggleswitch"></a>            | <h3>ToggleSwitch</h3>                                                                                                         |       |
||||
| <a name="#tooltip"></a>                 | <h3>ToolTip</h3>                                                                                                              |       |
||||
| <a name="#transitioningcontentcontrol"></a> | <h3>TransitioningContentControl</h3>                                                                                          |       |
||||
| <a name="#treeview"></a>                | <h3>TreeView</h3>                                                                                                             |       |
||||
| <a name="#treeviewitem"></a>            | <h3>TreeViewItem</h3>                                                                                                         |       |
||||
| <a name="#window"></a>                  | <h3>Window</h3>                                                                                                               |       |
||||
| <a name="#windownotificationmanager"></a> | <h3>WindowNotificationManager</h3>                                                                                            |       |
||||


### TreeView
Coming soon ...

### DataGrid
