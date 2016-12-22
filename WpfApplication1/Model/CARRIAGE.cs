namespace TrainTicketsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CARRIAGE")]
    public partial class CARRIAGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARRIAGE()
        {
            PLACEs = new HashSet<PLACE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int NUMBER { get; set; }

        [Required]
        [StringLength(8)]
        public string TYPE { get; set; }

        public int? ID_TRAIN { get; set; }

        public virtual TRAIN TRAIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLACE> PLACEs { get; set; }
    }
}
