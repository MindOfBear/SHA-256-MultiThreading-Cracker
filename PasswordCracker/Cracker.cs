using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    class Cracker
    {
        private readonly string hashedPassword;
        private readonly int passwordLength;
        private readonly int numThreads;
        private readonly char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789[];./!&@".ToCharArray();
        private readonly int charSetLength;

        public Cracker(string hashedPassword, int passwordLength, int numThreads)
        {
            this.hashedPassword = hashedPassword;
            this.passwordLength = passwordLength;
            this.numThreads = numThreads;
            this.charSetLength = characters.Length;
        }

        public async Task BruteForceCrackAsync(Label passwordLabel, TimeSpan startTime, Label timeLabel)
        {
            long totalAttempts = (long)Math.Pow(charSetLength, passwordLength);
            bool found = false;

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            Task[] tasks = new Task[numThreads];
            long chunkSize = totalAttempts / numThreads;

            for (int i = 0; i < numThreads; i++)
            {
                long start = i * chunkSize;
                long end = (i == numThreads - 1) ? totalAttempts : start + chunkSize;

                tasks[i] = Task.Run(() =>
                {
                    BruteForceChunk(start, end, ref found, cts, passwordLabel, timeLabel, startTime);
                }, token);
            }

            await Task.WhenAll(tasks);
        }

        private void BruteForceChunk(long start, long end, ref bool found, CancellationTokenSource cts, Label passwordLabel, Label timeLabel, TimeSpan startTime)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                for (long i = start; i < end && !found; i++)
                {
                    string permutation = GeneratePassword(i);
                    string hashedAttempt = HashPassword(permutation, sha256);

                    if (hashedAttempt == hashedPassword)
                    {
                        found = true;
                        cts.Cancel();
                        UpdateUI(passwordLabel, timeLabel, permutation, startTime);
                        return;
                    }
                }
            }
        }

        private string HashPassword(string password, SHA256 sha256)
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private string GeneratePassword(long index)
        {
            char[] result = new char[passwordLength];
            for (int i = passwordLength - 1; i >= 0; i--)
            {
                result[i] = characters[index % charSetLength];
                index /= charSetLength;
            }
            return new string(result);
        }

        private void UpdateUI(Label passwordLabel, Label timeLabel, string password, TimeSpan startTime)
        {
            if (passwordLabel.InvokeRequired)
            {
                passwordLabel.BeginInvoke((MethodInvoker)(() =>
                {
                    passwordLabel.Text = password;
                    TimeSpan duration = DateTime.Now.TimeOfDay - startTime;
                    timeLabel.Text = $"{duration.TotalSeconds:F2} seconds";
                }));
            }
        }
    }
}
