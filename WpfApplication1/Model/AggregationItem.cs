using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.ViewModel;

namespace WpfApplication1.Model
{
	public class AggregationItem
	{
		public PLACE Place { get; set; }
		public CARRIAGE Carriage { get; set; }

		public TICKET Ticket { get; set; }

		public TRAIN Train { get; set; }

		public STATION StartStation { get; set; }

		public STATION EndStation { get; set; }

		public CLIENT Client { get; set; }

		public TICKET_SALE SoldTickset { get; set; }
	}
}
