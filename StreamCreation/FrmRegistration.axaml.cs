using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using Russkyc.AttachedUtilities.FileStreamExtensions;

namespace StreamCreation;

public partial class FrmRegistration : Window
{
    public FrmRegistration()
    {
        InitializeComponent();
    }

    private void BtnRegister_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            ValidateFields();
            
            var content = $"""
                          Student No.: {txtStudentNo.Text}
                          Full Name: {txtFirstName.Text} {txtMi.Text}. {txtLastName.Text}
                          Program: {selProgram.SelectionBoxItem}
                          Gender: {selGender.SelectionBoxItem}
                          Age: {TxtAge.Text}
                          Birthday: {dateBirthDay.SelectedDate:yyyy-MM-dd}
                          Contact No.: {txtContactNo.Text}
                          """;
            
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var docPath = Path.Combine(documentsPath, $"{txtStudentNo.Text}.txt");
            
            // We check if there is already a document with the same student number
            docPath.IsDocumentExist();
            
            // We check if there is already a document containing the same student name
            documentsPath.IsStudentExist($"{txtFirstName.Text} {txtMi.Text}. {txtLastName.Text}");

            docPath.StreamWrite(content);
            
            new ContentDialog
            {
                Title = "Registration",
                Content = $"Registration details for {txtStudentNo.Text} is saved in {docPath}",
                IsPrimaryButtonEnabled = false,
                IsSecondaryButtonEnabled = false,
                CloseButtonText = "Okay"
            }.ShowAsync();
            
            ClearFields();
        }
        catch (Exception exception)
        {
            new ContentDialog
            {
                Title = "Registration",
                Content = exception.Message,
                IsPrimaryButtonEnabled = false,
                IsSecondaryButtonEnabled = false,
                CloseButtonText = "Okay"
            }.ShowAsync();
        }
    }

    private void ClearFields()
    {
        selProgram.SelectedItem = null;
        selGender.SelectedItem = null;
        dateBirthDay.SelectedDate = null;

        txtContactNo.Text = string.Empty;
        txtStudentNo.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtMi.Text = string.Empty;
        TxtAge.Text = string.Empty;
    }

    private void ValidateFields()
    {
        txtStudentNo.Text.IsNotEmpty("student number");
        txtStudentNo.Text.IsStudentNumber();
            
        selProgram.SelectedItem.IsValidSelection("program");

        txtLastName.Text.IsNotEmpty("last name");
        txtFirstName.Text.IsNotEmpty("first name");
        txtMi.Text.IsNotEmpty("middle initial");
            
        TxtAge.Text.IsNotEmpty("age");
        TxtAge.Text.IsRealisticAge();
            
        selGender.SelectedItem.IsValidSelection("gender");
            
        dateBirthDay.Text.IsNotEmpty("birthday");
        dateBirthDay.SelectedDate.IsRealisticBirthday(TxtAge.Text);
            
        txtContactNo.Text.IsNotEmpty("contact number");
        txtContactNo.Text.IsContactNumber();
    }
}