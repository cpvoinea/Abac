using System.IO;

namespace JsonWinEdit.Data
{
    public static class FileSystemAccess
    {
        public static string ReadTextFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            using (var sr = new StreamReader(fileName))
                return sr.ReadToEnd();
        }

        public static void WriteTextToFile(string text, string fileName)
        {
            using (var sw = new StreamWriter(fileName))
            {
                sw.Write(text);
            }
        }
    }
}
