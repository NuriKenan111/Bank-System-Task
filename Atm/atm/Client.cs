namespace atm;
public class Client{
    private string id;
    private string name;
    private string surname;
    private int age;
    private decimal salary;
    private BankCard bankAccount;
    
    public string Name {
        get => name;
        set {
            if (value.Length >= 3) {
                name = value;
                return;
            }
            throw new Exception("Name must be at least 3 characters long.");
        }
    }
    public string Surname {
        get => surname;
        set {
            if (value.Length >= 3) {
                surname = value;
                return;
            }
            throw new Exception("Surname must be at least 3 characters long.");
        }
    }
    public int Age {
        get => age;
        set {
            if (value >= 18) {
                age = value;
                return;
            }
            throw new Exception("The minimum age limit is 18");
        }
    }

    public decimal Salary {
        get => salary;
        set {
            if (value >= 0) {
                salary = value;
                return;
            }
            throw new Exception("Minimum Salary 0");
        }
    }
    
    public BankCard GetBankAccount { get => bankAccount;}
    public string RandomID(){
    
        string str = "";
        for (int i = 0; i < 5; i++)
        {
            str += Random.Shared.Next(10).ToString();
        }
        return str;
    
    }
    public void PrintClient(){
        Console.WriteLine("<---------------------------->");
        Console.WriteLine("Id: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Surname: " + surname);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Salary: " + salary);
        Console.WriteLine("Bank Account: " + bankAccount.Bankname);
        
    
    }
    public Client(string name,string surname,int age,decimal salary,BankCard bankCard)
    {
        id = RandomID();
        this.Name = name;
        this.Surname = surname;
        this.Age = age;
        this.Salary = salary;
        this.bankAccount = bankCard;
    }




}
   
