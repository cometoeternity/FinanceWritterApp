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
        public List<CostType> Costs { get; }
        public CostsList CostsList { get; }

        public CostsController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            }
            this.user = user;
            Costs = GetAllCosts();
            CostsList = GetCosts();
        }
        private List<CostType> GetAllCosts()
        {
            return Load<CostType>() ?? new List<CostType>();
        }

        private CostsList GetCosts()
        {
            return Load<CostsList>().FirstOrDefault() ?? new CostsList(user);
        }

        public void Add(CostType costType,double amount)
        {
            var costs = Costs.SingleOrDefault(c => c.Name == costType.Name);
            if(costs==null)
            {
                Costs.Add(costType);
            }
            CostsList.Add(costType, amount);
            Save(Costs);
            Save(new List<CostsList>() { CostsList });
        }

        public void AllAmount()
        {

        }

        public void AllAmountByDate(DateTime dateTime)
        {

        }

    }
   
}
