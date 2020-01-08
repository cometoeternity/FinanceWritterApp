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
        public List<Income> Incomes { get; }
        public IncomeList IncomeList { get; }


        public IncomeController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Incomes = GetAllIncomes();
            IncomeList = GetIncomeList();
        }
        private List<Income> GetAllIncomes()
        {
            return Load<Income>() ?? new List<Income>();
        }
        private IncomeList GetIncomeList()
        {
            return Load<IncomeList>().FirstOrDefault() ?? new IncomeList(user);
        }

        public void Add(Income income, double amount)
        {
            var costs = Incomes.SingleOrDefault(c => c.Name == income.Name);
            if (costs == null)
            {
                Incomes.Add(income);
                IncomeList.Add(income, amount);
            }
            else
            {
                IncomeList.Add(income, amount);
            }
            Save(Incomes);
            Save(new List<IncomeList>() { IncomeList });
        }

    }
}

