using System;

namespace atm;

public class  BankCard
{
   private string bankName;
    private string fullName;
    private string pan;
    private string pin;
    private string cvc;
    private DateTime expirationDate;
    private decimal balance;


    public string Bankname {
        get => bankName ;
        set{
            if(value.Length < 3)
                throw new Exception("Bank Name must be minimum 3");
            bankName = value;

        } 
    }

    public string Fullname {
        get => fullName ;
        set{
            if(value.Length < 3)
                throw new Exception("Full Name must be minimum 3");
            fullName = value;
        } 
    }

    public string Pan {
        get => pan ;
        set{
            if(value.Length ==  16){
                pan = value;
                return;
            }
            throw new Exception("Pan code must be minimum 16");
        } 
    }

    public string Pin {
        get => pin ;
        set{
            if(value.Length == 4){
                pin = value;
                return;
            }     
            throw new Exception("pin code must be 4 digits ");
        } 
    }
    public string Cvc {
        get => cvc ;
        set{
            if(value.Length == 3){
                cvc = value;
                return;
            }     
            throw new Exception("cvc code must be 4 digits ");
        } 
    }
    public DateTime ExpirationDate {
        get => expirationDate ;
        set => expirationDate = value;
    }

    public decimal Balance {
        get => balance ;
        set{
            if(value  >= 0){
                balance = value;
                return;
            }     
            throw new Exception("balance 0 won't be small");
        } 
    }

    public string RandomPan(){
    
        string randomstr = "";
        for (int i = 0; i < 16; i++)
            randomstr+= Random.Shared.Next(10).ToString();
        
        return randomstr;
    }
    public string RandomPin(){
    
        string randomstr = "";
        for (int i = 0; i < 4; i++)
            randomstr+= Random.Shared.Next(10).ToString();
        
        return randomstr;
    }
    public string RandomCvc(){
    
        string randomstr = "";
        for (int i = 0; i < 3; i++)
            randomstr += Random.Shared.Next(10).ToString();
        
        return randomstr;
    }
    public string FormatPan()
    {
        string formattedPan = $"{pan.Substring(0, 4)}-{pan.Substring(4, 4)}-{pan.Substring(8, 4)}-{pan.Substring(12, 4)}";

        return formattedPan;
    }
    public void Print(){
        Console.WriteLine("<----------------------------------->");
        Console.WriteLine("Bank Name: " + bankName);
        Console.WriteLine("FullName: " + fullName);
        Console.WriteLine("Pan: " + FormatPan());
        Console.WriteLine("Pin: " + pin);
        Console.WriteLine("Cvc: " + cvc);
        Console.WriteLine("Datetime: " + expirationDate);
        Console.WriteLine("Balance:  " + balance);
    
    }
    public BankCard(string bankName, string fullName, string pan, string pin, string cvc, DateTime expirationDate, decimal balance)
    {
        this.Bankname = bankName;
        this.Fullname = fullName;
        this.Pan = pan;
        this.Pin = pin;
        this.Cvc = cvc;
        this.ExpirationDate = expirationDate;
        this.Balance = balance;
    } 
    public BankCard(string bankName, string fullName,DateTime expirationDate,decimal balance)
    {
        this.Bankname = bankName;
        this.Fullname = fullName;
        this.pan = RandomPan();
        this.pin = RandomPin();
        this.cvc = RandomCvc();
        this.expirationDate = expirationDate;
        this.balance = balance;
    }

    public BankCard(string bankName, string fullName)
    {
        this.Bankname = bankName;
        this.Fullname = fullName;
        this.pan = RandomPan();
        this.pin = RandomPin();
        this.cvc = RandomCvc();
        this.expirationDate = DateTime.Now;
        this.balance = 200;
        
    }
    public BankCard(string bankName, string fullName,decimal balance)
    {
        this.Bankname = bankName;
        this.Fullname = fullName;
        this.pan = RandomPan();
        this.pin = RandomPin();
        this.cvc = RandomCvc();
        this.expirationDate = DateTime.Now;
        this.Balance = balance;
        
    }
    public BankCard(string bankName, string fullName,string pan,string pin,string cvc,decimal balance)
    {
        this.Bankname = bankName;
        this.Fullname = fullName;
        this.Pan = pan;
        this.Pin = pin;
        this.Cvc = cvc;
        this.expirationDate = DateTime.Now;
        this.Balance = balance;
        
    }

}
