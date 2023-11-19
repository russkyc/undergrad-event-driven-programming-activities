using System.Linq;
namespace BasicCalculator;

public static class Validations
{
    public static bool IsDivisible(params float[] values)
    {
        return values.All(value => value != 0);
    }

    public static (bool IsLesserPrecision, int Precision) IsLesserPrecision(string value)
    {
        // Float is limited to a precision of 7 digits(where X in X.# is counted as 1)
        // If the whole number is more than single digit, added digits deduct from the decimal precision
        // eg; ### will only support a precision of 4 digits (###.####)
        var precision = 7 - value.Split(".").First().Length;
        var isLesserPrecision = precision < 6;
        return (isLesserPrecision, precision);
    }
}