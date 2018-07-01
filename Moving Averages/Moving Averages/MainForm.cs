using DataStorage;
using MovingAverageDSAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_Averages
{
	public partial class MainForm : Form
	{
		private int _activeId = -1;
		private BindingList<MovingAverageDS> _listData = new BindingList<MovingAverageDS>();
		private BindingList<double> _values = new BindingList<double>();

		private int activeId
		{
			get { return _activeId; }
			set
			{
				_activeId = value;

				if (value == -1) btnDelete.Enabled = false;
				else btnDelete.Enabled = true;
			}
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetupDatasets();
			SetupValues();
			nudValue.Maximum = decimal.MaxValue;
			nudValue.Minimum = decimal.MinValue;
			nudWindowSize.Maximum = decimal.MaxValue;
			nudWindowSize.Minimum = decimal.MinValue;
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			if (activeId == -1)
			{
				MessageBox.Show("No data selected.", "Cannot open data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string outputFileName;
			sfdSave.ShowDialog();
			outputFileName = sfdSave.FileName;
			MovingAverageDS ds = DSAccess.Operation(DSOperation.Find, new MovingAverageDS { id = activeId }, DSFindBy.Id).FirstOrDefault();

			try
			{
				File.WriteAllText(outputFileName, CalculateDSToString.OutputCalculation(ds));
			}
			catch (Exception ex)
			{
				string title = "Could not save output.";
				MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCalculateAll_Click(object sender, EventArgs e)
		{
			string outputFileName;
			sfdSave.ShowDialog();
			outputFileName = sfdSave.FileName;
			MovingAverageDS[] dataSets = DSAccess.Operation(DSOperation.GetAll);
			StringBuilder builder = new StringBuilder();

			if (dataSets.Length > 0)
			{
				foreach(MovingAverageDS ds in dataSets)
				{
					CalculateDSToString.OutputCalculation(ds, builder);
					builder.AppendLine();
				}

				try
				{
					File.WriteAllText(outputFileName, builder.ToString());
				}
				catch (Exception ex)
				{
					string title = "Could not save output.";
					MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("No data was detected in the database. Cannot calculate an average of nothing.", 
					"No Data Detected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void lbxDataSets_SelectedIndexChanged(object sender, EventArgs e)
		{
			MovingAverageDS ds = lbxDataSets.SelectedItem as MovingAverageDS;
			if (ds == null) activeId = -1;
			else activeId = ds.id;

			UpdateValues(ds == null);

			if (ds != null)
			{
				txtName.Text = ds.name;
				nudWindowSize.Value = ds.windowSize;
				lbxValues_SelectedIndexChanged(this, null);
			}
			else ClearDisplay();
		}

		private void lbxValues_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbxValues.SelectedItem == null) nudValue.Value = 0;
			else nudValue.Value = (decimal)((double)lbxValues.SelectedItem);
		}

		private void btnRemoveValue_Click(object sender, EventArgs e)
		{
			_values.RemoveAt(lbxValues.SelectedIndex);
			lbxValues.SelectedIndex = 0;
		}

		private void btnAddValue_Click(object sender, EventArgs e)
		{
			_values.Add((double)nudValue.Value);
		}

		private void btnUpdateValue_Click(object sender, EventArgs e)
		{
			_values[lbxValues.SelectedIndex] = (double)nudValue.Value;
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			ClearDisplay();
			activeId = -1;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (activeId != -1)
			{
				MovingAverageDS ds = lbxDataSets.SelectedItem as MovingAverageDS;

				if (ds != null)
				{
					DSAccess.Operation(DSOperation.Delete, ds);
					ClearDisplay();
					activeId = -1;
					UpdateDatasets();
				}
				else MessageBox.Show("No data selected...", "Delete Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			MovingAverageDS ds = new MovingAverageDS();
			ds.name = txtName.Text;
			ds.windowSize = (int)nudWindowSize.Value;
			ds.data = _values.ToArray();
			ds.id = activeId;

			if (activeId == -1)
			{
				ds = DSAccess.Operation(DSOperation.Add, ds)[0];
				SelectDSById(ds.id);
			}
			else
			{
				DSAccess.Operation(DSOperation.Modify, ds);
			}

			UpdateDatasets();
		}

		private void SetupDatasets()
		{
			lbxDataSets.DataSource = _listData;
			lbxDataSets.DisplayMember = "name";

			UpdateDatasets(true);
		}

		private void UpdateDatasets(bool isSetupOrRemove = false)
		{
			string name = txtName.Text;
			_listData.Clear();

			MovingAverageDS[] ds = DSAccess.Operation(DSOperation.GetAll);
			for (int i = 0; i < ds.Length; i++)
			{
				_listData.Add(ds[i]);
			}

			if (!isSetupOrRemove) lbxDataSets.SelectedValue = name;
			else lbxDataSets.ClearSelected();
		}

		private void SetupValues()
		{
			lbxValues.DataSource = _values;
			UpdateValues(true);
		}

		private void UpdateValues(bool isClearing = false)
		{
			if (isClearing) _values.Clear();
			else
			{
				_values.Clear();

				if ((lbxDataSets.SelectedItem as MovingAverageDS).data.Length > 0)
				{
					foreach(double d in (lbxDataSets.SelectedItem as MovingAverageDS).data)
					{
						_values.Add(d);
					}

					lbxValues.SelectedIndex = 0;
				}
			}
		}

		private void ClearDisplay()
		{
			_values.Clear();
			txtName.Clear();
			nudWindowSize.Value = 0;
			nudValue.Value = 0;
			lbxDataSets.ClearSelected();
			lbxValues.ClearSelected();
		}

		private void SelectDSById(int id)
		{
			activeId = -1;

			foreach(MovingAverageDS ds in _listData)
			{
				if (ds.id == id)
				{
					lbxDataSets.SelectedItem = ds;
					activeId = ds.id;
				}
			}

			if (activeId == -1) lbxDataSets.ClearSelected();
		}
	}
}
