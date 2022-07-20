using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFight
{
    interface IUtils
    {
        public int Attack();
        public bool IsAlive();
        public void BeInjuries(int injuriesSustained);
    }
}
