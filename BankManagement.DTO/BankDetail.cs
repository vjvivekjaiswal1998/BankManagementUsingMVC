using System;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.DTO
{
    public class BankDetail
    {
      [Required(ErrorMessage = "Please enter the account number")]
   
        public int AccountNumber { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = " AccountType can't be more than 10.")]
        public string AccountType { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength (20)]
        public string NomieeName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Phone]
        [Range(1000000000, 9999999999 ,ErrorMessage = "phoneNumber must be of 10 digits")]
        public string CustomerPhoneNumber { get; set; }

    }
}
