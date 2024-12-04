// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

using MyMenuMessages;

using MyMenuMethods;

namespace Menu
{
    class Program
    {
        static void Main()
        {
            MenuMessages message = new MenuMessages();

            MenuMethods method = new MenuMethods();

            method.Menu();


        }
    }
}
