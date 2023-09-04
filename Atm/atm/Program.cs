using atm;


string atmimg = (@"                                                 █████╗ ████████╗███╗   ███╗
                                                ██╔══██╗╚══██╔══╝████╗ ████║
                                                ███████║   ██║   ██╔████╔██║
                                                ██╔══██║   ██║   ██║╚██╔╝██║
                                                ██║  ██║   ██║   ██║ ╚═╝ ██║
                                                ╚═╝  ╚═╝   ╚═╝   ╚═╝     ╚═╝
                                                                                ");

Client user1 = new Client("Kenan", "Nuri", 21, 500, new BankCard("Kapital Bank", "Nuri Kenan","9090113456799087","9010","987",600));
Client user2 = new Client("Kamran", "Hesenov", 22, 500, new BankCard("Kapital Bank", "Kamran Hesenov","3455609878561344","0000","000",600));
Client user3 = new Client("Seid", "Aydinli", 19, 900, new BankCard("Pasha Bank", "Seid Aydinli","1923445578569011","1010","101",600));
Client user4 = new Client("Kamil", "Eliyev", 55, 500, new BankCard("Access Bank", "Kamil Eliyev", "1234567891234567", "4532", "992", new DateTime(09 / 12), 9000));
Client user5 = new Client("Murad", "Quliyev", 32, 500, new BankCard("Kapital Bank", "Murad Quliyev", "8970665687701133", "1222", "143", new DateTime(09 / 12), 300));

Bank bank = new Bank();
bank.AddClient(user1);
bank.AddClient(user2);
bank.AddClient(user3);
bank.AddClient(user4);
bank.AddClient(user5);


string input;
bank.pinLogin(atmimg,out input);

string[] menuItems = {"Card details", "User Details","list of transactions", "Money Out", "transfer money","Create User","Exit"};
int selectedItemIndex = 0;

while (true)
{
    Console.Clear();

    for (int i = 0; i < menuItems.Length; i++)
    {
        if (i == selectedItemIndex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("-> " + menuItems[i]);
            Console.ResetColor();
        }
        else Console.WriteLine(menuItems[i]);
    }

    ConsoleKeyInfo keyInfo = Console.ReadKey();

    if (keyInfo.Key == ConsoleKey.DownArrow)
    {
        selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length; 
    }
    else if (keyInfo.Key == ConsoleKey.UpArrow)
    {
        selectedItemIndex = (selectedItemIndex - 1 + menuItems.Length) % menuItems.Length;
    }
    else if (keyInfo.Key == ConsoleKey.Enter)
    {   
        Console.Clear();
        if(selectedItemIndex == 0){
        
            foreach (var item in bank.GetClients)
            {
                if(input == item.GetBankAccount.Pin){
                    item.GetBankAccount.Print();
                    Console.ReadLine();
                }
            }
        }

        else if(selectedItemIndex == 1){
        
            foreach (var item in bank.GetClients)
            {
                if(input == item.GetBankAccount.Pin){
                    item.PrintClient();
                    Console.ReadLine();

                }
            }
        }
        else if(selectedItemIndex == 2){
            bank.transactionsPrint();
        }

        else if(selectedItemIndex == 3){
            Console.Write("Include the money you will withdraw from the atm: ");
            int outmoney = int.Parse(Console.ReadLine());
            bank.moneySubtract(outmoney,input);   
        }
        else if(selectedItemIndex == 4){
            Console.Write("Enter the Pin of the user you are sending the money to: ");
            string pin2 = Console.ReadLine();
            Console.Write("Enter the amount of money you are sending: ");
            int outmoney = int.Parse(Console.ReadLine());
            bank.moneyTransfer(pin2,input,outmoney);
        }
        else if(selectedItemIndex == 5){
            bank.newClient();
        }
        else if(selectedItemIndex == 6){
            bank.pinLogin(atmimg,out input);
        }
        
    }
}