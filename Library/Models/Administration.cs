
using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    public class Administration
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }

    }
}
