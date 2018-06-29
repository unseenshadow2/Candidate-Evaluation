using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class MovingAverageDS
    {
		public int id { get; set; }
		public double[] data { get; set; }
		public int windowSize { get; set; }
    }
}
