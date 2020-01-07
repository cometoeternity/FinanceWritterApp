using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.BL.Model
{
    [Serializable]
    public class User
    {
        public string UserName { get; set; }
        private readonly DateTime registrationTime;
        public Gender Gender { get; set; }
        public User(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(userName));
            }
            UserName = userName;
        }
        public User(string userName, Gender gender)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            if(gender==null)
            {
                throw new ArgumentNullException("Пол не может быть пустым!", nameof(gender));
            }
            UserName = userName;
            Gender = gender;
            registrationTime = DateTime.Now;
        }
        public override string ToString()
        {
            return UserName + " " + registrationTime;
        }
    }
}
