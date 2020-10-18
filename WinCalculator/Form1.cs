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
		
		string saveNum;			//입력한 숫자와 연산된 결과를 저장하기위한 전역변수
		int leftValue = 0;		//피연산자의 왼쪽항을 담기위한 변수
		int rightValue = 0;		//오른쪽
		char oper;				//연산자를 눌렀을때 누른 연산자를 담기위한 변수
		int result = 0;			//연산한 결과를 담기위한 변수
		bool newButton = true;  //새로 눌렀을때를 위한 bool타입 변수
		

		public Form1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, EventArgs e) 
		{
			Button btn = (Button)sender; // sender가 object형식이니 button형식으로 형변환
								  // 여러개의 컨트롤을 하나로 몰아줄때 그때 sender사용
			if (lblCal.Text == null || newButton == true)	// 처음 아무것도 입력하지 않았을때 
			{
				lblCal.Text = (btn.Text); //라벨에 입력한값을 출력해주고
				saveNum = btn.Text;		  //변수에 입력한값을 담아준다
				newButton = false;		  //그러고 새로눌렀으니 false
			}
			else	// 입력한 값이 있을때 이어쓰기 위해
			{
				lblCal.Text += (btn.Text); //newButton값이 false이기 때문에 이어서 써준다
				saveNum += btn.Text;
			}
		}

		private void button_Click_Operator(object sender, EventArgs e) //연산자 버튼을 눌렀을때
		{

			Button btn = (Button)sender;
			newButton = false; //여기에 false를준 이유는 연산자를 눌렀을때 이전의 결과값에 이어서 연산하기 위해 
			saveNum += btn.Text;
			oper = btn.Text[0]; // 누른 연산자를 담아준다
			lblCal.Text += btn.Text;

		}

		private void button_Click_Equal(object sender, EventArgs e) // =버튼을 눌렀을때 연산
		{
			
			if (oper == '+')
			{
				Calculation('+');
			}
			else if (oper == '-')
			{
				Calculation('-');
			}
			else if (oper == '*')
			{
				Calculation('*');
			}
			else
			{
				Calculation('/');
			}
			newButton = true; 
			//여기에 true를 준이유는 연산자를 누르지 않고 바로 숫자버튼을 누르면 처음눌렀을때와 같이 초기로 돌려주기위해
		}

		private void Calculation(char oper) //saveNum에 저장한 값을 연산자기준으로 좌우로 나누어 연산을 해주는 매서드
		{
			leftValue = int.Parse(saveNum.Substring(0, saveNum.LastIndexOf(oper)));
			rightValue = int.Parse(saveNum.Substring(saveNum.LastIndexOf(oper) + 1));
			result = Math(leftValue, rightValue, oper);
			lblCal.Text = result.ToString();
			saveNum = result.ToString();
		}


		private void button_Click_Clear(object sender, EventArgs e) //Clear버튼을 눌렀을시 초기화
		{
			lblCal.Text = null;
			saveNum = null;
		}

		int Math(int a, int b, char oper) //실제 연산을 위한 메서드 생성
		{
			switch (oper)
			{
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
				case '/':
					return a / b;
			}
			return 0;
		}
	}
}
