using System.Runtime.InteropServices;

namespace atm;
public class Bank
{
    private List<Client> clients = new List<Client>();
    private List<string> atmlist = new List<string>();
    public List<Client> GetClients { get => clients; } 
    public void AddClient(Client client)
    {
        clients.Add(client);
    }

    public void RemoveClient(Client client)
    {
        clients.Remove(client);
    }
    public void AddAtmList(string input){
        atmlist.Append(input);
    }
    public void transactionsPrint(){
        foreach (var item in atmlist)
            Console.WriteLine(item);

        Console.ReadLine();
    }
    public void pinLogin(string atmimg,out string input){

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine(atmimg);
            Console.Write("\t\t\t\t\t\t\tEnter Pin: ");
            input = Console.ReadLine();
            bool check = Login(input);
            if(!check) continue;
            break;
        }
    
    }
    public bool Login(string input)
    {
        foreach (Client client in clients)
        {
            if (input == client.GetBankAccount.Pin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Welcome {client.Name} {client.Surname}");
                Console.ReadLine();
                return true; 
            }
        }
        return false;
    }

    public void moneySubtract(int outmoney,string input){

        AddAtmList("Removing money from the balance");
        try{
            if(outmoney <= 0) throw new Exception("extracted money cannot be 0 or negative");
            
            foreach (var item in clients)
            {  
                if(input == item.GetBankAccount.Pin){
                    if((item.GetBankAccount.Balance - outmoney) > 0){
                        item.GetBankAccount.Balance -= outmoney;
                        Console.WriteLine($"{outmoney} dollars subtracted from the balance");
                        Console.WriteLine("Your Balance: " + item.GetBankAccount.Balance);
                        Console.ReadLine();
                        return;
                    }
                }
            }
            throw new Exception("Removing money from the balance");
        
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.ReadLine();

        }
    }

    public void moneyTransfer(string pin,string input,int outmoney){
        try{
            if(outmoney <= 0) throw new Exception("extracted money cannot be 0 or negative");
                
        
            foreach (var item in clients)
            {
                if(input == item.GetBankAccount.Pin){
                    if((item.GetBankAccount.Balance - outmoney) >= 0){
                        item.GetBankAccount.Balance -= outmoney;
                        foreach (var tr in clients)
                        {
                            if(pin == tr.GetBankAccount.Pin){
                                tr.GetBankAccount.Balance += outmoney;
                                Console.WriteLine("Money transferred to account");
                                AddAtmList("Money transfer");
                                Console.ReadLine();
                                return;
                            }
                        }
                    }
                }
            }
            AddAtmList("Money transfer");
            throw new Exception("Money Could Not Be Sent For Some Reason");

        }
        catch{
        
            Console.WriteLine("The money has not been sent, check the pin or balance of the account you sent from");
            Console.ReadLine();
        
        }
    
    }

    public void newClient(){
        try{
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Bank Name: ");
            string bankname = Console.ReadLine();
            Console.Write("Enter Full name: ");
            string fullname = Console.ReadLine();
            Console.Write("Enter Balance: ");
            decimal balance  = decimal.Parse(Console.ReadLine());
            Client newcl = new Client(name,surname,age,salary,new BankCard(bankname,fullname,balance));
            AddClient(newcl);
            newcl.GetBankAccount.Print();
            Console.WriteLine("your account was created successfully your bank details are above");
            Console.ReadLine();
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }
    
}

