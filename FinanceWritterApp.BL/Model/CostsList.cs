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
        public double Amount { get; set; } = 0;

        /// <summary>
        /// Время добавление расхода.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; set; }

        public CostsList() { }

        /// <summary>
        /// Создание списка расходов.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public CostsList(string name,double amount,User user)
        {
            if(user==null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название расхода не может быть пустым!", nameof(name));
            }
            if(amount<0)
            {
                throw new ArgumentOutOfRangeException("Неправильное число в записи расходов!", nameof(amount));
            }
            Moment = DateTime.UtcNow;
            Name = name;
            User = user;
        }

        public override string ToString()
        {
            return $"Название расхода - {Name}, Сумма расхода - {Amount}";
        }
    }
}
