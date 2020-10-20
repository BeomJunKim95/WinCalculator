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

		string saveNum;         //입력한 숫자와 연산된 결과를 저장하기위한 전역변수
		int leftValue = 0;      //피연산자의 왼쪽항을 담기위한 변수
		int rightValue = 0;     //오른쪽
		char oper;              //연산자를 눌렀을때 누른 연산자를 담기위한 변수
		int result = 0;         //연산한 결과를 담기위한 변수
		bool newButton = true;  //새로 눌렀을때를 위한 bool타입 변수

		string preOperator = "+";


		public Form1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, EventArgs e)
		{
			#region 내코드
			//Button btn = (Button)sender; // sender가 object형식이니 button형식으로 형변환
			//					  // 여러개의 컨트롤을 하나로 몰아줄때 그때 sender사용
			//if (lblCal.Text == null || newButton == true)	// 처음 아무것도 입력하지 않았을때 
			//{
			//	lblCal.Text = (btn.Text); //라벨에 입력한값을 출력해주고
			//	saveNum = btn.Text;		  //변수에 입력한값을 담아준다
			//	newButton = false;		  //그러고 새로눌렀으니 false
			//}
			//else	// 입력한 값이 있을때 이어쓰기 위해
			//{
			//	lblCal.Text += (btn.Text); //newButton값이 false이기 때문에 이어서 써준다
			//	saveNum += btn.Text;
			//}
			#endregion

			#region Class

			Button btn = (Button)sender;

			rightValue = int.Parse(rightValue.ToString() + btn.Text);

			lblCal.Text = rightValue.ToString();

			#endregion
		}

		private void button_Click_Operator(object sender, EventArgs e) //연산자 버튼을 눌렀을때
		{
			#region 내코드
			//Button btn = (Button)sender;
			//newButton = false; //여기에 false를준 이유는 연산자를 눌렀을때 이전의 결과값에 이어서 연산하기 위해 
			//saveNum += btn.Text;
			//oper = btn.Text[0]; // 누른 연산자를 담아준다
			//lblCal.Text += btn.Text;
			#endregion

			#region Class
			//이전 연산자로 계산
			switch(preOperator)
			{
				case "+":
					result = leftValue + rightValue;
					break;
				case "-":
					result = leftValue - rightValue;
					break;
				case "*":
					result = leftValue * rightValue;
					break;
				case "/":
					if(rightValue == 0)
					{
						MessageBox.Show("0으로 나눌 수 없습니다.");
						return;
					}
					result = leftValue / rightValue;
					break;
			}

			//이번 연산자를 다음번을 위해서 저장
			Button b1 = (Button)sender;
			preOperator = b1.Text;
			lblCal.Text = result.ToString();
			leftValue = result;
			rightValue = 0;

			#endregion

		}

		private void button_Click_Clear(object sender, EventArgs e) //Clear버튼을 눌렀을시 초기화
		{
			#region 내코드
			//lblCal.Text = null;
			//saveNum = null;
			#endregion 

			lblCal.Text = "";
			leftValue = rightValue = result = 0;
			preOperator = "+";
		}

		private void button_Click_Equal(object sender, EventArgs e) // =버튼을 눌렀을때 연산
		{
			#region 내코드
			//if (oper == '+')
			//{
			//	Calculation('+');
			//}
			//else if (oper == '-')
			//{
			//	Calculation('-');
			//}
			//else if (oper == '*')
			//{
			//	Calculation('*');
			//}
			//else
			//{
			//	Calculation('/');
			//}
			//newButton = true;
			////여기에 true를 준이유는 연산자를 누르지 않고 바로 숫자버튼을 누르면 처음눌렀을때와 같이 초기로 돌려주기위해
			#endregion
		}

		#region 내코드 (메서드)
		//private void Calculation(char oper) //saveNum에 저장한 값을 연산자기준으로 좌우로 나누어 연산을 해주는 매서드
		//{
		//	leftValue = int.Parse(saveNum.Substring(0, saveNum.LastIndexOf(oper)));
		//	rightValue = int.Parse(saveNum.Substring(saveNum.LastIndexOf(oper) + 1));
		//	result = Math(leftValue, rightValue, oper);
		//	lblCal.Text = result.ToString();
		//	saveNum = result.ToString();
		//}

		//int Math(int a, int b, char oper) //실제 연산을 위한 메서드 생성
		//{
		//	switch (oper)
		//	{
		//		case '+':
		//			return a + b;
		//		case '-':
		//			return a - b;
		//		case '*':
		//			return a * b;
		//		case '/':
		//			return a / b;
		//	}
		//	return 0;
		//}
		#endregion

		//private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		//{
		//	e.KeyChar
		//}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
			{
				int temp = (int)e.KeyCode -96; 
				// -96을 한 이유는 keypad의 0의값이 96이고 1씩 늘어나기 때문에 인트값에 0~9만 담고싶어 96을 빼주면 올바른 값이 담김
				rightValue = int.Parse(rightValue.ToString() + temp.ToString());

				lblCal.Text = rightValue.ToString();
			}
			else
			{
				if (e.KeyCode == Keys.Add)
					button16.PerformClick(); //+버튼이 눌리면 윈폼의 +버튼을 클릭한것 처럼해라
				else if (e.KeyCode == Keys.Subtract)
					button12.PerformClick();
				else if (e.KeyCode == Keys.Multiply)
					button11.PerformClick();
				else if (e.KeyCode == Keys.Divide)
					button10.PerformClick();

			}
		}
	}
}
