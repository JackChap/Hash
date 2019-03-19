using System;
using System.Text;  
using System.Security.Cryptography; 

namespace hashTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter something: ");
            string originalData = Console.ReadLine();
            Console.WriteLine("Please enter something else: ");
            string newData = Console.ReadLine();
            // Console.Clear();

            Console.WriteLine("Original data  : {0}", originalData);
            Console.WriteLine("New data        : {0}", newData);

            string originalHashedData = ComputeSha256Hash(originalData);
            string newHashedData = ComputeSha256Hash(newData);
            Console.WriteLine("Original hash data : {0}", originalHashedData);
            Console.WriteLine("New hash data : {0}", newHashedData);

            if(originalHashedData == newHashedData)
                Console.WriteLine("Hash matches.");
            else
                Console.WriteLine("Hash doesn't match.");

            Console.ReadLine();
        }

        static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
                
                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {  
                    builder.Append(bytes[i].ToString("x2"));
                }  
                return builder.ToString();
            }  
        }  
    }
}
