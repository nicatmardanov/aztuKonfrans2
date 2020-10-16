using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aztuKonfrans2.Classes
{
    public class PaperDeadline
    {
        public static int deadlineValue
        {
            get
            {
                DateTime deadline = new DateTime(2019, 11, 20, 21, 0, 0);
                return deadline.CompareTo(DateTime.UtcNow);
            }
        }
    }
}