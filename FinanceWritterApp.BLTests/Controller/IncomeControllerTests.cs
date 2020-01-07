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
    public class IncomeControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var incomeName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var incomeController = new IncomeController(userController.CurrentUser);
            var cost = new IncomeList(incomeName, 0, userController.CurrentUser);
            incomeController.Add(cost, rnd.Next(100, 500));
            Assert.AreEqual(cost.Name, incomeController.Incomes.First().Name);
        }
    }
}