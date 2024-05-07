using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    public partial class mainWindow : Form
    {
        private readonly string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[];./!&@";
        private int Max_Length = 0;
        private byte[] PasswordByte; // vector pentru stocarea bitiilor sirului sha256

        public mainWindow()
        {
            InitializeComponent();

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string password256Hash = passwordHash.Text;

            if (int.TryParse(passwordLenght.Text, out int password_Length))
            {
                Max_Length = password_Length;
            }

            TimeSpan start_time = DateTime.Now.TimeOfDay;

            if (multiThreading.Checked)
            {
                usedMultithreadingLabel.Text = "MultiThreading";

                Task.Run(() =>
                {
                    Cracker cracker = new Cracker(Max_Length, Alphabet, password256Hash, start_time, cpuThreads);
                    cracker.RunMultiThread();
                });
            }
            else
            {
                usedMultithreadingLabel.Text = "SingleThreading";

                Cracker cracker = new Cracker(Max_Length, Alphabet, password256Hash, start_time, cpuThreads);
                cracker.RunSingleThread();
            }
        }
    }
}
