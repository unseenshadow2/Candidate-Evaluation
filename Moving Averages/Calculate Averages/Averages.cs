using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Averages
{
	/// <summary>
	/// Handles the actual calculating of the averages.
	/// </summary>
	public static class Averages
	{
		/// <summary>
		/// Calculate the average of the given data. If no windowSize is provided, the
		/// average is cumulative using the currentAverage. If windowSize is a value other
		/// than 0, then the average is calculated based of off the past windowSize values.
		/// </summary>
		/// <param name="data">The array of data to calculate the average from</param>
		/// <param name="currentAverage">The current average before the given data. Used for cumulative averages</param>
		/// <param name="position">The position of the data we are calculating</param>
		/// <param name="windowSize">The window size of the moving average. If a value other than 0, a moving average will be calculated</param>
		/// <returns>The average of the data given</returns>
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

		/// <summary>
		/// Calculates a simple moving average.
		/// </summary>
		/// <param name="data">The array of data to calculate the average from</param>
		/// <param name="position">The position to calculate the simple moving average from within the data</param>
		/// <param name="windowSize">The window size for the moving average</param>
		/// <returns>The simple moving average</returns>
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
