using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank_t
{
    public class Client
    {

        public Client(string name, string surname, int age, double salary, BankCard bankAcc)
        {
            this.name = name;

        }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public double salary { get; set; }
        public BankCard bankAcc { get; set; }
        public void ShowBalance()
        {
            Console.WriteLine($"Balance:{bankAcc.balance}");
        }
    }
}

