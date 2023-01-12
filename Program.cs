using Akka.Actor;
using Akka.Actor.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.netBankExplam
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("my-system");

            var auditorActor = system.ActorOf<AuditorActor>("auditor");
            var accountActors = new List<IActorRef> {
            system.ActorOf<AccountActor>(new AccountActor(1, 1000)),
            system.ActorOf<AccountActor>(new AccountActor(2, 2000)),
            system.ActorOf<AccountActor>(new AccountActor(3, 3000))
        };
            var routerActor = system.ActorOf<RouterActor>(new RouterActor(accountActors));
            var supervisorActor = system.ActorOf<SupervisorActor>(new SupervisorActor(routerActor));
            var bankActor = system.ActorOf<BankActor>(new BankActor(routerActor, auditorActor));

            bankActor.Tell(new Transaction { AccountNumber = 1, Amount = -500 });
            bankActor.Tell(new Transaction { AccountNumber = 2, Amount = 500 });
            bankActor.Tell(new Transaction { AccountNumber = 3, Amount = -2000 });

            Console.ReadLine();
        }
    }
}
