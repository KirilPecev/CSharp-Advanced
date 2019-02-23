using System;
using System.Collections.Generic;
using System.IO;

namespace Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"..\..\..\..\..\04. Streams-Exercise\sliceMe.mp4";
            string destinationDirectory = @"..\..\..\..\..\04. Streams-Exercise";
            List<string> paths = new List<string>();
            Slice(sourceFile, destinationDirectory, 5, paths);
            Assemble(paths, destinationDirectory + "Assembled.mp4");
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts, List<string> paths)
        {
            string extension = Path.GetExtension(sourceFile);
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = reader.Length / parts + 1;
                for (int i = 1; i <= parts; i++)
                {
                    string outputFile = Path.Combine(destinationDirectory, $"Part {i}{extension}");
                    paths.Add(outputFile);
                    using (FileStream writer = new FileStream(outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (writer.Length < partSize)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> paths, string destinaonDirectory)
        {
            byte[] buffer = new byte[1024];

            using (FileStream writeFile = new FileStream(destinaonDirectory, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    using (FileStream readFile = new FileStream(path, FileMode.Open))
                    {
                        while (true)
                        {
                            int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                            if (bytesCount == 0)
                            {
                                break;
                            }

                            writeFile.Write(buffer, 0, bytesCount);
                        }
                    }
                }
            }
        }
    }
}
