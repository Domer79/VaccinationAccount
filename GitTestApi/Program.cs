using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GitTestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUsers();
            Console.ReadLine();
        }

        static async void GetUsers()
        {
            try
            {
                var connection = new Connection();
                var github = new GitHubClient(new ProductHeaderValue("VaccinationAccount"));
                var users = await github.User.Current();
//                var user = await github.User.Get("Domer79");
                    //.ContinueWith(task => { Console.WriteLine(task.Result); });
                Console.WriteLine(users[0].Login + " folks love the half ogre!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
