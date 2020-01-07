using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceWritterApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUsersDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var userController = new UserController(userName);
            userController.SetNewUsersData(gender);
            Assert.AreEqual(userName, userController.CurrentUser.UserName);
            Assert.AreEqual(gender, userController.CurrentUser.Gender.Name);
        }
    }
}