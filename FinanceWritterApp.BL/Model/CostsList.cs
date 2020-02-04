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
        public Dictionary<Cost,double> Costs { get; set; }

        /// <summary>
        /// Время добавление расхода.
        /// </summary>
        public DateTime Moment { get; set; }
        public User User { get; set; }

        public CostsList() { }

        /// <summary>
        /// Создание списка расходов.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public CostsList(User user)
        {
            if(user==null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            Moment = DateTime.Now;
            Costs = new Dictionary<Cost, double>();
        }

        public void Add(Cost costName,double amount)
        {
            var cost = Costs.Keys.FirstOrDefault(c => c.Name.Equals(costName));
            if(cost==null)
            {
                Costs.Add(costName, amount);
            }
            else
            {
                Costs[cost] += amount;
            }
        }

        public override string ToString()
        {
            return $"Название расхода - {Costs.Keys}, Сумма расхода - {Costs.Values} рублей.";
        }
    }
}
