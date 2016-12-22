namespace TrainTicketsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TICKET")]
    public partial class TICKET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TICKET()
        {
            TICKET_SALE = new HashSet<TICKET_SALE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime TRAVEL_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRICE { get; set; }

        public bool STATE { get; set; }

        public int? ID_PLACE { get; set; }

        public int? ID_TRAIN { get; set; }

        public virtual PLACE PLACE { get; set; }

        public virtual TRAIN TRAIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_SALE> TICKET_SALE { get; set; }
    }
}
