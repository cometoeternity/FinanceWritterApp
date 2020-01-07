using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Имя нового пола.
        /// </summary>
        public string Name { get; set; }
        public Gender() { }

        /// <summary>
        /// Добавление нового пола.
        /// </summary>
        /// <param name="name">Название нового пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Пол не может быть пустым!", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
