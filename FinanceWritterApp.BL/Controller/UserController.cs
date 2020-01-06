using FinanceWritterApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Controller
{
    public class UserController:ControllerBase
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; set; } = false;

        public UserController(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым!", nameof(name));
            }
            Users = GetUsersData();
            CurrentUser = Users.FirstOrDefault(u => u.UserName == name);
            if(CurrentUser==null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save(Users);
            }
        }
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUsersData(string gender)
        {
            if(gender==null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть пустым!", nameof(gender));
            }
            CurrentUser.Gender = new Gender(gender);
            Save(Users);
        }
    }
}
