using PR5_Guselnikova_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR5_Guselnikova_Mod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = Helper.GetContext();
            Console.WriteLine("Создание новой учетной записи");

            Console.Write("Введите почту: ");
            string employee_email = Console.ReadLine();
            Employee employee = db.Employee.Where(x => x.Email == employee_email).FirstOrDefault();

            if (employee != null)
            {
                if (employee.ID_Authorization != null)
                {
                    Console.WriteLine("Учетная запись для этого сотрудника уже существует!");
                    return;
                }

                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                Console.WriteLine("Выберите роль:");
                var roles = db.Roles.ToList();
                foreach (var role in roles) 
                {
                    Console.WriteLine(role.ID_Role + " | " + role.Name);
                }

                int IDroles = Convert.ToInt32(Console.ReadLine());
                string hash = HashPasswords.Hash.HashPassword(password);

                Console.Write("Хэшированный пароль пользователя: " + hash);
                

                Models.Authorization authorization = new Models.Authorization
                {
                    Login = login,
                    Password = hash,
                    RoleID = IDroles
                };
                db.Authorization.Add(authorization);
                db.SaveChanges();
                employee.ID_Authorization = authorization.ID_Authorization;
                db.SaveChanges();
                Console.WriteLine("Учетная запись успешно добавлена!");
            }

            else
            {
                Console.WriteLine("Сотрудник не найден!");
            }
        }
    }
}
