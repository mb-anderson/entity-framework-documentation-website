using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documentation.Service.Models
{
    public class Dokuman
    {
        [Key]
        public int DokumanID { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "Başlık Zorunludur")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama Zorunludur")]
        public string Subtitle { get; set; }

        public string Content { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;

        [DisplayName("Kategori")]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
