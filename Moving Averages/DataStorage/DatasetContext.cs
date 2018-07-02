using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
	/// <summary>
	/// The database context for interacting with the datasets
	/// that are stored in the SQLite file.
	/// </summary>
	public class DatasetContext : DbContext
	{
		public DatasetContext() : base("name=default")
        {
		}

		/// <summary>
		/// Setup the context in code first Entity Framework.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			SqliteDropCreateDatabaseWhenModelChanges<DatasetContext> sqliteConnectionInitializer = new SqliteDropCreateDatabaseWhenModelChanges<DatasetContext>(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}

		public DbSet<MovingAverageDS> dataSets { get; set; }
	}
}
