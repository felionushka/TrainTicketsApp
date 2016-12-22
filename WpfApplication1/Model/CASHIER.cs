namespace TrainTicketsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CASHIER")]
    public partial class CASHIER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CASHIER()
        {
            TICKET_SALE = new HashSet<TICKET_SALE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(12)]
        public string NAME { get; set; }

        [Required]
        [StringLength(15)]
        public string sURNAME { get; set; }

        [Required]
        [StringLength(8)]
        public string LOGIN { get; set; }

        [Required]
        [StringLength(6)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_SALE> TICKET_SALE { get; set; }
    }
}
