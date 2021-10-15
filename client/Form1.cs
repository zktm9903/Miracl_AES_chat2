using EngineIOSharp.Common.Enum;
using SocketIOSharp.Client;
using SocketIOSharp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {

        SocketIOClient client;
        string key = "";
        string myA = "";
        string myPA = "";
        string receivedPB = "";

        public Form1()
        {
            InitializeComponent();
            socketinit();
            keyExchange(1);
        }

        private void socketinit()
        {
            client = new SocketIOClient(new SocketIOClientOption(EngineIOScheme.http, "localhost", 3000));
            InitEventHandlers(client);
            client.Connect();

        }

        void InitEventHandlers(SocketIOClient client)
        {
            //연결 성공시
            client.On(SocketIOEvent.CONNECTION, () =>
            {
                Console.WriteLine("Connected!");
            });

            //연결 끊을시
            client.On(SocketIOEvent.DISCONNECT, () =>
            {
                Console.WriteLine();
                Console.WriteLine("Disconnected!");
            });

            //데이터 받기
            client.On("chat", (Data) =>
            {
                string decMsg = crypthion('D', Data[0].ToString());

                textBoxEncMsg.Text += "WHO : " + Data[0] + "\r\n";
                textBoxMsg.Text += "WHO : " + decMsg;
                textBoxMsg.Text += "\r\n";
            });

            client.On("chk", (Data) =>
            {
                string data = Data[0].ToString();

                textBoxMsgInput.ReadOnly = false;
                client.Emit("keyExchange", myPA);
            });

            client.On("keyExchange", (Data) =>
            {
                string data = Data[0].ToString();

                receivedPB = data;
                textBoxEncMsg.Text += "public key exchange...\r\n";
                textBoxEncMsg.Text += "received public key = " + receivedPB + "\r\n";
                textBoxEncMsg.Text += "---------------------------------------------------------------\r\n";

                keyExchange(2);
            });
        }

        private string crypthion(char type, string txt)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardInput = true;
            proInfo.RedirectStandardError = true;

            pro.StartInfo = proInfo;
            pro.Start();

            //CMD에 보낼 명령어를 입력
            pro.StandardInput.Write(@"cd " + Application.StartupPath + Environment.NewLine); //경로 설정

            if (type == 'E')
                pro.StandardInput.Write(@"AES.exe E " + key + " \"" + txt + "\"" + Environment.NewLine);
            else if (type == 'D')
                pro.StandardInput.Write(@"AES.exe D " + key + " \"" + txt + "\"" + Environment.NewLine);

            pro.StandardInput.Close();

            string resultValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();

            //데이터 파싱
            string[] result = resultValue.Split(new char[] { '@' });  // @를 기준으로 잘라서 배열 result 에 넣어라.

            string afterTxt = result[1];

            return afterTxt;
        }

        private void textBoxMsgInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonMsgSend_Click(sender, e);
            }
        }

        private void buttonMsgSend_Click(object sender, EventArgs e)
        {
            string Msg = textBoxMsgInput.Text;
            string encMsg = crypthion('E', Msg);
            textBoxMsgInput.Text = "";

            if (string.IsNullOrEmpty(Msg))
                return;

            //데이터 보내기
            client.Emit("chat", encMsg);

            textBoxEncMsg.Text += "ME : " + encMsg + "\r\n";
            textBoxMsg.Text += "ME : " + Msg + "\r\n";

            textBoxMsgInput.Focus();
        }

        private void keyExchange(int type)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardInput = true;
            proInfo.RedirectStandardError = true;

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@"cd " + Application.StartupPath + Environment.NewLine); //경로 설정

            if (type == 1)
                pro.StandardInput.Write(@"miracl.exe 1" + Environment.NewLine);
            else if (type == 2)
                pro.StandardInput.Write(@"miracl.exe 2 " + myA + " " + receivedPB + Environment.NewLine);

            pro.StandardInput.Close();

            string resultValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
            if (type == 1)
            {
                textBoxEncMsg.Text += "generate my secret key...\r\n";
                string[] result = resultValue.Split(new char[] { '@' });  // @를 기준으로 잘라서 배열 result 에 넣어라.

                myA = result[1];
                myPA = result[2];

                myA = myA.Substring(0, myA.Length - 2);
                myPA = myPA.Substring(0, myPA.Length - 2);

                textBoxEncMsg.Text += "my secret key = " + myA + "\r\n";
                textBoxEncMsg.Text += "my public key = " + myPA + "\r\n";
                textBoxEncMsg.Text += "---------------------------------------------------------------\r\n";
                labelMyA.Text = "my secret key : " + myA;


            }
            else if (type == 2)
            {
                textBoxEncMsg.Text += "generate symmetric key...\r\n";
                string[] result = resultValue.Split(new char[] { '@' });  // @를 기준으로 잘라서 배열 result 에 넣어라.

                key = result[1];

                key = key.Substring(0, key.Length - 2);

                textBoxEncMsg.Text += "symmetric key = " + key + "\r\n";
                labelSymmetricKey.Text = "symmetric key : " + key;
                textBoxEncMsg.Text += "---------------------------------------------------------------\r\n";

            }

        }
    }
}
