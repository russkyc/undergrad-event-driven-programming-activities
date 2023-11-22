using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CalculatorPrivateAssembly;

namespace BasicCalculator;

// ReSharper disable UnusedParameter.Local
// ReSharper disable once UnusedMember.Local
public partial class FrmBasicCalculator : Window
{
    private string Operation { get; set; } = null!;
    
    public FrmBasicCalculator()
    {
        InitializeComponent();
    }
    
    private void Calculate(object? sender, RoutedEventArgs args)
    {
        try
        {
            Message.Text = string.Empty;
            var num1 = float.Parse(TxtNum1.Text!);
            var num2 = float.Parse(TxtNum2.Text!);

            Func<float,float,float> operation = CbxOperands.SelectedIndex switch
            {
                0 => BasicComputation.Add,
                1 => BasicComputation.Subtract,
                2 => BasicComputation.Multiply,
                3 => BasicComputation.Divide,
                _ => throw new ArgumentOutOfRangeException()
            };

            if (!Validations.IsDivisible(num1, num2)
                && operation.Method.Name is nameof(BasicComputation.Divide))
            {
                Message.Text = "Cannot divide by zero";
                TxtTotal.Text = String.Empty;
                return;
            }

            // This is so we can translate the scientific notation back to floating point
            var result = operation.Invoke(num1, num2).ToString("0.######", CultureInfo.CurrentUICulture);
            
            // The float primitive only supports a 7 digit precision, so we take that into account
            var validationResult = Validations.IsLesserPrecision(result);
            if (validationResult.IsLesserPrecision)
            {
                var precision = validationResult.Precision < 0 ? 0 : validationResult.Precision;
                Message.Text = $"Limited to a float precision of {precision} decimal places.";
            }
            
            TxtTotal.Text = result;
        }
        // Should handle all exceptions by default to throw zero errors
        catch (Exception e)
        {
            Message.Text = e switch
            {
                ArgumentNullException => "Please make sure none of the inputs are blank",
                FormatException => "Please make sure all inputs are valid numbers",
                ArgumentOutOfRangeException => "Please select an operation",
                _ => "There seems to be an internal problem with the app."
            };
        }
    }

}