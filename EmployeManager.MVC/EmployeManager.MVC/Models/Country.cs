using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeManager.MVC.Models
{
    [Table("Country")]
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
