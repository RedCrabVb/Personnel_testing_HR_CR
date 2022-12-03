using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Data.Entity
{
    public class PersonModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
    }
}
