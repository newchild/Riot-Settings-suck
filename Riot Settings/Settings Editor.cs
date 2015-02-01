using System;	
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using IniParser;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser.Model;

namespace Riot_Settings
{
	public partial class Settings_Editor : Form
	{
		Dictionary<string, string[]> help = new Dictionary<string, string[]>();
		Dictionary<string, string> help2 = new Dictionary<string, string>();
		FileIniDataParser parser = new FileIniDataParser();
		IniData data;
		public Settings_Editor()
		{
			InitializeComponent();
		}

		private void Settings_Editor_Load(object sender, EventArgs e)
		{
			data = parser.ReadFile(Form1.Filepath);
			foreach (var Option in data.Sections)
			{
				comboBox1.Items.Add(Option.SectionName);
				
			}
		
			
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.Text = data[comboBox1.SelectedItem.ToString()][comboBox2.SelectedItem.ToString()];
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox2.Items.Clear();
			foreach (var Key in data.Sections)
			{
				if (Key.SectionName == comboBox1.SelectedItem.ToString())
				{
					foreach (var ActualKey in Key.Keys)
					{
						comboBox2.Items.Add(ActualKey.KeyName);
					}
				}
			}

			
			

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			data[comboBox1.SelectedItem.ToString()][comboBox2.SelectedItem.ToString()] = textBox1.Text;
			parser.WriteFile(Form1.Filepath, data);
		}

		private void Presets_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			data = parser.ReadFile(openFileDialog1.FileName);
			parser.WriteFile(Form1.Filepath, data);
			MessageBox.Show("Preset loaded");
		}
	}
}
