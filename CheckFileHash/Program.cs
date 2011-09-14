using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace CheckFileHash
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("You need to specify a filename as a single argument");
            }
            else
            {
                string file = args[0];
                if (File.Exists(file) == false)
                {
                    Console.WriteLine("Argument is not a valid filename");
                }
                else
                {
                    FileStream fs = new FileStream(@file, FileMode.Open);
                    using (SHA1Managed sha1 = new SHA1Managed())
                    {
                        byte[] hash = sha1.ComputeHash(fs);
                        StringBuilder sb = new StringBuilder(hash.Length);
                        foreach (byte b in hash)
                        {
                            sb.AppendFormat("{0:X2}", b);
                        }
                        Console.WriteLine(sb.ToString());
                    }
                }
            }
        }
    }
}
