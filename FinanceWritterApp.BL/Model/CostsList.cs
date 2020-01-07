using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
    public class CostsList
    {
        /// <summary>
        /// Имя расхода.
        /// </summary>
        public string Name  { get; set; }

        /// <summary>
        /// Сумма расхода.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Время добавление расхода.
        /// </summary>
        public DateTime Moment { get; set; }

        public CostsList() { }

        /// <summary>
        /// Создание списка расходов.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public CostsList(string name,double amount)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название расхода не может быть пустым!", nameof(name));
            }
            if(amount<0)
            {
                throw new ArgumentOutOfRangeException("Неправильное число в записи расходов!", nameof(amount));
            }
            Moment = DateTime.Now;
            Amount = amount;
            Name = name;
        }

        public override string ToString()
        {
            return $"Название расхода - {Name}, Сумма расхода - {Amount}";
        }
    }
}
