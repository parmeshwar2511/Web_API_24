using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsing_EF.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar")]
        [StringLength (50)]
        public string Name { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public bool IsCreate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }

    }
}