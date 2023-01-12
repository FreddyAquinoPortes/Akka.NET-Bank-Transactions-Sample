using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    public class Failure
    {
        public Failure(IActorRef child)
        {
            Child = child;
        }
        public IActorRef Child { get; }
    }
}
