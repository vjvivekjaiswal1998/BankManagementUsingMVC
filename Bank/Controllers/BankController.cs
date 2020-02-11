using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.BLL;
using BankManagement.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class BankController : Controller
    {
        private readonly IBank _bank;
        public BankController(IBank bank)
        {
            _bank = bank;
        }

        public IActionResult Index()
        {
            return View();
        }
        BankDetail bankDetail = new BankDetail();

        [HttpGet]
        public IActionResult ShowAllBankDetail()
        {
            List<BankDetail> BankList = new List<BankDetail>();
            BankList = _bank.ShowAllBankDetail();

            return View(BankList);

        }

        [HttpGet]
        public IActionResult GetBankDetail(int accountNumber)
        {
            
            bankDetail = _bank.GetSingleBankAccountDetail(accountNumber);

            return View(bankDetail);
           
        }
     //[httpGet]
        public IActionResult AddBankDetail(BankDetail bankDetail)
        {   
            _bank.AddBankDetail(bankDetail);       
            return View(bankDetail);
        }
        //[HttpPut]
        public IActionResult UpdateBankDetail(int accountNumber, string CustomerEmail , string CustomerPhoneNumber)
        {
            _bank.UpdatebankDetail(accountNumber , CustomerEmail , CustomerPhoneNumber);
            return View(bankDetail);        
        }
    //    [HttpDelete]
        public IActionResult DeleteBankDetail(int accountNumber)
        {
            _bank.DeleteBankDetail(accountNumber);
            return View(bankDetail);
          
        }
     
    }
}