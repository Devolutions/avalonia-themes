# avalonia-themes
Custom Avalonia Themes developed by Devolutions

## MacOS Theme [Work in Progress]
(Inspired by [@MikeCodesDotNET's earlier draft](https://github.com/AvaloniaUI/Avalonia/issues/14880#issuecomment-1985425341))

- [Installation](#installation)
- [Styled Components](#styled-components)
  - [Button](#button)
  - [CheckBox](#checkbox)
  - [ComboBox](#combobox)
  - [TabControl](#tabcontrol)
  - [TextBox](#textbox)
- [Next on our to-do list](#next-on-our-to-do-list)
  - [TreeView](#treeview)
  - [DataGrid](#datagrid)

## Installation
Install the Devolutions.MacOS.Avalonia.Theme package via NuGet:
``` bash
Install-Package Devolutions.MacOS.Avalonia.Theme
```
In your App.axaml, replace the existing theme (e.g., <FluentTheme /> or <SimpleTheme />) with the MacOS theme:
``` xaml
<Application ...>
  <Application.Styles>
     <StyleInclude Source="avares://Devolutions.MacOS.Avalonia.Theme/MacOSTheme.axaml" />
  </Application.Styles>
</Application>
```

## Styled Components

### Button
<video width="50%" controls source src="https://github.com/user-attachments/assets/4dddd7a3-ac49-49f7-aba1-88f0e0df0240" type="video/mp4"> Your browser does not support the video tag. </video>

### CheckBox
https://github.com/user-attachments/assets/4b2d3e5b-1f44-4007-adba-805a75012b97

### ComboBox
https://github.com/user-attachments/assets/ceaf88f8-f2ba-477c-873b-afe669f5c6e3

### TabControl
https://github.com/user-attachments/assets/2ad9fcf3-fbd1-4086-8abd-5973d8cd9593

### TextBox
https://github.com/user-attachments/assets/7bbfa22d-664b-41b4-9134-a8213c82d215


## Next on our to-do list

### TreeView
Coming soon ...

### DataGrid
