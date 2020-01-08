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
        public Dictionary<Income, double> Incomes { get; set; }
        /// <summary>
        /// Время записи дохода.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Конструктор для записи доходов.
        /// </summary>
        /// <param name="user"></param>
        public IncomeList() { }

        /// <summary>
        /// Создание списка расходов.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public IncomeList(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            Moment = DateTime.Now;
            Incomes = new Dictionary<Income, double>();
        }

        public void Add(Income incomeName, double amount)
        {
            var cost = Incomes.Keys.FirstOrDefault(c => c.Name.Equals(incomeName));
            if (cost == null)
            {
                Incomes.Add(incomeName, amount);
            }
            else
            {
                Incomes[cost] += amount;
            }
        }

        public override string ToString()
        {
            return $"Название расхода - {Incomes.Keys}, Сумма расхода - {Incomes.Values}";
        }
    }
}
