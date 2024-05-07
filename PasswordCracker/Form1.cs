using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    public partial class mainWindow : Form
    {
        private string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[];./!&@";
        private int Max_Len = 0;
        private byte[] PasswordByte; // vector pentru stocarea bitiilor sirului sha256

        private string processorName;
        private int threadCount;
        private int coreCount;

        public mainWindow()
        {
            InitializeComponent();

            
            processorName = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            threadCount = Environment.ProcessorCount;
            coreCount = threadCount / 2;

            cpuName.Text = processorName.Substring(0, Math.Min(processorName.Length, 8)); // Display only the first 8 characters of the processor name
            cpuCores.Text = "Cores: " + coreCount.ToString();
            cpuThreads.Text = "Threads: " + threadCount.ToString();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string password256Hash = passwordHash.Text;
            char[] password = password256Hash.ToCharArray();
            string binaryString = "";

            foreach (char c in password)
            {
                int asciiValue = (int)c;
                string binaryChar = Convert.ToString(asciiValue, 2);
                binaryString += binaryChar;
            }

            if (int.TryParse(passwordLenght.Text, out int password_Length))
            {
                Max_Len = password_Length;
            }

            TimeSpan start_time = DateTime.Now.TimeOfDay;

            if (multiThreading.Checked)
            {
                usedMultithreadingLabel.Text = "Multi Threading";

               
                Task.Run(() =>
                {
                    Cracker cracker = new Cracker(Max_Len, Alphabet, start_time);
                    cracker.RunMultiThread();
                });
            }
            else
            {
                usedMultithreadingLabel.Text = "Single Threading";

                
                Cracker cracker = new Cracker(Max_Len, Alphabet, start_time);
                cracker.RunSingleThread();
            }
        }
    }

    public class Cracker
    {
        private int Max_Len;
        private string Alphabet;
        private TimeSpan Start_time;

        public Cracker(int max_Len, string alphabet, TimeSpan start_time)
        {
            Max_Len = max_Len;
            Alphabet = alphabet;
            Start_time = start_time;
        }

        public void RunMultiThread()
        {
           
            
         
        }

        public void RunSingleThread()
        {
           

        }
    }
}