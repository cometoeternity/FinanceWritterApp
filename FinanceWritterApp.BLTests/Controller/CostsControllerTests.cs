using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceWritterApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceWritterApp.BL.Model;

namespace FinanceWritterApp.BL.Controller.Tests
{
    [TestClass()]
    public class CostsControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var costName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var costController = new CostsController(userController.CurrentUser);
            var cost = new CostsList(costName,0,userController.CurrentUser);
            costController.Add(cost, rnd.Next(100, 500));
            Assert.AreEqual(cost.Name, costController.Costs.First().Name);
        }
    }
}