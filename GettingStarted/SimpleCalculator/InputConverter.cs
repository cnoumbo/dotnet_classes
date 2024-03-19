namespace SimpleCalculator;

public class InputConverter
{
    public double ConvertInputToNumeric(string input)
    {
        double converterNumber;
        if (!double.TryParse(input, out converterNumber)) throw new ArgumentException("Expected a numeric value");
        return converterNumber;
    }
}