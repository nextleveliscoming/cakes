namespace CakesAdvanced
{
    public class Cake
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        private List<Ingredient> _ingredients = new List<Ingredient>();

        public Cake(string name, List<Ingredient> ingredients)
        {
            Name = name;

            _ingredients = ingredients;

            Price = _ingredients.Sum(item => item.Quantity * item.Cost + (item.Quantity * item.Cost * 0.5m));
        }

    }
}
