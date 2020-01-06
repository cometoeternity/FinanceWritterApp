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
        /// Время добавление расхода.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Словарь расходов с суммой расхода.
        /// </summary>
        public Dictionary<CostType,double> Costs  { get; set; }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Создание списка расходов.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public CostsList(User user)
        {
            if(user==null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            }
            Moment = DateTime.UtcNow;
            User = user;
            Costs = new Dictionary<CostType, double>();
        }

        /// <summary>
        /// Добавление нового вида расхода в лист расходов с суммой/если есть уже такой расход, добавление суммы расхода.
        /// </summary>
        /// <param name="costType">Вид расхода.</param>
        /// <param name="amount">Сумма расхода.</param>
        public void Add(CostType costType,double amount)
        {
            var expenses = Costs.Keys.FirstOrDefault(c => c.Name.Equals(costType.Name));
            if(expenses==null)
            {
                Costs.Add(costType, amount);
            }
            else
            {
                Costs[expenses] += amount;
            }
        }
    }
}
