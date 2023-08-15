using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public interface IDataStorage
    {
        public void SavePlayerScore(string _source, PlayerData playerData);
        public string GetHighScore(string fileName);
        
    }
}
