using Tea.Shared.Models;

namespace Tea.Shared.Services
{
    public class BeverageService
    {
        private readonly List<BeverageItem> _beverages;
        private readonly List<Topping> _toppings;

        public BeverageService()
        {
            _beverages = GetBeverages();
            _toppings = GetToppings();
        }

        public List<BeverageItem> GetAllBeverages() => _beverages;

        public List<BeverageItem> GetBeveragesByCategory(BeverageCategory category)
        {
            return _beverages.Where(b => b.Category == category).ToList();
        }

        public BeverageItem? GetBeverageById(int id)
        {
            return _beverages.FirstOrDefault(b => b.Id == id);
        }

        public List<Topping> GetAllToppings() => _toppings;

        private List<BeverageItem> GetBeverages()
        {
            return new List<BeverageItem>
            {
                // กลุ่มเครื่องดื่มกาแฟ
                new BeverageItem { Id = 1, NameThai = "ชาไข่มุกกาแฟคลาสสิก", NameEnglish = "Classic Coffee Bubble Tea", DescriptionThai = "กาแฟหอมกรุ่นพร้อมไข่มุกนุ่ม", DescriptionEnglish = "Aromatic coffee with soft pearls", Price = 89, Category = BeverageCategory.Coffee, ImageUrl = "/img/classic-coffee.svg" },
                new BeverageItem { Id = 2, NameThai = "คาปูชิโน่ไข่มุก", NameEnglish = "Cappuccino Bubble Tea", DescriptionThai = "ครีมนุ่มผสมเสียงฟองนม", DescriptionEnglish = "Creamy smooth with milk foam", Price = 95, Category = BeverageCategory.Coffee, ImageUrl = "/img/cappuccino.svg" },
                new BeverageItem { Id = 3, NameThai = "เอสเปรสโซ่ไข่มุก", NameEnglish = "Espresso Bubble Tea", DescriptionThai = "กาแฟเข้มข้นสุดยอด", DescriptionEnglish = "Ultimate strong coffee", Price = 99, Category = BeverageCategory.Coffee, ImageUrl = "/img/espresso.svg" },
                new BeverageItem { Id = 4, NameThai = "มอคค่าช็อกโกแลต", NameEnglish = "Mocha Chocolate", DescriptionThai = "หวานมันของช็อกโกแลตแท้", DescriptionEnglish = "Sweet richness of real chocolate", Price = 109, Category = BeverageCategory.Coffee, ImageUrl = "/img/mocha.svg" },

                // กลุ่มเครื่องดื่มชา
                new BeverageItem { Id = 5, NameThai = "ชาไทยไข่มุก", NameEnglish = "Thai Tea Bubble", DescriptionThai = "ชาไทยเข้มข้นรสแท้", DescriptionEnglish = "Rich authentic Thai tea", Price = 79, Category = BeverageCategory.Tea, ImageUrl = "/img/thai-tea.svg" },
                new BeverageItem { Id = 6, NameThai = "ชาเขียวมัทฉะ", NameEnglish = "Matcha Green Tea", DescriptionThai = "มัทฉะญี่ปุ่นแท้", DescriptionEnglish = "Authentic Japanese matcha", Price = 89, Category = BeverageCategory.Tea, ImageUrl = "/img/matcha.svg" },
                new BeverageItem { Id = 7, NameThai = "ชาอู่หลงพรีเมี่ยม", NameEnglish = "Premium Oolong Tea", DescriptionThai = "ชาอู่หลงคุณภาพสูง", DescriptionEnglish = "High quality oolong tea", Price = 95, Category = BeverageCategory.Tea, ImageUrl = "/img/oolong.svg" },
                new BeverageItem { Id = 8, NameThai = "เลมอนที", NameEnglish = "Lemon Tea", DescriptionThai = "ชาเลมอนสดชื่น", DescriptionEnglish = "Fresh lemon tea", Price = 85, Category = BeverageCategory.Tea, ImageUrl = "/img/lemon-tea.svg" },

                // กลุ่มเครื่องดื่มผลไม้
                new BeverageItem { Id = 9, NameThai = "แมงโก้ไข่มุก", NameEnglish = "Mango Bubble Tea", DescriptionThai = "แมงโก้สดหวานนุ่ม", DescriptionEnglish = "Fresh sweet mango", Price = 99, Category = BeverageCategory.Fruit, ImageUrl = "/img/mango.svg" },
                new BeverageItem { Id = 10, NameThai = "สตรอเบอร์รี่ครีม", NameEnglish = "Strawberry Cream", DescriptionThai = "สตรอเบอร์รี่สดพร้อมครีม", DescriptionEnglish = "Fresh strawberry with cream", Price = 105, Category = BeverageCategory.Fruit, ImageUrl = "/img/strawberry.svg" },
                new BeverageItem { Id = 11, NameThai = "ลิ้นจี่ไข่มุก", NameEnglish = "Lychee Bubble Tea", DescriptionThai = "ลิ้นจี่หวานซ่าส์", DescriptionEnglish = "Sweet refreshing lychee", Price = 95, Category = BeverageCategory.Fruit, ImageUrl = "/img/lychee.svg" },
                new BeverageItem { Id = 12, NameThai = "ส้มยูซุ", NameEnglish = "Yuzu Orange", DescriptionThai = "ยูซุญี่ปุ่นหอมสดชื่น", DescriptionEnglish = "Fragrant Japanese yuzu", Price = 109, Category = BeverageCategory.Fruit, ImageUrl = "/img/yuzu.svg" },

                // กลุ่มพิเศษ
                new BeverageItem { Id = 13, NameThai = "ทาโร่ไข่มุก", NameEnglish = "Taro Bubble Tea", DescriptionThai = "เผือกหวานนุ่มลิ้น", DescriptionEnglish = "Sweet smooth taro", Price = 89, Category = BeverageCategory.Special, ImageUrl = "/img/taro.svg" },
                new BeverageItem { Id = 14, NameThai = "โกโก้ไข่มุก", NameEnglish = "Cocoa Bubble Tea", DescriptionThai = "โกโก้เข้มข้นหอมหวน", DescriptionEnglish = "Rich aromatic cocoa", Price = 85, Category = BeverageCategory.Special, ImageUrl = "/img/cocoa.svg" }
            };
        }

        private List<Topping> GetToppings()
        {
            return new List<Topping>
            {
                new Topping { Id = 1, NameThai = "ไข่มุกเพิ่ม", NameEnglish = "Extra Popping Bobas", Price = 15 },
                new Topping { Id = 2, NameThai = "วิปครีม", NameEnglish = "Whipped Cream", Price = 20 },
                new Topping { Id = 3, NameThai = "ช็อกโกแลตเกล็ด", NameEnglish = "Dark Chocolate Shavings", Price = 25 },
                new Topping { Id = 4, NameThai = "ฟองนมหยี", NameEnglish = "Saffron Infused Milk Foam", Price = 30 },
                new Topping { Id = 5, NameThai = "เจลลี่ผลไม้", NameEnglish = "Fruit Jelly", Price = 18 },
                new Topping { Id = 6, NameThai = "พุดดิ้งไข่", NameEnglish = "Egg Pudding", Price = 22 }
            };
        }
    }
}