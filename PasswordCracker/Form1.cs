using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    public partial class mainWindow : Form
    {
        private readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789[];./!&@"; // definirea alfabetului folosit
        private int Max_Length = 0;
        private byte[] PasswordByte; // vector pentru stocarea bitiilor sirului sha256

        public mainWindow()
        {
            InitializeComponent();
            string processorName = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"); // identificam arhitectura procesorului
            int threadCount = Environment.ProcessorCount; // identificam numar-ul de core-uri
            int coreCount = threadCount / 2; // numarul de thread-uri

            cpuName.Text = processorName.Substring(0, Math.Min(processorName.Length, 8)); // afisam detaliile despre procesor
            cpuCores.Text = "Cores: " + coreCount.ToString();
            cpuThreads.Text = "Threads: " + threadCount.ToString();

        }

        private void startBtn_Click(object sender, EventArgs e) // metoda care este triggeruita la apasarea butonului Start Cracking
        {
            string password256Hash = passwordHash.Text; // preluam hash-ul din interfata
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

                int totalThreads = Environment.ProcessorCount;

                Cracker cracker = new Cracker(password256Hash, Max_Length, totalThreads);
                cracker.parallelBruteForceCrack(passwordLabel, start_time, timeLabel);
            }
            else
            {
                usedMultithreadingLabel.Text = "SingleThread";
                int totalThreads = 1;
                Cracker cracker = new Cracker(password256Hash, Max_Length, totalThreads);
                cracker.parallelBruteForceCrack(passwordLabel, start_time, timeLabel);
            }
        }
    }
}
