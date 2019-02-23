using System;
using System.IO;

namespace CopyBinaryF
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathIn = @"..\..\..\..\..\04. Streams-Exercise\copyMe.png";
            string pathOut = @"..\..\..\..\..\04. Streams-Exercise\copyMe-copy.png";
            using (FileStream fileStream = new FileStream(pathOut, FileMode.OpenOrCreate))
            {
                FileStream fs = new FileStream(pathIn, FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fs.Length);
                byte[] bytes = new byte[1024*1024];
                int bytesRead;
                while ((bytesRead = fs.Read(bytes, 0, 1024*1024)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }
            }
        }
    }
}
