namespace SimpleCalculator;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            InputConverter inputConverter = new InputConverter();
            CalculatorEngine calculatorEngine = new CalculatorEngine();
            Operators chosenOperator = Menu();

            Console.Write("Entrer the first number : ");
            double input1 = inputConverter.ConvertInputToNumeric(Console.ReadLine());
            Console.Write("Entrer the first number : ");
            double input2 = inputConverter.ConvertInputToNumeric(Console.ReadLine());

            double result = calculatorEngine.Calculate(chosenOperator, input1, input2);

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Operators Menu()
    {
        Console.WriteLine(" ====== Welcome to our awesome Simple Calculator ====== ");
        foreach (Operators item in Enum.GetValues(typeof(Operators)))
        {
            Console.WriteLine("{0}. {1}", (int)item, item);
        }
        Console.Write("Select Operator : ");
        string input = Console.ReadLine()!;
        
        Operators chosenOp = (Operators) Enum.Parse(typeof(Operators), input!, true);

        return chosenOp;
    }
}