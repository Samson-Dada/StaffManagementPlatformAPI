namespace StaffManagementPlatfromAPI.Utilities
{
    public static class CalculateAge
    {
        public static int GetCurrentAge(this DateTime date)
        {
            var dateOfBirth = DateTime.Now;
            int age = DateTime.Today.Year - date.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            Console.WriteLine($"Age: {age}");
            return age;
        }
    }
}
