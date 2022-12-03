using Microsoft.AspNetCore.Mvc;

namespace Personnel_testing_HR_CR.Data.Entity
{
    public class PersonModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
    }
}
