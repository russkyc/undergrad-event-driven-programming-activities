using System;
using System.IO;
using System.Text.RegularExpressions;
using Russkyc.AttachedUtilities.FileStreamExtensions;

namespace StreamCreation;

public static class Validations
{
    public static void IsStudentNumber(this string? studentNumber)
    {
        if (studentNumber is null || !Regex.IsMatch(studentNumber, "^02[0-9]{9}$"))
        {
            throw new FormatException("Please enter a valid student Number");
        }
    }

    public static void IsContactNumber(this string? contactNumber)
    {
        if (contactNumber is null || !Regex.IsMatch(contactNumber, "^09[0-9]{9}$"))
        {
            throw new FormatException("Please enter a valid contact number");
        }
    }

    public static void IsNotEmpty(this string? text, string field)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new FormatException($"Please fill in your {field}");
        }
    }

    public static void IsValidSelection(this object? selection, string field)
    {
        if (selection is null || string.IsNullOrWhiteSpace(selection.ToString()))
        {
            throw new FormatException($"Please select a {field}");
        }
    }

    public static void IsRealisticBirthday(this DateTime? birthday, string? age)
    {
        var birthdayValue = birthday ?? throw new FormatException("Age is not a valid number");
        var ageValue = age ?? throw new FormatException("Age is not a valid number");

        if (!int.TryParse(ageValue, out int numAge))
        {
            throw new FormatException("Age is not a valid number");
        }

        // We check if age matches the selected birthday
        if (birthdayValue.AddYears(numAge).Year != DateTime.Now.Year)
        {
            throw new FormatException("Selected birthday does not match entered age");
        }

        var min = DateTime.Today.AddYears(-16);
        var max = DateTime.Today.AddYears(-122);

        if (DateTime.Compare(birthdayValue, min) > 0 || DateTime.Compare(birthdayValue, max) < 0)
        {
            throw new FormatException("Please enter a realistic birthday");
        }
    }
    
    public static void IsRealisticAge(this string? age)
    {
        if (age is null)
        {
            throw new FormatException("Please enter an age between 16 and 122");
        }
        try
        {
            var realAge = int.Parse(age);
            if (realAge is < 16 or > 122)
            {
                throw new FormatException("Please enter an age between 16 and 122");
            }
        }
        catch (Exception _)
        {
            throw new FormatException("Please enter an age between 16 and 122");
        }
    }

    public static void IsDocumentExist(this string path)
    {
        // We need to check if document exists so we avoid duplicate registrations
        if (File.Exists(path))
        {
            throw new FormatException("A student with the same student number already exists");
        }
    }

    public static void IsStudentExist(this string folderPath, string name)
    {
        var directoryInfo = new DirectoryInfo(folderPath);
        foreach (var fileinfo in directoryInfo.EnumerateFiles())
        {
            // If document name doesn't match, we check for contents if there is a matching record
            var content = fileinfo.FullName.StreamRead();
            if (content.Contains(name))
            {
                throw new FormatException("Student with the same name is already registered");
            }
        }
    }

}