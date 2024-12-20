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
<img src="https://github.com/user-attachments/assets/49093553-a8b6-4cbe-b7a5-7c8f6a8ead3b" alt="Buttons 2024-12-19" width="300">

### CheckBox
<img src="https://github.com/user-attachments/assets/30182450-b339-49d4-9aab-96cef627d0ca" alt="Buttons 2024-12-19" width="723">

### ComboBox
<img src="https://github.com/user-attachments/assets/7a8ed69e-1e1c-4218-9b97-591f5b7baaba" alt="Buttons 2024-12-19" width="461">

### TabControl
<img src="https://github.com/user-attachments/assets/4f88ce2c-59f9-4f85-b2db-a47fe0301472" alt="Buttons 2024-12-19" width="515">

### TextBox
<img src="https://github.com/user-attachments/assets/4c14fdcd-f41d-41f0-aa39-1b37d7f5ab26" alt="Buttons 2024-12-19" width="332">


## Next on our to-do list

### TreeView
Coming soon ...

### DataGrid
