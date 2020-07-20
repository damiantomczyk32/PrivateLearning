using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5Learn
{
    class Program
    {
        public static string CalculateMD5ForFilename(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-","").ToUpperInvariant();
                }
            }
        }

        public static string CalculateMD5ForText(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] bytes = provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for(int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@"C:\Users\lenovo\source\repos\TestFiles\TestExcel.xlsx");
            Console.WriteLine(CalculateMD5ForFilename(@"C:\Users\lenovo\source\repos\TestFiles\TestExcel.xlsx"));

            Console.WriteLine("Damian");
            Console.WriteLine(CalculateMD5ForText("Damian"));
            Console.ReadKey();
        }
    }
}
