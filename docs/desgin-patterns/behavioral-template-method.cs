abstract class CookingRecipe
{
  public void Cook()
  {
    PrepareIngredients();
    CookMain();
    Serve();
  }

  protected abstract void PrepareIngredients();
  protected abstract void CookMain();
  
  protected void Serve() => Console.WriteLine("Dish served.");
}

class PastaRecipe : CookingRecipe
{
  protected override void PrepareIngredients() => Console.WriteLine("Preparing pasta ingredients.");

  protected override void CookMain() => Console.WriteLine("Cooking pasta.");
}

class Client
{
  public static void Main()
  {
    CookingRecipe recipe = new PastaRecipe();
    recipe.Cook();
  }
}
