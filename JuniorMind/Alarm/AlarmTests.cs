using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*O alarmă poate fi setată să se declanșeze la o anumită oră în una sau în mai multe zile din săptămână.
De exemplu, se poate configura ca alarma să se declanșeze la ora 6 de luni până vineri și să se declanșeze la ora 8 
sâmbătă și duminică.
Scrie o funcție care decide pe baza acestor setări dacă trebuie declanșată alarma într-o anumită zi la o anumită oră.*/
namespace Alarm
{
    [Flags]
    public enum WeekDays
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40 
    }

    public struct Alarm
    {
        public WeekDays day;
        public int hour;
        public Alarm(WeekDays day, int hour)
        {
            this.day = day;
            this.hour = hour;
        }
    }
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void AlarmSetOnSundayMorning()
        {            
            Alarm requestedAlarm = new Alarm(WeekDays.Sunday, 6);
            Alarm[] setAlarms = new Alarm[] { new Alarm(WeekDays.Sunday, 6), new Alarm(WeekDays.Monday, 8) };
            Assert.AreEqual(true, CheckIfAlarmIsSet(requestedAlarm, setAlarms));        
        }

        bool CheckIfAlarmIsSet(Alarm requestedAlarm, Alarm[] setAlarms)
        {
            for (int i = 0; i < setAlarms.Length; i++)
                if (((requestedAlarm.day & setAlarms[i].day ) != 0) && (requestedAlarm.hour == setAlarms[i].hour))
                    return true;
            return false;
           
        }
    }
}
