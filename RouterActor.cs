using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    // Actor Router
    public class RouterActor : ReceiveActor
    {
        private readonly List<IActorRef> _accountActors;
        private int _nextIndex;

        public RouterActor(List<IActorRef> accountActors)
        {
            _accountActors = accountActors;
            _nextIndex = 0;

            Receive<Transaction>(transaction =>
            {
                _accountActors[_nextIndex].Tell(transaction);
                _nextIndex = (_nextIndex + 1) % _accountActors.Count;
            });
        }
    }
}
