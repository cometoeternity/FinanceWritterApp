using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
    public class CostType
    {
        /// <summary>
        /// Название вида расхода.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Добавление нового вида расхода.
        /// </summary>
        /// <param name="name">Название расхода.</param>
        public CostType(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование расхода не может быть пустым!", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"Вид расхода - {Name}";
        }
    }
}
