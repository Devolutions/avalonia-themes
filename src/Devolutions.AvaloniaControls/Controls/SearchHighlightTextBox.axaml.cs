namespace Devolutions.AvaloniaControls.Controls;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;

public class SearchHighlightTextBox : ContentControl
{
    public static readonly DirectProperty<SearchHighlightTextBox, string> LeftTextProperty =
        AvaloniaProperty.RegisterDirect<SearchHighlightTextBox, string>(nameof(LeftText), static o => o.leftText);

    public static readonly DirectProperty<SearchHighlightTextBox, string> HighlightedTextProperty =
        AvaloniaProperty.RegisterDirect<SearchHighlightTextBox, string>(nameof(HighlightedText), static o => o.highlightedText);

    public static readonly DirectProperty<SearchHighlightTextBox, string> RightTextProperty =
        AvaloniaProperty.RegisterDirect<SearchHighlightTextBox, string>(nameof(RightText), static o => o.rightText);

    public static readonly DirectProperty<SearchHighlightTextBox, string?> SearchProperty =
        AvaloniaProperty.RegisterDirect<SearchHighlightTextBox, string?>(nameof(Search), static o => o.Search, static (o, v) => o.Search = v);

    public static readonly StyledProperty<IBrush?> HighlightBackgroundProperty =
        AvaloniaProperty.Register<SearchHighlightTextBox, IBrush?>(nameof(HighlightBackground));

    public static readonly StyledProperty<IBrush?> HighlightForegroundProperty =
        AvaloniaProperty.Register<SearchHighlightTextBox, IBrush?>(nameof(HighlightForeground));

    private string highlightedText = string.Empty;

    private string leftText = string.Empty;

    private string rightText = string.Empty;

    private string? search;

    public SearchHighlightTextBox()
    {
        this.GetObservable(ContentProperty).Subscribe(_ => this.ProcessHighlight());
        this.GetObservable(SearchProperty).Subscribe(_ => this.ProcessHighlight());
        this.ProcessHighlight();
    }

    public string LeftText => this.leftText;

    public string HighlightedText => this.highlightedText;

    public string RightText => this.rightText;

    public string? Search
    {
        get => this.search;
        set => this.SetAndRaise(SearchProperty, ref this.search, value);
    }

    public IBrush? HighlightBackground
    {
        get => this.GetValue(HighlightBackgroundProperty);
        set => this.SetValue(HighlightBackgroundProperty, value);
    }

    public IBrush? HighlightForeground
    {
        get => this.GetValue(HighlightForegroundProperty);
        set => this.SetValue(HighlightForegroundProperty, value);
    }

    private void ProcessHighlight()
    {
        var currentSearch = this.Search ?? string.Empty;
        var content = this.Content?.ToString() ?? string.Empty;

        var oldLeftText = this.leftText;
        var oldHighlightedText = this.highlightedText;
        var oldRightText = this.rightText;

        var highlightIndex = content.IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase);
        if (highlightIndex >= 0)
        {
            this.leftText = content[..highlightIndex];
            this.highlightedText = content.Substring(highlightIndex, currentSearch.Length);
            this.rightText = content[(highlightIndex + currentSearch.Length)..];
        }
        else
        {
            this.leftText = content;
            this.highlightedText = string.Empty;
            this.rightText = string.Empty;
        }

        this.RaisePropertyChanged(LeftTextProperty, oldLeftText, this.leftText);
        this.RaisePropertyChanged(HighlightedTextProperty, oldHighlightedText, this.highlightedText);
        this.RaisePropertyChanged(RightTextProperty, oldRightText, this.rightText);
    }
}