using NuGet.Packaging;

namespace User_Management_WebApp.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermitionsList(string module)
        {
            return new List<string>
            {
                $"{ClaimTypes.Permations}.{module}.View",
                $"{ClaimTypes.Permations}.{module}.Details",
                $"{ClaimTypes.Permations}.{module}.Create",
                $"{ClaimTypes.Permations}.{module}.Edit",
                $"{ClaimTypes.Permations}.{module}.Delete",
                $"{ClaimTypes.Permations}.{module}.SoftDelete",
                $"{ClaimTypes.Permations}.{module}.Restore",
                $"{ClaimTypes.Permations}.{module}.Active",
                $"{ClaimTypes.Permations}.{module}.Desactive",
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
    }
}
