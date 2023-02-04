using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Bank_t;


Client nargis = new Client("Nargis", "Orujova", 22, 3500, new BankCard("KapitalBank", "Nargis Orujova", "5103071506065678", "1909", "198", "02/27", 150));
Client cahangir = new Client("Cahangir", "Suleymanov", 25, 2500, new BankCard("KapitalBank", "Cahangir Suleymanov", "5103071605065678", "2345", "567", "07/28", 550));
Client tural = new Client("Tural", "Taghi", 24, 5000, new BankCard("KapitalBank", "Tural Taghi", "5103071505059078", "1705", "189", "02/27", 900));
Client dunyamin = new Client("Dunyamin", "Orujlu", 24, 6500, new BankCard("KapitalBank", "Dunyamin Orujlu", "5103071505059078", "1705", "189", "02/27", 900));
Client madina = new Client("Madina", "Akberova", 24, 5000, new BankCard("KapitalBank", "Madina Akberova", "5103071505059078", "1705", "189", "02/27", 900));


Bank bank = new Bank();
bank.AddUser(nargis);
bank.AddUser(cahangir);
bank.AddUser(tural);
bank.AddUser(dunyamin);
bank.AddUser(madina);

bool Check(decimal num, decimal balance)
{
    if (balance >= num)
        return true;

    return false;
}

void Bank()
{
labelmain:
    Console.Clear();
    Console.WriteLine("Enter pin:");
    string? pin = Console.ReadLine();
    for (int i = 0; i < bank.clients.Count; i++)
    {
        if (pin == bank.clients[i].bankAcc.pin)
        {
        labelchoice:
            Console.Clear();
            Console.WriteLine($"Welcome,{bank.clients[i].name}{bank.clients[i].surname}");
            Console.WriteLine("[1]Balance");
            Console.WriteLine("[2]Cash");
            Console.WriteLine("[3]Card To Card");
            Console.WriteLine("[4]Back");
            Console.WriteLine("Enter the choice:");
            string? choice = Console.ReadLine();
            if (choice == "1")
            {
            labelbalance:
                Console.Clear();
                bank.clients[i].ShowBalance();
                Console.WriteLine("Back");
                choice = Console.ReadLine();
                if (choice != "4")
                {
                    Console.WriteLine("Try Again!");
                    goto labelbalance;
                }
                else
                    goto labelchoice;
            }
            else if (choice == "2")
            {
            labelcash:
                Console.Clear();
                Console.WriteLine("[1]10$");
                Console.WriteLine("[2]20$");
                Console.WriteLine("[3]50$");
                Console.WriteLine("[4]1000$");
                Console.WriteLine("[5]Other $");
                Console.WriteLine("[6]Back ");
                choice = Console.ReadLine();
                if (Convert.ToInt32(choice) < 0 || Convert.ToInt32(choice) > 5)
                {
                    Console.WriteLine("Try Again!");
                    goto labelcash;
                }
                else if (choice == "1")
                {
                    if (Check(10, bank.clients[i].bankAcc.balance))
                    {
                        bank.clients[i].bankAcc.balance -= 10;
                        Thread.Sleep(1000);
                        goto labelchoice;
                    }

                }
                else if (choice == "2")
                {
                    if (Check(20, bank.clients[i].bankAcc.balance))
                    {
                        bank.clients[i].bankAcc.balance -= 20;
                        Thread.Sleep(1000);
                        goto labelchoice;
                    }

                }
                else if (choice == "3")
                {
                    if (Check(50, bank.clients[i].bankAcc.balance))
                    {
                        bank.clients[i].bankAcc.balance -= 50;
                        Thread.Sleep(1000);
                        goto labelchoice;
                    }

                }
                else if (choice == "4")
                {
                    if (Check(100, bank.clients[i].bankAcc.balance))
                    {
                        bank.clients[i].bankAcc.balance -= 100;
                        Thread.Sleep(1000);
                        goto labelchoice;
                    }

                }
                else if (choice == "5")
                {
                    Console.WriteLine("Enter money:");
                    decimal money = Convert.ToDecimal(Console.ReadLine());
                    if (Check(money, bank.clients[i].bankAcc.balance))
                    {
                        bank.clients[i].bankAcc.balance -= money;
                        Thread.Sleep(1000);
                        goto labelchoice;
                    }

                }
                else
                    goto labelchoice;
            }
            else if (choice == "3")
            {
            labelcardtocard:
                Console.Clear();
                Console.WriteLine("Enter 16 digits:");
                choice = Console.ReadLine();
                if (choice != "4")
                {
                    for (int k = 0; k < bank.clients.Count; k++)
                    {
                        if (choice == bank.clients[k].bankAcc.pan)
                        {
                            Console.WriteLine("Enter money");
                            decimal money = Convert.ToDecimal(Console.ReadLine());
                            if (Check(money, bank.clients[i].bankAcc.balance))
                            {
                                bank.clients[k].bankAcc.balance += money;

                                bank.clients[i].bankAcc.balance -= money;
                                Thread.Sleep(1000);
                                goto labelchoice;

                            }

                        }
                    }
                    Console.WriteLine("User Not Found!");
                    Thread.Sleep(1000);
                    goto labelcardtocard;

                }
                else
                    goto labelchoice;


            }
            else
                goto labelmain;


        }
        else goto labelmain;
    }
    Console.WriteLine("Wrong pin,try again!");
    Thread.Sleep(1000);
    goto labelmain;
}


