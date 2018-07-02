using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
	/// <summary>
	/// The Entity Framework code first data storage class
	/// for the datasets used for calculating the moving
	/// averages.
	/// </summary>
    public class MovingAverageDS
    {
		public int id { get; set; }
		public string name { get; set; }
		public int windowSize { get; set; }
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string InternalData { get; set; }

		[NotMapped]
		public double[] data
		{
			get
			{
				if (!InternalData.Contains(";")) return new double[0];

				return Array.ConvertAll(InternalData.Split(';'), Double.Parse);
			}
			set
			{
				double[] _data = value;
				InternalData = String.Join(";", _data.Select(p => p.ToString()).ToArray());
			}
		}
	}
}
