using FinanceWritterApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Controller
{
    public class CostsController:ControllerBase
    {
        
        private readonly User user;
        public List<Cost> Costs { get; }
        public CostsList CostsList { get;}


        public CostsController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Costs = GetAllCosts();
            CostsList = GetCostList();
        }
        private List<Cost> GetAllCosts()
        {
            return Load<Cost>() ?? new List<Cost>();
        }
        private CostsList GetCostList()
        {
            return Load<CostsList>().FirstOrDefault() ?? new CostsList(user);
        }

        public void Add(Cost cost, double amount)
        {
            var costs = Costs.SingleOrDefault(c => c.Name==cost.Name);
            if(costs==null)
            {
                Costs.Add(cost);
                CostsList.Add(cost, amount);
            }
            else
            {
                CostsList.Add(cost, amount);
            }
            Save(Costs);
            Save(new List<CostsList>() { CostsList});
        }
    }
}
