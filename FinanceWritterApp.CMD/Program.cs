using FinanceWritterApp.BL.Controller;
using FinanceWritterApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWritterApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение для записи Доходов и Расходов!");
            Console.WriteLine("Введите Логин: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var costsController = new CostsController(userController.CurrentUser);
            var incomeController = new IncomeController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите свой пол: ");
                var gender = Console.ReadLine();
                userController.SetNewUsersData(gender);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Выберите следующее действие: ");
                Console.WriteLine("E - Ввод расходов.");
                Console.WriteLine("A - Ввод доходов.");
                Console.WriteLine("Q - Выйти и закрыть.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var costs = EnterCosts();
                        costsController.Add(costs.Cost,costs.Amount);
                        break;
                    case ConsoleKey.A:
                        var income = EnterIncomes();
                        incomeController.Add(income.Income,income.Amount);
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (CostsList Cost, double Amount) EnterCosts()
        {
            Console.WriteLine("Введите название расхода: ");
            var name = Console.ReadLine();
            var amount = ParseDouble("Сумма расхода: ");
            var cost = new CostsList(name, amount);
            return (Cost: cost, Amount: amount);
        }
        private static (IncomeList Income,double Amount) EnterIncomes()
        {
            Console.WriteLine("Введите название дохода: ");
            var name = Console.ReadLine();
            var amount = ParseDouble("Сумма расхода: ");
            var income = new IncomeList(name, amount);
            return (Income: income, Amount: amount);
        }
        private static double ParseDouble(string name)
        {
            while(true)
            {
                Console.WriteLine($"{name} ");
                if(double.TryParse(Console.ReadLine(),out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {name}");
                }
            }
        }
    }
}
    
        
