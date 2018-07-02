using DataStorage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DSOperation { Add, Modify, Find, Delete, GetAll }
public enum DSFindBy { Id, Data, WindowSize, Name }

namespace MovingAverageDSAccess
{
    public static class DSAccess
    {
		/// <summary>
		/// Handle a database operation for the datasets.
		/// </summary>
		/// <param name="operation">The operation to perform</param>
		/// <param name="data">The data to be used for the operation. Ignored by GetAll operation</param>
		/// <param name="findBy">The method by which to find the data. Only used by the Find operation</param>
		/// <returns>The output of the operation</returns>
		public static MovingAverageDS[] Operation(DSOperation operation, MovingAverageDS data = null, DSFindBy findBy = DSFindBy.Id)
		{
			MovingAverageDS[] toReturn = null;

			using (DatasetContext db = new DatasetContext())
			{
				switch(operation)
				{
					case DSOperation.Add:
						toReturn = new MovingAverageDS[] { Add(data, db) };
						break;
					case DSOperation.Delete:
						Delete(data, db);
						break;
					case DSOperation.Modify:
						Modify(data, db);
						break;
					case DSOperation.Find:
						toReturn = Find(data, findBy, db);
						break;
					case DSOperation.GetAll:
						toReturn = GetAll(db);
						break;
				}

				db.SaveChanges();
			}

			return toReturn;
		}

		/// <summary>
		/// Add the given data to the database.
		/// </summary>
		/// <param name="data">The data to add to the database</param>
		/// <param name="db">The active db context to add the data to</param>
		/// <returns>The data added</returns>
		private static MovingAverageDS Add(MovingAverageDS data, DatasetContext db)
		{
			return db.dataSets.Add(data);
		}

		/// <summary>
		/// Modify the database. Uses the data's ID to determine which entry
		/// to modify in the database.
		/// </summary>
		/// <param name="data">The data to use for the modification</param>
		/// <param name="db">The active db context to modify the data from</param>
		private static void Modify(MovingAverageDS data, DatasetContext db)
		{
			MovingAverageDS toChange = (from d in db.dataSets
										where (d.id == data.id)
										select d).FirstOrDefault();

			toChange.data = data.data;
			toChange.windowSize = data.windowSize;
			toChange.name = data.name;
		}

		/// <summary>
		/// Delete a dataset from the database.
		/// </summary>
		/// <param name="data">The dataset to delete. Only reads the ID</param>
		/// <param name="db">The active db context to delete the data from</param>
		private static void Delete(MovingAverageDS data, DatasetContext db)
		{
			MovingAverageDS ds = Find(data, DSFindBy.Id, db)[0];

			if (ds == null) { }
			else db.dataSets.Remove(ds);
		}

		/// <summary>
		/// Gets all datasets within the database.
		/// </summary>
		/// <param name="db">The active database context to get all datasets from</param>
		/// <returns>All the datasets in the database</returns>
		private static MovingAverageDS[] GetAll(DatasetContext db)
		{
			return db.dataSets.ToArray();
		}

		/// <summary>
		/// Find all matching datasets within the database based on the
		/// given dataset and the DSFindBy method.
		/// </summary>
		/// <param name="data">The dataset is used as the sought value</param>
		/// <param name="findBy">The method to search by</param>
		/// <param name="db">The active database context to seach</param>
		/// <returns>The datasets that match</returns>
		private static MovingAverageDS[] Find(MovingAverageDS data, DSFindBy findBy, DatasetContext db)
		{
			MovingAverageDS[] toReturn = null;

			switch (findBy)
			{
				case DSFindBy.Data:
					toReturn = (from MovingAverageDS ds in db.dataSets
								where data.data == ds.data
								select ds).ToArray();
					break;
				case DSFindBy.Id:
					toReturn = (from MovingAverageDS ds in db.dataSets
								where data.id == ds.id
								select ds).ToArray();
					break;
				case DSFindBy.WindowSize:
					toReturn = (from MovingAverageDS ds in db.dataSets
								where data.windowSize == ds.windowSize
								select ds).ToArray();
					break;
				case DSFindBy.Name:
					toReturn = (from MovingAverageDS ds in db.dataSets
								where data.name == ds.name
								select ds).ToArray();
					break;
			}

			return toReturn;
		}
    }
}
