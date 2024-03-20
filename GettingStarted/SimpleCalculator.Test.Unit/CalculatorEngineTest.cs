namespace SimpleCalculator.Test.Unit;

[TestFixture]
public class CalculatorEngineTest
{
    private CalculatorEngine _calculatorEngine;
    [SetUp]
    public void Setup()
    {
        _calculatorEngine = new CalculatorEngine();
    }

    [Test]
    public void AddsTwoNumberAndReturnsValidResult()
    {
        double input1 = 2;
        double input2 = 4;
        double result = _calculatorEngine.Calculate(Operators.Add, input1, input2);
        Assert.AreEqual(6, result);
    }
    
    [Test]
    public void FailsIntegerDivideIntoNonIntergerInput()
    {
        double input1 = 2;
        double input2 = 4.3;
        Assert.Throws<ArgumentException>(() =>_calculatorEngine.Calculate(Operators.Div, input1, input2));
    }
}