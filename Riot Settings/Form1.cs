using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Riot_Settings
{
	public partial class Form1 : Form
	{
		public static string Filepath = "";
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.DefaultExt = ".cfg";
			openFileDialog1.ShowDialog();
			if (openFileDialog1.CheckFileExists)
			{
				Filepath = openFileDialog1.FileName;
				Settings_Editor editor = new Settings_Editor();
				editor.Show();
				//this.Close();
			}
			else
			{
				this.Close();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Text = "Select game.cfg...";
		}
	}
}
