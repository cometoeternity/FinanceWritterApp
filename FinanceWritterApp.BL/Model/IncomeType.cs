using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
    public class IncomeType
    {
        /// <summary>
        /// Добавление нового имя дохода.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Создание нового дохода.
        /// </summary>
        /// <param name="name">Название дохода.</param>
        public IncomeType(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название дохода не может быть пустым!", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"Вид дохода - {Name}";
        }
    }
}
