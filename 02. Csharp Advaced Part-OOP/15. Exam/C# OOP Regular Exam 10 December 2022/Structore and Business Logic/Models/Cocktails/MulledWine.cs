namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double Price = 13.50;
        public MulledWine(string name, string size) 
            : base(name, size, Price)
        {
        }
    }
}
