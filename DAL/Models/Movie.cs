using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Plot")]
        public string Plot { get; set; }

        [Display(Name = "DateOfRelease")]
        public DateTime DateOfRelease { get; set; }

        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Actor")]
        public int? ActorId { get; set; }
        public Actor Actor { get; set; }

        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

        [ForeignKey("Image")]
        public int? PosterId { get; set; }
        public Image Image { get; set; }

    }
}
