namespace TheIcecreamParlour.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("icecream")]
    public partial class icecream
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlavourID { get; set; }

        [Required]
        [StringLength(50)]
        public string Flavour { get; set; }

        public int Calories { get; set; }

        public bool Gluten_Free { get; set; }

        public bool Dairy_Free { get; set; }
    }
}
