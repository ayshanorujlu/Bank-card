using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_t
{
    public class BankCard
    {
        public BankCard(string bankName, string fullName, string pan, string pin, string cvc, string expireDate, decimal balance)
        {
            this.bankName = bankName;
            this.fullName = fullName;
            this.pan = pan;
            this.pin = pin;
            this.cvc = cvc;
            this.expireDate = expireDate;
            this.balance = balance;

        }
        public string bankName { get; set; }
        public string fullName { get; set; }
        public string pan { get; set; }
        public string pin { get; set; }
        public string cvc { get; set; }
        public string expireDate { get; set; }
        public decimal balance { get; set; }
    }
}
