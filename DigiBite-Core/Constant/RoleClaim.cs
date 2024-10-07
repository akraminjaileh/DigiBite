namespace DigiBite_Core.Constant
{
    public static class RoleClaim
    {
        public static Dictionary<string, string> Claims
        {
            get =>
                 new Dictionary<string, string>()
                 {
                      // Cart Claims
                      { "Cart.Read", "false"},
                      { "Cart.Create", "false"},
                      { "Cart.Update", "false"},
                      { "Cart.Delete", "false"},
                      // Category Claims
                      { "Category.Read", "false"},
                      { "Category.Create", "false"},
                      { "Category.Update", "false"},
                      { "Category.Delete", "false"},
                      // Ingredient Claims
                      { "Ingredient.Read", "false"},
                      { "Ingredient.Create", "false"},
                      { "Ingredient.Update", "false"},
                      { "Ingredient.Delete", "false"},
                      // Item Claims
                      { "Item.Read", "false"},
                      { "Item.Create", "false"},
                      { "Item.Update", "false"},
                      { "Item.Delete", "false"},
                      // Meal Claims
                      { "Meal.Read", "false"},
                      { "Meal.Create", "false"},
                      { "Meal.Update", "false"},
                      { "Meal.Delete", "false"},
                       // Order Claims
                      { "Order.Read", "false"},
                      { "Order.Create", "false"},
                      { "Order.Update", "false"},
                      { "Order.Delete", "false"},
                      // Address Claims
                      { "Address.Read", "false"},
                      { "Address.Create", "false"},
                      { "Address.Update", "false"},
                      { "Address.Delete", "false"},
                      // Image Claims
                      { "Image.Read", "false"},
                      { "Image.Create", "false"},
                      { "Image.Update", "false"},
                      { "Image.Delete", "false"},
                      // Voucher Claims
                      { "Voucher.Read", "false"},
                      { "Voucher.Create", "false"},
                      { "Voucher.Update", "false"},
                      { "Voucher.Delete", "false"},
                      // EmployeeInformation Claims
                      { "EmployeeInformation.Read", "false"},
                      { "EmployeeInformation.Create", "false"},
                      { "EmployeeInformation.Update", "false"},
                      { "EmployeeInformation.Delete", "false"},
                       // EmployeeDocument Claims
                      { "EmployeeDocument.Read", "false"},
                      { "EmployeeDocument.Create", "false"},
                      { "EmployeeDocument.Update", "false"},
                      { "EmployeeDocument.Delete", "false"},
                      // AddOn Claims
                      { "AddOn.Read", "false"},
                      { "AddOn.Create", "false"},
                      { "AddOn.Update", "false"},
                      { "AddOn.Delete", "false"},
                 };

        }


        // Cart Claims
        public static class Cart
        {
            public const string Read = "Cart.Read";
            public const string Create = "Cart.Create";
            public const string Update = "Cart.Update";
            public const string Delete = "Cart.Delete";
        }

        // Category Claims
        public static class Category
        {
            public const string Read = "Category.Read";
            public const string Create = "Category.Create";
            public const string Update = "Category.Update";
            public const string Delete = "Category.Delete";
        }

        // Ingredient Claims
        public static class Ingredient
        {
            public const string Read = "Ingredient.Read";
            public const string Create = "Ingredient.Create";
            public const string Update = "Ingredient.Update";
            public const string Delete = "Ingredient.Delete";
        }

        // Item Claims
        public static class Item
        {
            public const string Read = "Item.Read";
            public const string Create = "Item.Create";
            public const string Update = "Item.Update";
            public const string Delete = "Item.Delete";
        }

        // Meal Claims
        public static class Meal
        {
            public const string Read = "Meal.Read";
            public const string Create = "Meal.Create";
            public const string Update = "Meal.Update";
            public const string Delete = "Meal.Delete";
        }

        // Order Claims
        public static class Order
        {
            public const string Read = "Order.Read";
            public const string Create = "Order.Create";
            public const string Update = "Order.Update";
            public const string Delete = "Order.Delete";
        }

        // Address Claims
        public static class Address
        {
            public const string Read = "Address.Read";
            public const string Create = "Address.Create";
            public const string Update = "Address.Update";
            public const string Delete = "Address.Delete";
        }

        // Image Claims
        public static class Image
        {
            public const string Read = "Image.Read";
            public const string Create = "Image.Create";
            public const string Update = "Image.Update";
            public const string Delete = "Image.Delete";
        }

        // Voucher Claims
        public static class Voucher
        {
            public const string Read = "Voucher.Read";
            public const string Create = "Voucher.Create";
            public const string Update = "Voucher.Update";
            public const string Delete = "Voucher.Delete";
        }

        // EmployeeInformation Claims
        public static class EmployeeInformation
        {
            public const string Read = "EmployeeInformation.Read";
            public const string Create = "EmployeeInformation.Create";
            public const string Update = "EmployeeInformation.Update";
            public const string Delete = "EmployeeInformation.Delete";
        }

        // EmployeeDocument Claims
        public static class EmployeeDocument
        {
            public const string Read = "EmployeeDocument.Read";
            public const string Create = "EmployeeDocument.Create";
            public const string Update = "EmployeeDocument.Update";
            public const string Delete = "EmployeeDocument.Delete";
        }

        // AddOn Claims
        public static class AddOn
        {
            public const string Read = "AddOn.Read";
            public const string Create = "AddOn.Create";
            public const string Update = "AddOn.Update";
            public const string Delete = "AddOn.Delete";
        }
    }
}

