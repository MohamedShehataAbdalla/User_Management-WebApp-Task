using NuGet.Packaging;

namespace User_Management_WebApp.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermitionsList(string module)
        {
            return new List<string>
            {
                $"{ClaimPermationTypes.Permations}.{module}.View",
                $"{ClaimPermationTypes.Permations}.{module}.Details",
                $"{ClaimPermationTypes.Permations}.{module}.Create",
                $"{ClaimPermationTypes.Permations}.{module}.Edit",
                $"{ClaimPermationTypes.Permations}.{module}.Delete",
                $"{ClaimPermationTypes.Permations}.{module}.SoftDelete",
                $"{ClaimPermationTypes.Permations}.{module}.Restore",
                $"{ClaimPermationTypes.Permations}.{module}.Active",
                $"{ClaimPermationTypes.Permations}.{module}.Desactive",
            };
        }

        public static List<string> GenerateAllPermitions()
        {
            var allPermitions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermitions.AddRange(GeneratePermitionsList(module.ToString()!));

            return allPermitions;
        }

        public static class Employee
        {
            public const string View = "Permations.Employee.View";
            public const string Details = "Permations.Employee.Details";
            public const string Create = "Permations.Employee.Create";
            public const string Edit = "Permations.Employee.Edit";
            public const string Delete = "Permations.Employee.Delete";
            public const string SoftDelete = "Permations.Employee.SoftDelete";
            public const string Restore = "Permations.Employee.Restore";
            public const string Active = "Permations.Employee.Active";
            public const string Desactive = "Permations.Employee.Desactive";
        }

        public static class Product
        {
            public const string View = "Permations.Product.View";
            public const string Details = "Permations.Product.Details";
            public const string Create = "Permations.Product.Create";
            public const string Edit = "Permations.Product.Edit";
            public const string Delete = "Permations.Product.Delete";
            public const string SoftDelete = "Permations.Product.SoftDelete";
            public const string Restore = "Permations.Product.Restore";
            public const string Active = "Permations.Product.Active";
            public const string Desactive = "Permations.Product.Desactive";
        }
        public static class Category
        {
            public const string View = "Permations.Category.View";
            public const string Details = "Permations.Category.Details";
            public const string Create = "Permations.Category.Create";
            public const string Edit = "Permations.Category.Edit";
            public const string Delete = "Permations.Category.Delete";
            public const string SoftDelete = "Permations.Category.SoftDelete";
            public const string Restore = "Permations.Category.Restore";
            public const string Active = "Permations.Category.Active";
            public const string Desactive = "Permations.Category.Desactive";
        }

        public static class Stock
        {
            public const string View = "Permations.Stock.View";
            public const string Details = "Permations.Stock.Details";
            public const string Create = "Permations.Stock.Create";
            public const string Edit = "Permations.Stock.Edit";
            public const string Delete = "Permations.Stock.Delete";
            public const string SoftDelete = "Permations.Stock.SoftDelete";
            public const string Restore = "Permations.Stock.Restore";
            public const string Active = "Permations.Stock.Active";
            public const string Desactive = "Permations.Stock.Desactive";
        }
    }
}
