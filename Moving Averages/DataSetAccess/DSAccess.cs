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

		private static MovingAverageDS Add(MovingAverageDS data, DatasetContext db)
		{
			return db.dataSets.Add(data);
		}

		private static void Modify(MovingAverageDS data, DatasetContext db)
		{
			MovingAverageDS toChange = (from d in db.dataSets
										where (d.id == data.id)
										select d).FirstOrDefault();

			toChange.data = data.data;
			toChange.windowSize = data.windowSize;
			toChange.name = data.name;
		}

		private static void Delete(MovingAverageDS data, DatasetContext db)
		{
			MovingAverageDS ds = Find(data, DSFindBy.Id, db)[0];

			if (ds == null) { }
			else db.dataSets.Remove(ds);
		}

		private static MovingAverageDS[] GetAll(DatasetContext db)
		{
			return db.dataSets.ToArray();
		}

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
