using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private Theme[] availableThemes = [
        new LinuxYaruTheme(),
        new DevExpressTheme(),
        new MacOsTheme(),
    ];
    
    [ObservableProperty]
    private Theme currentTheme;

    public MainWindowViewModel()
    {
        this.CurrentTheme = AvailableThemes.FirstOrDefault(t => Equals(t, App.CurrentTheme!))!;
    }
}