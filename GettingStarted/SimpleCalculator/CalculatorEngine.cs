namespace SimpleCalculator;

public class CalculatorEngine
{
    public double Calculate(Operators op, double input1, double input2)
    {
        double result;
        switch (op)
        {
            case Operators.Add :
                result = input1 + input2;
                break;
            case Operators.Subtract :
                result = input1 - input2;
                break;
            case Operators.Mupliply:
                result = input1 * input2;
                break;
            case Operators.Divide:
                result = input1 / input2;
                break;
            case Operators.Modulo:
                try
                {
                    int intVal1 = int.Parse(input1.ToString());
                    int intVal2 = int.Parse(input2.ToString());
                    result = intVal1 % intVal2;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"{ex.Message}. Integer expected.", ex);
                }
                break;
            case Operators.Div:
                try
                {
                    int intVal11 = int.Parse(input1.ToString());
                    int intVal22 = int.Parse(input2.ToString());
                    result = intVal11 / intVal22;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"{ex.Message}. Integer expected.", ex);
                }
                break;
            default:
                throw new InvalidOperationException("Specified operator is not recognized");
        }

        return result;
    }
}