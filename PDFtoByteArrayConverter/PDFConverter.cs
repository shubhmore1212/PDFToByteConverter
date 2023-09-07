using System;
using System.Collections;

namespace PDFConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string? input = "";
            do
            {
                Console.WriteLine("Enter File Path or 'q' to quit : ");
                input = Console.ReadLine();
                if(string.IsNullOrEmpty(input) || input=="q")
                {
                    break;
                }
                byte[]? PDFByteArray = PDFToByteArray(input);
                WriteToFile(PDFByteArray);
            } while (true);

            Console.WriteLine();
        }

        static byte[]? PDFToByteArray(string pdfFilePath)
        {
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
                return bytes;
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message + "\nPlease input valid file path.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return null;
        }

        static void WriteToFile(byte[]? byteArray)
        {
            if (byteArray == null) return;

            foreach (byte b in byteArray)
            {
                using (var writer = File.AppendText("result.txt"))
                {
                    writer.Write(b);
                }
            }
            using (var writer = File.AppendText("result.txt"))
            {
                writer.WriteLine();
                writer.WriteLine("=============End of Byte Array============");
                writer.WriteLine();
            }
            Console.WriteLine("Done");
        }
    }
}