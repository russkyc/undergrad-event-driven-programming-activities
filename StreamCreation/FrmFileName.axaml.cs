using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace StreamCreation;

public partial class FrmFileName : AppWindow
{

    public static string SetFileName = string.Empty;
    
    public FrmFileName()
    {
        InitializeComponent();
    }

    private async void BtnOkay_OnClick(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFileName.Text))
        {
            await new ContentDialog
            {
                Title = "Stream Creation",
                Content = "Please enter a filename",
                CloseButtonText = "Okay"
            }.ShowAsync();
            return;
        }
        SetFileName = $"{txtFileName.Text}.text";
        Close();
    }

}