using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    public partial class mainWindow : Form
    {
        private readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789[];./!&@"; // Setul de caractere utilizat
        private int Max_Length = 0;

        public mainWindow()
        {
            InitializeComponent();

            // informatii hardware
            string processorName = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            int threadCount = Environment.ProcessorCount;

            cpuName.Text = processorName.Substring(0, Math.Min(processorName.Length, 8));
            cpuCores.Text = $"Cores: {threadCount / 2}";
            cpuThreads.Text = $"Threads: {threadCount}";
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            string password256Hash = passwordHash.Text;
            passwordLabel.Text = "-";
            timeLabel.Text = "-";

            if (int.TryParse(passwordLenght.Text, out int password_Length))
            {
                Max_Length = password_Length;
            }
            else
            {
                MessageBox.Show("Invalid password lenght");
                return;
            }

            TimeSpan startTime = DateTime.Now.TimeOfDay;

            bool useMultithreading = multiThreading.Checked;
            usedMultithreadingLabel.Text = useMultithreading ? "MultiThreading" : "SingleThread";

            int totalThreads = useMultithreading ? Environment.ProcessorCount : 1;

            Cracker cracker = new Cracker(password256Hash, Max_Length, totalThreads);
            await cracker.BruteForceCrackAsync(passwordLabel, startTime, timeLabel);
        }
    }
}
