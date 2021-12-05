using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.GameEntities
{
    class NullGameEntity : GameEntity
    {
        public override void PrintInfo()
        {
            Console.WriteLine("Tai yra null objektas, su juo neturėtų būti dirbama!");
        }
    }
}
