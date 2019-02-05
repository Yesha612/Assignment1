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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public icecream()
        {
            store_info = new HashSet<store_info>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlavourID { get; set; }

        [Required]
        [StringLength(50)]
        public string Flavour { get; set; }

        public int Calories { get; set; }

        public bool Gluten_Free { get; set; }

        public bool Dairy_Free { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<store_info> store_info { get; set; }
    }
}
