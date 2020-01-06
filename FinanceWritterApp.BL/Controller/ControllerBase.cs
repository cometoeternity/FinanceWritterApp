using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save<T>(List<T> item) where T:class
        {
            var fileName = typeof(T).Name;
            var formatter = new BinaryFormatter();
            using(var fileStream=new FileStream(fileName,FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, item);
            }
        }

        protected List<T> Load<T>() where T:class
        {
            var fileName = typeof(T).Name;
            var formatter = new BinaryFormatter();
            using(var fileStream=new FileStream(fileName,FileMode.OpenOrCreate))
            {
                if(fileStream.Length>0 && formatter.Deserialize(fileStream) is List<T> item)
                {
                    return item;
                }
                else
                {
                    return new List<T>();
                }
                    
            }
        }

    }
}
