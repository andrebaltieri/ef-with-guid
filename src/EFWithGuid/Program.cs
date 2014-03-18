using EFWithGuid.DataContexts;
using EFWithGuid.Models;
using System;

namespace EFWithGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            var andrebaltieri = new User
            {
                Email = "andrebaltieri@hotmail.com",
                IsActive = true,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = "andrebaltieri",
                Password = "andrebaltieri"
            };

            var batman = new User
            {
                Email = "bruce.wayne@hotmail.com",
                IsActive = true,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = "andrebaltieri",
                Password = "batman"
            };

            using (AppDbContext db = new AppDbContext())
            {
                db.Users.Add(andrebaltieri);
                db.Users.Add(batman);
                db.SaveChanges();

                foreach (User user in db.Users)
                {
                    Console.WriteLine(String.Format("{0} - {1}", user.Id, user.Email));
                }

                Console.WriteLine(
                    String.Format("{0} - {1}", 
                    db.Users.Find(batman.Id).Id,
                    db.Users.Find(batman.Id).Email));
            }

            Console.ReadKey();
        }
    }
}
