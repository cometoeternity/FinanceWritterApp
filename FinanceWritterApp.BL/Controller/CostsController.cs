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
        public List<CostsList> Costs { get; }

        public CostsController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Costs = GetAllCosts();
        }
        private List<CostsList> GetAllCosts()
        {
            return Load<CostsList>() ?? new List<CostsList>();
        }

        public void Add(CostsList cost, double amount)
        {
            var costs = Costs.SingleOrDefault(c => c.Name == cost.Name);
            if(costs==null)
            {
                var costList = new CostsList(cost.Name,amount);
                Costs.Add(costList);
            }
            else
            {
                var costList = new CostsList(cost.Name,costs.Amount+=amount);
                Costs.Add(costList);
            }
            Save(Costs);
        }
    }
}
