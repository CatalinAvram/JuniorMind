using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Priority
{
    Low = 1,
    Medium = 2,
    High = 3
}

namespace RepairCenter
{
    public class Car   
    {
        private Priority priority;

        public Car(Priority priority)
        {
            this.priority = priority;
        }

        public Priority Priority
        {
            get { return priority; }
            set { priority = value; }
        }
    }
}
