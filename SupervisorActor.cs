using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    public class SupervisorActor : ReceiveActor
    {
        private readonly IActorRef _accountActor;

        public SupervisorActor(IActorRef accountActor)
        {
            _accountActor = accountActor;
            Receive<Failure>(failure =>
            {
                if (failure.Child.Equals(_accountActor))
                {
                    Console.WriteLine("Restarting AccountActor...");
                    _accountActor.Tell(PoisonPill.Instance);
                    Context.Watch(_accountActor);
                    var newAccountActor = Context.ActorOf<AccountActor>("account");
                    _accountActor = newAccountActor;
                }
            });
        }
    }
}
