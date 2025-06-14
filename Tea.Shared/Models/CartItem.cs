namespace Tea.Shared.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public BeverageItem Beverage { get; set; } = new();
        public List<Topping> SelectedToppings { get; set; } = new();
        public SweetnessLevel SweetnessLevel { get; set; } = SweetnessLevel.Half;
        public IceLevel IceLevel { get; set; } = IceLevel.Normal;
        public int Quantity { get; set; } = 1;
        
        public decimal TotalPrice 
        { 
            get 
            { 
                var beveragePrice = Beverage.Price;
                var toppingsPrice = SelectedToppings.Sum(t => t.Price);
                return (beveragePrice + toppingsPrice) * Quantity;
            } 
        }
    }
}