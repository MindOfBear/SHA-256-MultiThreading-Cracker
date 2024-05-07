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
            string processorName = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            int threadCount = Environment.ProcessorCount;
            int coreCount = threadCount / 2;

            cpuName.Text = processorName.Substring(0, Math.Min(processorName.Length, 8)); // Display only the first 8 characters of the processor name
            cpuCores.Text = "Cores: " + coreCount.ToString();
            cpuThreads.Text = "Threads: " + threadCount.ToString();

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string password256Hash = passwordHash.Text;
            passwordLabel.Text = "-";
            timeLabel.Text = "-";

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
                    Cracker cracker = new Cracker(Max_Length, Alphabet, password256Hash, start_time, passwordLabel, timeLabel);
                    cracker.RunMultiThread();
                });
            }
            else
            {
                usedMultithreadingLabel.Text = "SingleThreading";

                Cracker cracker = new Cracker(Max_Length, Alphabet, password256Hash, start_time, passwordLabel, timeLabel);
                cracker.RunSingleThread();
            }
        }
    }
}
