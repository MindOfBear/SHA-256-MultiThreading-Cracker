using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace PasswordCracker
{
    public class Cracker
    {
        private int Max_Length;
        private string Alphabet;
        private string PasswordHash;
        private TimeSpan Start_time;

        private Label CrackedPasswordLabel;

        public Cracker(int max_Length, string alphabet, string passwordHash, TimeSpan start_time, Label crackedPasswordLabel)
        {
            Max_Length = max_Length;
            Alphabet = alphabet;
            PasswordHash = passwordHash;
            Start_time = start_time;
            CrackedPasswordLabel = crackedPasswordLabel;
        }

        public void RunMultiThread()
        {
            Parallel.For(1, Environment.ProcessorCount, i =>
            {
                GeneratePasswords(1, Max_Length);
            });
        }

        public void RunSingleThread()
        {
            GeneratePasswords(1, Max_Length);
        }

        private void GeneratePasswords(int start, int end)
        {
            for (int length = start; length <= end; length++)
            {
                StringBuilder sb = new StringBuilder(length);
                Generate(sb, length);
            }
        }

        private void Generate(StringBuilder sb, int length)
        {
            if (length == sb.Length)
            {
                string candidate = sb.ToString();
                byte[] candidateBytes = Encoding.UTF8.GetBytes(candidate);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(candidateBytes);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    if (hashString == PasswordHash)
                    {
                        TimeSpan duration = DateTime.Now.TimeOfDay - Start_time;
                        CrackedPasswordLabel.Invoke(new MethodInvoker(delegate
                        {
                            CrackedPasswordLabel.Text = $"Password cracked in {duration.TotalSeconds} seconds. Password was = {candidate}";
                        }));
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Alphabet.Length; i++)
                {
                    sb.Append(Alphabet[i]);
                    Generate(sb, length);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }
    }
}
