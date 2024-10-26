interface ITaxStrategy
{
  decimal CalculateTax(decimal income);
}

class RegularTaxStrategy : ITaxStrategy
{
  public decimal CalculateTax(decimal income) => income * 0.2m;
}

class ReducedTaxStrategy : ITaxStrategy
{
  public decimal CalculateTax(decimal income) => income * 0.1m;
}

class TaxCalculator
{
  private ITaxStrategy taxStrategy;

  public void SetTaxStrategy(ITaxStrategy strategy) => taxStrategy = strategy;

  public decimal Calculate(decimal income) => taxStrategy.CalculateTax(income);
}

class Client
{
  public static void Main()
  {
    TaxCalculator calculator = new TaxCalculator();

    calculator.SetTaxStrategy(new RegularTaxStrategy());
    Console.WriteLine(calculator.Calculate(1000)); // 200

    calculator.SetTaxStrategy(new ReducedTaxStrategy());
    Console.WriteLine(calculator.Calculate(1000)); // 100
  }
}
