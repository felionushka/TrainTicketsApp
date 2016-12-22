namespace TrainTicketsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TICKET_SALE
    {
        [Column(TypeName = "date")]
        public DateTime SELL_DATE { get; set; }

        public int ID_CLIENT { get; set; }

        public int ID_TICKET { get; set; }

        public int ID_CASHIER { get; set; }

        public int ID { get; set; }

        public virtual CASHIER CASHIER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual TICKET TICKET { get; set; }
    }
}
