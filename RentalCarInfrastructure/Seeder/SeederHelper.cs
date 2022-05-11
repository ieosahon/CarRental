using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Seeder
{
    public class SeederHelper<T>
    {
        public static List<T> GetData(string filePath)
        {
            var baseDir = Directory.GetCurrentDirectory();
            var path2 = File.ReadAllText(FilePath(baseDir, filePath));
            return JsonConvert.DeserializeObject<List<T>>(path2);
        }
        private static string FilePath(string folderName, string fileName)
        {
            folderName += @"/Json/";
            if (Directory.Exists(folderName))
            {
                return Path.Combine(folderName, fileName);
            }
            return "";
        }
    }
}

