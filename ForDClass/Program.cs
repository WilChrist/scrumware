using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDClass
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Model1Container model1Container = new Model1Container();
            model1Container.Database.Log = Console.Write;
            Role role = new Role
            {
                Name = "ScrumMaster",
                Description = "Animateur de Réunion"
            };
            model1Container.Roles.Add(role);

            User user = new User
            {
                LastName = "Wandji",
                FirstName = "Alexis",
                DateOfBirth = DateTime.Now,
                SignUpDate = DateTime.Now.ToLongDateString(),
                LastSignIn = DateTime.Now,
                Role = role,
                Description="Un gars bon"
            };
            model1Container.Users.Add(user);

            
             Projet projet = new Projet()
             {
                 Name = "ScrumWare Building",
                 CreationDate = DateTime.Now,
                 LastUpdateDate = DateTime.Now,
                 State = "Running",
                 Description = "Création d'un Outils Scrum"

             };
            projet.User.Add(user);
            model1Container.SaveChanges();

            Console.Read();
        }
    }
}
