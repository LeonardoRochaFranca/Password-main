using System;
using System.Threading.Tasks;

namespace Password_Main
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var senha = new Password();
            string teste = await senha.GeneratePassword();
            Console.WriteLine(teste);
        }
    }
}
