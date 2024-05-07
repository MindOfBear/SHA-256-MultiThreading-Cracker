using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCracker
{

    class Cracker
    {
        string hashedPassword;
        int passwordLength;
        int numThreads;

        public Cracker(string hashedPassword, int passwordLength, int numThreads)
        {
            this.hashedPassword = hashedPassword;
            this.passwordLength = passwordLength;
            this.numThreads = numThreads;
        }

        public void parallelBruteForceCrack(Label passwordLabel, TimeSpan start_time, Label timeLabel) // metoda pentru spargerea hash-ului 
        {
            char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            List<Task> tasks = new List<Task>();
            object lockObject = new object();
            int attempts = 0;
            long totalAttempts = (long)Math.Pow(characters.Length, this.passwordLength);
            for (int i = 0; i < this.numThreads; i++)
            {
                int threadIndex = i; // contor thread
                string solution;
                tasks.Add(Task.Run(() =>
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        for (int j = threadIndex; j < totalAttempts; j += this.numThreads)
                        {
                            string permutation = GetPermutation(characters, this.passwordLength, j); // generam folosind permutari un sir de caractere de dimensiunea parolei
                            byte[] bytes = Encoding.UTF8.GetBytes(permutation); // encodam sirul de caractere generat
                            byte[] hash = sha256.ComputeHash(bytes); // generam sha-ul 
                            string hashedAttempt = BitConverter.ToString(hash).Replace("-", "").ToLower(); // convertim in string sha-ul pentru al compara cu hash-ul primit din interfata

                            lock (lockObject) // blocam executia pana cand thread-ul actual verifica daca a gasit solutie
                            {
                                attempts++;
                                if (hashedAttempt == this.hashedPassword) // verificam daca s a gasit solutie
                                {
                                    if (passwordLabel.InvokeRequired)
                                    {
                                        passwordLabel.BeginInvoke((MethodInvoker)delegate () { passwordLabel.Text = permutation; });
                                    }
                                    TimeSpan duration = DateTime.Now.TimeOfDay - start_time;
                                    string formatedDuration = duration.TotalSeconds.ToString();
                                    if (timeLabel.InvokeRequired)
                                    {
                                        timeLabel.BeginInvoke((MethodInvoker)delegate () {
                                            timeLabel.Text = formatedDuration;
                                        });
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray()); // asteptam pana cand toate threaduriile termina executia
        }

        static string GetPermutation(char[] characters, int length, long index) // metoda pentru a genera string-ul folosind alfabetul dat
        {
            StringBuilder permutation = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int charIndex = (int)(index % characters.Length);
                permutation.Append(characters[charIndex]);
                index /= characters.Length;
            }

            return permutation.ToString();
        }
    }
}