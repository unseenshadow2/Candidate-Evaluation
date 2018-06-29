using Calculate_Averages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOut
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] data = { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
			int windowSize = 5;

			double[] output = MovingAverage.GetMovingAverage(windowSize, data);

			Console.WriteLine("{0,-10} {1,4} {2,10}", "Position", "Data", "Output");

			// Display output
			for (int i = 0; i < data.Length; i++)
			{
				Console.WriteLine("{0,-10} {1,4} {2,10:0.##}", i, data[i], output[i]);
			}

			Console.In.Read();
		}
	}
}