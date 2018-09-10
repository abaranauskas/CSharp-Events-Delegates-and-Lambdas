using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GenerateReport
    }

    public delegate int BizzRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>()
            {
                new Customer() {City="Phoenix", FirstName="John", LastName="Doe", ID=1 },
                new Customer() {City="Phoenix", FirstName="Jane", LastName="Doe", ID=555 },
                new Customer() {City="Seattle", FirstName="Suki", LastName="Pizzoro", ID=3 },
                new Customer() {City="New York City", FirstName="Michelle", LastName="Smith", ID=4 }
            };

            var phxCust = customers
                .Where(c => c.City == "Phoenix" && c.ID<500)
                .OrderBy(c=>c.FirstName);

            foreach (var cust in phxCust)
            {
                Console.WriteLine(cust.FirstName);
            }


            var processData = new ProcessDate();
            //=====================================Func<T, TResult> delegate + Lambdas======================================
            Func<int, int, int> myFunc = (x, y) => x * (x + y);
            Func<int, int, int> myFuncMultiply = (x, y) => x * y;
            processData.ProcessFunc(2, 3, myFunc);
            processData.ProcessFunc(2, 3, myFuncMultiply);

            //=====================================Action<T> delegate + Lambdas======================================
            Action<int, int> myAction = (x, y) => Console.WriteLine($"Is lamda Dalyba: {(double)x/(double)y }");
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine($"Is lamda Daugyba: {x *y }");

            //processData.ProcessAction(4, 2, myAction);
            //processData.ProcessAction(4, 2, myMultiplyAction);

            //=====================================Lambdas======================================
            BizzRulesDelegate delMano = new BizzRulesDelegate((x,y)=> x*x+y*y);
            BizzRulesDelegate delAdd = (x, y) => x + y;  //galima iskart taip
            BizzRulesDelegate delMultiply = (x, y) => x * y;

            
            //processData.Process(2, 3, delMano);
            //processData.Process(2, 3, delAdd);
            //processData.Process(2, 3, delMultiply);



            var worker = new Worker();
            //=====================================Lambdas======================================
            //worker.WorkPerformed += (s, e) => Console.WriteLine($"LAMBDA: Dirbta valandu: {e.Hours}. Tokio darbo: {e.WorkType}");
            //jei norima daugiau neivienos eilutes reikia {}
            //worker.WorkPerformed += (s, e) =>
            //{
            //    Console.WriteLine($"LAMBDA: Dirbta valandu: {e.Hours}. Tokio darbo: {e.WorkType}");
            //    Console.WriteLine($"LAMBDA: Some other value!");
            //};
            //worker.WorkCompleted += (s, e) => Console.WriteLine("LAMBDA: Darbas baigtas");

            //=====================================Eventes======================================
            //budas1 
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed1);
            //worker.WorkCompleted += new EventHandler(Worker_WorkCompleted1);

            //budas2  Delegate inference
            //worker.WorkPerformed += Worker_WorkPerformed1; //stanalone method
            //worker.WorkPerformed += Worker_WorkPerformed2; //pridejimas i ivikation list

            //worker.WorkPerformed += delegate(object sender, WorkPerformedEventArgs e)
            //{
            //    Console.WriteLine($"Dirbta: {e.Hours}");
            //};
            //cia anoniminis metodas pridedamas tiesiai, minusas jo panaudot kitur jau nebegalima
            //retai naudojamas nes yra lambda


            //worker.WorkCompleted += Worker_WorkCompleted1;
            //worker.WorkCompleted += Worker_WorkCompleted2;
            //worker.WorkCompleted -= Worker_WorkCompleted2; //atemimas is ivikation list


            worker.DoWork(3, WorkType.GenerateReport);


            //==================================Delegates=========================================
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerform1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerform2);
            //var del3 = new WorkPerformedHandler(WorkPerform3);

            //del1(5, WorkType.Golf);
            //del2.Invoke(10, WorkType.GenerateReport);
            //DoWork(del2);

            //del1 += del3;
            //del1 += del2;
            //del1 += del3 + del2;  //galima ir taip. labai svarbu eiliskumas kokia eile bus 
            //prideta taip ir perduodama bus

            //del1(6, WorkType.GoToMeeting);

            //Console.WriteLine(del1(5, WorkType.GoToMeeting)); //returnina tik veina Value
            //paskutinio is ideto i vokationlist mano atveju del2. todel returnina 7
        }

       

        private static void Worker_WorkCompleted2(object sender, EventArgs e)
        {
            Console.WriteLine("tikrai tikrai baigtas");
        }

        private static void Worker_WorkCompleted1(object sender, EventArgs e)
        {
            Console.WriteLine("darbas baigtas");
        }

        private static void Worker_WorkPerformed2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"tipas {e.WorkType}, Valandos {e.Hours}");
        }

        private static void Worker_WorkPerformed1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Rasoma is worker_WorkPerformed1. tipas {e.WorkType}, Valandos dirbata: {e.Hours}");
        }


        //===========================================================================
        /*
        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeeting);
            
        }

        static int WorkPerform1(int hours, WorkType workType)
        {
            Console.WriteLine($"Workedperformed1 called! {hours} dirbta si darba: {workType}");
            return hours + 1;
        }

        static int WorkPerform2(int hours, WorkType workType)
        {
            Console.WriteLine($"Workedperformed2 called! {hours} dirbta si darba: {workType}");
            return hours + 2;
        }

        static int WorkPerform3(int hours, WorkType workType)
        {
            Console.WriteLine($"Workedperformed3 called! {hours} dirbta si darba: {workType}");
            return hours + 3;
        }*/
    }
}
