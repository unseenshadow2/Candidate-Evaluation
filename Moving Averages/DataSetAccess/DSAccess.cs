using DataStorage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DSOperation { Add, Modify, Find, Delete, GetAll }
public enum DSFindBy { Id, Data, WindowSize }

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
						Add(data, db);
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
			}

			return toReturn;
		}

		private static void Add(MovingAverageDS data, DatasetContext db)
		{
			db.dataSets.Add(data);
		}

		private static void Modify(MovingAverageDS data, DatasetContext db)
		{
			MovingAverageDS toChange = (from d in db.dataSets
										where (d.id == data.id)
										select d).FirstOrDefault();

			toChange.data = data.data;
			toChange.windowSize = data.windowSize;
		}

		private static void Delete(MovingAverageDS data, DatasetContext db)
		{
			db.dataSets.Remove(data);
		}

		private static MovingAverageDS[] GetAll(DatasetContext db)
		{
			return db.dataSets.ToArray();
		}

		private static MovingAverageDS[] Find(MovingAverageDS data, DSFindBy findBy, DatasetContext db)
		{
			// TODO: Setup Find operation

			switch (findBy)
			{
				case DSFindBy.Data:
					break;
				case DSFindBy.Id:
					break;
				case DSFindBy.WindowSize:
					break;
			}

			return null;
		}
    }
}
