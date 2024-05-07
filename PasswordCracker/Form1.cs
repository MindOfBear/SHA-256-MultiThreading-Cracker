using System;
using System.Security.Cryptography.X509Certificates;

namespace PasswordCracker
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
            // definim variabilele
            string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[];./!&@";
            int Max_Len = 0;
            byte[] PasswordByte; // vector pentru stocarea bitiilor sirului sha256




            string processorName = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            int threadCount = Environment.ProcessorCount;
            int coreCount = threadCount / 2;
            cpuName.Text = processorName.Substring(0, Math.Min(processorName.Length, 8)); // afisam doar numele procesorului
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
            
            string password_LenghtText = passwordLenght.Text;

            if (int.TryParse(password_LenghtText, out int password_Lenght));


            

        }
    }
}