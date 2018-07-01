using Calculate_Averages;
using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Averages
{
	public static class CalculateDSToString
	{
		public static string OutputCalculation(MovingAverageDS ds)
		{
			StringBuilder toReturn = new StringBuilder();

			OutputCalculation(ds, toReturn);

			return toReturn.ToString();
		}

		public static void OutputCalculation(MovingAverageDS ds, StringBuilder builder)
		{
			double[] output = MovingAverage.GetMovingAverage(ds.windowSize, ds.data);

			builder.Append("Name: "); builder.AppendLine(ds.name);
			builder.Append("Window Size: "); builder.AppendLine(ds.windowSize.ToString());

			builder.Append("Data: "); ArrayToString(ds.data, builder); builder.AppendLine();
			builder.Append("Averages: "); ArrayToString(output, builder); builder.AppendLine();
		}

		private static string ArrayToString<T>(T[] data)
		{
			StringBuilder toReturn = new StringBuilder();

			ArrayToString(data, toReturn);

			return toReturn.ToString();
		}

		private static void ArrayToString<T>(T[] data, StringBuilder builder)
		{
			if (data.Length > 0)
			{
				builder.Append("[");

				foreach (T t in data)
				{
					builder.AppendFormat("{0:0.##}", t); builder.Append(", ");
				}

				builder.Remove(builder.Length - 2, 2);
				builder.Append("]");
			}
		}
	}
}
