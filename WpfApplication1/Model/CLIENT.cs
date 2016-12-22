namespace WpfApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENT")]
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            TICKET_SALE = new HashSet<TICKET_SALE>();
        }

        [Required]
        [StringLength(12)]
        public string NAME { get; set; }

        [Required]
        [StringLength(15)]
        public string SURNAME { get; set; }

        [Required]
        [StringLength(8)]
        public string PASSPORT_NUMBER { get; set; }

        public int ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_SALE> TICKET_SALE { get; set; }
    }
}
