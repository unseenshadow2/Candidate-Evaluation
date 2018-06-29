using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Averages
{
	public static class Averages
	{
		public static double Average(double[] data, double currentAverage, int position, int windowSize = 0)
		{
			if (windowSize == 0)
			{
				return Cumulative(data[position], currentAverage, position);
			}
			else
			{
				return SimpleMoving(data, position, windowSize);
			}
		}

		private static double SimpleMoving(double[] data, int position, int windowSize)
		{
			double toReturn = 0;
			int offset = 1 + position - windowSize;

			for (int i = 0; i < windowSize; i++)
			{
				toReturn += data[i + offset];
			}

			return toReturn / windowSize;
		}

		/// <summary>
		/// Calculate the cumulative average.
		/// </summary>
		/// <param name="data">The new data entry to add to the cumulative average.</param>
		/// <param name="currentAverage">The average before the new entry.</param>
		/// <param name="position">The position of the new entry within the dataset.</param>
		/// <returns>The new cumulative average.</returns>
		private static double Cumulative(double data, double currentAverage, int position)
		{
			return currentAverage + ((data - currentAverage) / (position + 1));
		}
	}
}
