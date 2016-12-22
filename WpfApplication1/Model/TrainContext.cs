namespace TrainTicketsApp.Model
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class TrainContext : DbContext
	{
		public TrainContext()
			: base("name=TrainContext3")
		{
		}

		public virtual DbSet<CARRIAGE> CARRIAGEs { get; set; }
		public virtual DbSet<CASHIER> CASHIERs { get; set; }
		public virtual DbSet<CLIENT> CLIENTs { get; set; }
		public virtual DbSet<PLACE> PLACEs { get; set; }
		public virtual DbSet<STATION> STATIONs { get; set; }
		public virtual DbSet<TICKET> TICKETs { get; set; }
		public virtual DbSet<TICKET_SALE> TICKET_SALE { get; set; }
		public virtual DbSet<TRAIN> TRAINS { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CARRIAGE>()
				.Property(e => e.TYPE)
				.IsFixedLength();

			modelBuilder.Entity<CARRIAGE>()
				.HasMany(e => e.PLACEs)
				.WithOptional(e => e.CARRIAGE)
				.HasForeignKey(e => e.ID_CARRIAGE);

			modelBuilder.Entity<CASHIER>()
				.Property(e => e.LOGIN)
				.IsFixedLength();

			modelBuilder.Entity<CASHIER>()
				.Property(e => e.PASSWORD)
				.IsFixedLength();

			modelBuilder.Entity<CASHIER>()
				.HasMany(e => e.TICKET_SALE)
				.WithRequired(e => e.CASHIER)
				.HasForeignKey(e => e.ID_CASHIER)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CLIENT>()
				.Property(e => e.PASSPORT_NUMBER)
				.IsFixedLength();

			modelBuilder.Entity<CLIENT>()
				.HasMany(e => e.TICKET_SALE)
				.WithRequired(e => e.CLIENT)
				.HasForeignKey(e => e.ID_CLIENT)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PLACE>()
				.Property(e => e.TIER)
				.IsFixedLength();

			modelBuilder.Entity<PLACE>()
				.HasMany(e => e.TICKETs)
				.WithOptional(e => e.PLACE)
				.HasForeignKey(e => e.ID_PLACE);

			modelBuilder.Entity<STATION>()
				.HasMany(e => e.TRAINS)
				.WithRequired(e => e.STATION)
				.HasForeignKey(e => e.ID_END_STATION)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<STATION>()
				.HasMany(e => e.TRAINS1)
				.WithRequired(e => e.STATION1)
				.HasForeignKey(e => e.ID_START_STATION)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TICKET>()
				.Property(e => e.PRICE)
				.HasPrecision(7, 2);

			modelBuilder.Entity<TICKET>()
				.HasMany(e => e.TICKET_SALE)
				.WithRequired(e => e.TICKET)
				.HasForeignKey(e => e.ID_TICKET)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TRAIN>()
				.HasMany(e => e.CARRIAGEs)
				.WithOptional(e => e.TRAIN)
				.HasForeignKey(e => e.ID_TRAIN);

			modelBuilder.Entity<TRAIN>()
				.HasMany(e => e.TICKETs)
				.WithOptional(e => e.TRAIN)
				.HasForeignKey(e => e.ID_TRAIN);
		}
	}
}
