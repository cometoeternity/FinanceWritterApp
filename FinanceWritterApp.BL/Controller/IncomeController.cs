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
        public List<IncomeType> Incomes { get; }
        public IncomeList IncomeList { get; }
        public IncomeController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Incomes = GetAllIncomes();
            IncomeList = GetIncomes();
        }
        private List<IncomeType> GetAllIncomes()
        {
            return Load<IncomeType>() ?? new List<IncomeType>();
        }

        private IncomeList GetIncomes()
        {
            return Load<IncomeList>().FirstOrDefault() ?? new IncomeList(user);
        }
        public void Add(IncomeType incomeType, double amount)
        {
            var income = Incomes.SingleOrDefault(i => i.Name == incomeType.Name);
            if (income == null)
            {
                Incomes.Add(incomeType);
            }
            IncomeList.Add(income, amount);
            Save(Incomes);
            Save(new List<IncomeList>() { IncomeList });
        }

    }
}

