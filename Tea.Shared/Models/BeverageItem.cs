namespace Tea.Shared.Models
{
    public class BeverageItem
    {
        public int Id { get; set; }
        public string NameThai { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string DescriptionThai { get; set; } = string.Empty;
        public string DescriptionEnglish { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BeverageCategory Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsVegetarian { get; set; } = true;
    }

    public class Topping
    {
        public int Id { get; set; }
        public string NameThai { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}