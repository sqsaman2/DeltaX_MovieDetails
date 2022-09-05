using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DAL.Enums.ApplicationEnum;

namespace DAL.Models
{
    [Table("Actor")]
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "DateofBirth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }

        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;

    }
}
