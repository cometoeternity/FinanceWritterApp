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
        /// Время записи дохода.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Словарь доходов.
        /// </summary>
        public Dictionary<IncomeType,double> Incomes { get; set; }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Конструктор для записи доходов.
        /// </summary>
        /// <param name="user"></param>
        public IncomeList(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            }
            Moment = DateTime.UtcNow;
            User = user;
            Incomes = new Dictionary<IncomeType, double>();
        }

        /// <summary>
        /// Добавление дохода с суммой/если расход присутствует, то добавление только суммы дохода.
        /// </summary>
        /// <param name="incomeType">Тип дохода.</param>
        /// <param name="amount">Сумма дохода.</param>
        public void Add(IncomeType incomeType, double amount)
        {
            var revenue = Incomes.Keys.FirstOrDefault(c => c.Name.Equals(incomeType.Name));
            if (revenue == null)
            {
                Incomes.Add(incomeType, amount);
            }
            else
            {
                Incomes[revenue] += amount;
            }
        }

    }
}
