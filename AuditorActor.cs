using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    // Actor Auditor
    public class AuditorActor : ReceiveActor
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public AuditorActor()
        {
            Receive<Transaction>(transaction => _transactions.Add(transaction));
        }
    }
}
