using System.ComponentModel.DataAnnotations;

namespace Documentation.Service.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        public string Name { get; set; }

        public virtual ICollection<Dokuman> Dokuman { get; set; }
    }
}
