using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class ProcessDate
    {
        public void Process(int x, int y, BizzRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessFunc(int x, int y, Func<int,int,int> del)
        {
            var result = del(x, y);
            Console.WriteLine("Is ProcessFunc "+result);
        }

        //metodas kurio parametras delegatas. tokiu budu net nezinoma ka darys sis metodas su x ir y
        //tai bus nurodoma per delgata
        public void ProcessAction(int x, int y, Action<int,int> actionDel) //metodas kurio parametras delegatas
        {
            actionDel(x, y);
            Console.WriteLine("Action<T> delegate suveike");
        }
    }
}
