using System;

namespace PDFConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path: ");
            byte[] PDFByteArray=PDFToByteArray(Console.ReadLine());

            foreach (byte b in PDFByteArray)
            {
                Console.WriteLine(b);
            }
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
    }
}