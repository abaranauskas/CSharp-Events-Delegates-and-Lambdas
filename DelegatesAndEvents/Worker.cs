using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class WorkPerformedEventArgs: EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }

    public class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        //jei naudojam kaip generini tada nereikia apsirasyti delegato o tik nurodyti kokio 
        //CustomEventArgs bus EventHandler// viduje realiai sukurs ta pati

        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i+1, workType);
            }
            OnWorkCompleted();
        }
              

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //budas 1
            //if (WorkPerformed!=null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            //budas 2
            //var del = WorkPerformed as WorkPerformedHandler;
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del!=null)
            {
                var args = new WorkPerformedEventArgs(hours, workType);
                del(this, args);
            }
        }


        protected virtual void OnWorkCompleted()
        {
            //budas 1
            //if (WorkCompleted!=null)
            //{
            //    WorkCompleted(this, EventArgs.Emptye);
            //}

            //budas 2
            var args = new EventArgs();
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, args);
                //del(this, EventArgs.Empty);
            }

        }
    }
}
