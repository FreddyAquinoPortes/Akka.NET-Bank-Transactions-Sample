using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    public class AccountActor : ReceiveActor
    {
        private readonly int _accountNumber;
        private int _balance;

        public AccountActor(int accountNumber, int initialBalance)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;

            Receive<Transaction>(transaction =>
            {
                if (transaction.AccountNumber != _accountNumber) return;
                if (transaction.Amount > _balance)
                {
                    Sender.Tell(new InsufficientFunds());
                    return;
                }

                _balance += transaction.Amount;
                Sender.Tell(new SuccessfulTransaction());
            });
        }
    }
}
