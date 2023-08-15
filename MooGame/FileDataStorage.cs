using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MooGame
{
    public class FileDataStorage : IDataStorage
    {
        private string _source;
        public FileDataStorage(string source)
        {
            _source = source;
        }

        public void SavePlayerScore(string _source, PlayerData playerData)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(playerData.Name + "#&#" + playerData._totalGuess);
            output.Close();
        }

        public string GetHighScore(string fileName)
        {
            string fileContent;
            using (StreamReader input = new StreamReader(fileName))
            {
                fileContent = input.ReadToEnd();
            }
            return fileContent;
        }
    }
}