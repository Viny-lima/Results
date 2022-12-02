using Results.Operations.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results.Notifier.Events
{ 
    public static class NotifierResultEvent
    {
        public delegate void SingIn(int id);
        public static event SingIn SingEvent;

        public static void OnSingIn(int id)
        {
            SingEvent?.Invoke(id);
        }
    }
}
