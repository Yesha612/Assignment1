namespace TheIcecreamParlour.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class store_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreLocationId { get; set; }

        [Required]
        [StringLength(50)]
        public string StoreName { get; set; }

        public int FlavourID { get; set; }

        [Required]
        [StringLength(50)]
        public string Flavour { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public virtual store_info store_info1 { get; set; }

        public virtual store_info store_info2 { get; set; }
    }
}
