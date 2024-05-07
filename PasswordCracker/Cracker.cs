using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    public class Cracker
    {
        private int Max_Length;
        private string Alphabet;
        private string PasswordHash;
        private TimeSpan Start_time;

        private Label CrackedPasswordLabel;
        private Label CrackedTimeLabel;

        private ConcurrentDictionary<string, TimeSpan> CrackedPasswords = new ConcurrentDictionary<string, TimeSpan>();

        public Cracker(int max_Length, string alphabet, string passwordHash, TimeSpan start_time, Label passwordLabel, Label timeLabel)
        {
            Max_Length = max_Length;
            Alphabet = alphabet;
            PasswordHash = passwordHash;
            Start_time = start_time;
            CrackedPasswordLabel = passwordLabel;
            CrackedTimeLabel = timeLabel;
        }

        public void RunMultiThread()
        {
            int numThreads = Environment.ProcessorCount;

            Parallel.For(0, numThreads, i =>
            {
                GeneratePasswords(i, numThreads);
            });

            UpdateUI();
        }

        public void RunSingleThread()
        {
            GeneratePasswords(0, 1);
            UpdateUI();
        }

        private void GeneratePasswords(int start, int step)
        {
            StringBuilder sb = new StringBuilder(Max_Length);
            Generate(sb, start, step);
        }

        private void Generate(StringBuilder sb, int start, int step)
        {
            if (sb.Length == Max_Length)
            {
                byte[] candidateBytes = Encoding.UTF8.GetBytes(sb.ToString());
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(candidateBytes);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    if (hashString == PasswordHash)
                    {
                        TimeSpan duration = DateTime.Now.TimeOfDay - Start_time;
                        CrackedPasswords.TryAdd(sb.ToString(), duration);
                    }
                }
            }
            else
            {
                for (int i = start; i < Alphabet.Length; i += step)
                {
                    sb.Append(Alphabet[i]);
                    Generate(sb, 0, 1); // Recursive call with step = 1 to generate next character
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }

        private void UpdateUI()
        {
            // Update UI with cracked password and time
            foreach (var entry in CrackedPasswords)
            {
                CrackedPasswordLabel.Invoke(new MethodInvoker(delegate
                {
                    CrackedPasswordLabel.Text = $"{entry.Key}";
                }));

                CrackedTimeLabel.Invoke(new MethodInvoker(delegate
                {
                    CrackedTimeLabel.Text = $"{entry.Value.TotalSeconds}s";
                }));
            }
        }
    }
}
