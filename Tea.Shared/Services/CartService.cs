using Tea.Shared.Models;

namespace Tea.Shared.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new();
        public event Action? CartChanged;

        public List<CartItem> GetCartItems() => _cartItems;

        public int GetCartItemCount() => _cartItems.Sum(item => item.Quantity);

        public decimal GetCartTotal() => _cartItems.Sum(item => item.TotalPrice);

        public void AddToCart(CartItem item)
        {
            var existingItem = _cartItems.FirstOrDefault(ci => 
                ci.Beverage.Id == item.Beverage.Id &&
                ci.SweetnessLevel == item.SweetnessLevel &&
                ci.IceLevel == item.IceLevel &&
                ci.SelectedToppings.Count == item.SelectedToppings.Count &&
                ci.SelectedToppings.All(t => item.SelectedToppings.Any(it => it.Id == t.Id))
            );

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                item.Id = _cartItems.Count > 0 ? _cartItems.Max(ci => ci.Id) + 1 : 1;
                _cartItems.Add(item);
            }

            CartChanged?.Invoke();
        }

        public void UpdateQuantity(int cartItemId, int quantity)
        {
            var item = _cartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _cartItems.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
                CartChanged?.Invoke();
            }
        }

        public void RemoveFromCart(int cartItemId)
        {
            var item = _cartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (item != null)
            {
                _cartItems.Remove(item);
                CartChanged?.Invoke();
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            CartChanged?.Invoke();
        }

        public string GenerateOrderNumber()
        {
            var random = new Random();
            return $"BT{DateTime.Now:yyyyMMdd}{random.Next(1000, 9999)}";
        }
    }
}