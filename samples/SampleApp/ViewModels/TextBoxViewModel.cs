namespace SampleApp.ViewModels;

using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class TextBoxViewModel : ObservableValidator
{
  [ObservableProperty] [Required(ErrorMessage = "This Input is required.", AllowEmptyStrings = false)] [NotifyDataErrorInfo]
  private string _requiredInput = string.Empty;
}