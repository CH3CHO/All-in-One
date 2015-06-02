using System.IO;

namespace GenericUtility
{
    public static class StreamUtils
    {
        /// <summary>
        /// Write the stream to the specified file.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filePath"></param>
        /// <returns>The number of byte written to the file.</returns>
        public static long CopyToFile(this Stream stream, string filePath)
        {
            var folder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var fileLength = 0L;
            using (var fileStream = File.Create(filePath))
            {
                var buffer = new byte[4096];
                int length;
                while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fileStream.Write(buffer, 0, length);
                    fileLength += length;
                }
            }
            return fileLength;
        }

        public static byte[] ReadAllBytes(this Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                var buffer = new byte[2048];
                int length;
                while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    ms.Write(buffer, 0, length);
                }
                return ms.ToArray();
            }
        }
    }
}