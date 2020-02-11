using BankManagement.BLL;
using BankManagement.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace BankManagement
{
    public class BankManagement
    {
        private readonly IBank _bank;
       
        //  Bank bank = new Bank();
        public BankManagement()
        {
            _bank = Getbank();

        }


        // Resolve Depedency
        private IServiceProvider ResolveDependency()
        {
            var serviceProvider = new ServiceCollection()
               .AddTransient<ISqlhelper, Sqlhelper>()
                .AddTransient<IBankDetailAccess, BankDetailAccess>()
                
             .AddTransient<IBank, Bank>()
            
                .BuildServiceProvider();
            return serviceProvider;
        }

        private IBank Getbank()
        {
            var serviceProvider = ResolveDependency();
            return serviceProvider.GetService<IBank>();

        }




      public static void Main(string[] args)
        {
            BankManagement _bankManagement = new BankManagement();
            _bankManagement.BankProject();
        }



        public void BankProject()
        {
            int AcceptNumber;
            do
            {
                Console.WriteLine(StringUtilityMain.menu);
                Console.WriteLine(StringUtilityMain.select);
                Console.WriteLine(StringUtilityMain.insert);
                Console.WriteLine(StringUtilityMain.update);
                Console.WriteLine(StringUtilityMain.delete);
                Console.WriteLine(StringUtilityMain.selectAll);
                Console.WriteLine(StringUtilityMain.exit);
                AcceptNumber = int.Parse(Console.ReadLine());
                //Take A Choice From User, What Task Needs To Be Performed.
                switch (AcceptNumber)
                {
                    case 1:
                        //It Receives Only Single Bank Account Detail.

                        _bank.GetSingleBankAccountDetail();

                        break;
                    case 2:
                        //It Add A Account In A BankDataBase.
                        _bank.AddBankDetail();
                        break;
                    case 3:
                        //It Update The AccountDetail in Bank.
                        _bank.UpdatebankDetail();
                        break;
                    case 4:
                        //It Delete The Account Details From Bank.
                        _bank.DeleteBankDetail();
                        break;
                    case 5:
                        //It Displays All The Account Details From Bank.
                        _bank.ShowAllBankDetail();
                        break;
                        //It will exit the program.
                    case 6:
                        break;
                    default:
                        Console.WriteLine(StringUtilityMain.option);
                        break;
                }
            }
            while (AcceptNumber != 6);
        }
        
    }
}

