using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PatientImaging.FileTracker.Services
{
    interface IFileService
    {
        List<string> GetNewFilesPath();
        Task<T> ParseXMLFile<T>(string path);
        void SetAsTransfered(string path);
    }

    internal class FileService : IFileService
    {
        public List<string> GetNewFilesPath()
        {
            return Directory.GetFiles("Files").Where(file => !file.EndsWith('_')).ToList();
        }

        public async Task<T> ParseXMLFile<T>(string path)
        {
            var xmlData = await File.ReadAllTextAsync(path);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlData))
            {
                T parsedData = (T)(serializer.Deserialize(reader));
                return parsedData;
            }
        }

        public void SetAsTransfered(string path)
        {
            if(File.Exists(path))
                System.IO.File.Move(path, path+"_");
        }
    }
}
