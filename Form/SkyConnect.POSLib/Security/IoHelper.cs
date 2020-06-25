using System;
using System.IO;
using System.Reflection;

namespace SkyConnect.POSLib.Security
{
    internal static class IoHelper
    {
        internal static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //public static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        internal static Stream GetStream(string stringData)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(stringData);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        internal static string GetString(Stream inputStream)
        {
            string output;
            using (StreamReader reader = new StreamReader(inputStream))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }

        internal static void WriteStream(Stream inputStream, ref byte[] dataBytes)
        {
            using (Stream outputStream = inputStream)
            {
                outputStream.Write(dataBytes, 0, dataBytes.Length);
            }
        }
    }
}
