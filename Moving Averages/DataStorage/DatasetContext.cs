using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
	public class DatasetContext : DbContext
	{
		public DatasetContext() : base("name=default")
        {
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			SqliteDropCreateDatabaseWhenModelChanges<DatasetContext> sqliteConnectionInitializer = new SqliteDropCreateDatabaseWhenModelChanges<DatasetContext>(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}

		public DbSet<MovingAverageDS> dataSets { get; set; }
	}
}
