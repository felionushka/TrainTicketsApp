namespace WpfApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLACE")]
    public partial class PLACE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLACE()
        {
            TICKETs = new HashSet<TICKET>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        public string TIER { get; set; }

        public int? ID_CARRIAGE { get; set; }

        public virtual CARRIAGE CARRIAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKETs { get; set; }
    }
}
