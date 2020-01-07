using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
   public class IncomeList
   {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// Время записи дохода.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Конструктор для записи доходов.
        /// </summary>
        /// <param name="user"></param>
        public IncomeList(string name, double amount, User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название расхода не может быть пустым!", nameof(name));
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Неправильное число в записи расходов!", nameof(amount));
            }
                Moment = DateTime.UtcNow;
                Name = name;
                Amount = amount;
                User = user;
        }
        public override string ToString()
        {
            return $"Название дохода - {Name}, Сумма расхода - {Amount}";
        }
    }
}
