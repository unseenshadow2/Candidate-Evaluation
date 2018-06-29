using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Averages
{
    public static class MovingAverage
    {
		/// <summary>
		/// Determine the cumulative averages of each element up to the windowSize,
		/// after which the average becomes a simple moving average.
		/// </summary>
		/// <param name="windowSize">The window size for the Simple Moving Average.</param>
		/// <param name="data">The data that the averages will be calculated from.</param>
		/// <returns>An array of the averages.</returns>
		public static double[] GetMovingAverage(int windowSize, double[] data)
		{
			double[] toReturn = new double[data.Length];

			for (int i = 0; i < data.Length; i++)
			{
				if (i == 0)
				{
					toReturn[i] = Averages.Average(data, 0, i);
				}
				else if (i < windowSize)
				{
					toReturn[i] = Averages.Average(data, toReturn[i - 1], i);
				}
				else
				{
					toReturn[i] = Averages.Average(data, 0, i, windowSize);
				}
			}

			return toReturn;
		}
    }
}
