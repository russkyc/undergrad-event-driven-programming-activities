using System;
using System.IO;
using System.Linq;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace StreamCreation;

public partial class FrmLab1 : AppWindow
{
    public FrmLab1()
    {
        InitializeComponent();
    }

    private async void BtnCreate_OnClick(object? sender, RoutedEventArgs eventArgs)
    {
        // we create the missing var
        var getInput = txtInput.Text;

        if (string.IsNullOrWhiteSpace(getInput))
        {
            await new ContentDialog
            {
                Title = "Stream Creation",
                Content = "Content can not be empty",
                CloseButtonText = "Okay"
            }.ShowAsync();
            return;
        }
        
        await new FrmFileName().ShowDialog(this);

        if (string.IsNullOrWhiteSpace(FrmFileName.SetFileName))
        {
            await new ContentDialog
            {
                Title = "Stream Creation",
                Content = "Filename not given, stream will not write",
                CloseButtonText = "Okay"
            }.ShowAsync();
            return;
        }
        
        try
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (Path.GetInvalidPathChars()
                .Any(invalidChar => FrmFileName.SetFileName.Contains(invalidChar))
                || Path.GetInvalidFileNameChars()
                    .Any(invalidChar => FrmFileName.SetFileName.Contains(invalidChar)))
            {
                await new ContentDialog
                {
                    Title = "Stream Creation",
                    Content = "File name cannot contain reserved characters",
                    CloseButtonText = "Okay"
                }.ShowAsync();
                return;
            }
            
            await using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName));
            await outputFile.WriteLineAsync(getInput);
            Console.WriteLine(getInput);
            txtInput.Text = string.Empty;
            
            await new ContentDialog
            {
                Title = "Stream Creation",
                Content = $"Content saved to {Path.Combine(docPath, FrmFileName.SetFileName)}",
                CloseButtonText = "Okay"
            }.ShowAsync();
            FrmFileName.SetFileName = string.Empty;
        }
        catch (Exception e)
        {
            await new ContentDialog
            {
                Title = "Stream Creation",
                Content = e switch
                {
                    InvalidOperationException => "Cannot write to file, the file is currently locked",
                    _ => "The program encountered an internal error"
                },
                CloseButtonText = "Okay"
            }.ShowAsync();
            FrmFileName.SetFileName = string.Empty;
        }
    }
}