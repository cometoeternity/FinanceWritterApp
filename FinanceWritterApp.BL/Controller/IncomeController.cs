using FinanceWritterApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Controller
{
    public class IncomeController:ControllerBase
    {
        
        private readonly User user;
        public List<IncomeList> Incomes { get; }
        public IncomeController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Incomes = GetAllIncomes();
        }
        private List<IncomeList> GetAllIncomes()
        {
            return Load<IncomeList>() ?? new List<IncomeList>();
        }
        public void Add(IncomeList incomeType, double amount)
        {
            var income = Incomes.SingleOrDefault(c => c.Name == incomeType.Name);
            if (income == null)
            {
                var incomeList = new IncomeList(incomeType.Name, amount);
                Incomes.Add(incomeList);
            }
            else
            {
                var incomeList = new IncomeList(incomeType.Name, income.Amount += amount);
                Incomes.Add(incomeList);
            }
            Save(Incomes);
        }

    }
}

