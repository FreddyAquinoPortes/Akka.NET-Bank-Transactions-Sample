using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    // Actor Banco
public class BankActor : ReceiveActor
    {
        private IActorRef _accountActor;
        private IActorRef _auditorActor;

        public BankActor(IActorRef accountActor, IActorRef auditorActor)
        {
            _accountActor = accountActor;
            _auditorActor = auditorActor;

            Receive<Transaction>(transaction =>
            {
                _accountActor.Tell(transaction);
                _auditorActor.Tell(transaction);
            });
        }
    }
}
