using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculator
{
	public partial class Form1 : Form
	{
		Button btn;

		public Form1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, EventArgs e)
		{
			btn = (Button)sender; // sender가 object형식이니 button형식으로 형변환
			// 여러개의 컨트롤을 하나로 몰아줄때 그때 sender사용
			lblCal.Text += (btn.Text);
		}

		private void button_Click_Operator(object sender, EventArgs e)
		{

			btn = (Button)sender;
			lblCal.Text += (btn.Text);

		}

		private void button_Click_Equal(object sender, EventArgs e)
		{
			if (btn.Text == "+")
			{

			}
		}

		private void button_Click_Clear(object sender, EventArgs e)
		{
			lblCal.Text = null;
		}
	}
}
