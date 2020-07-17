using Cosmos.HAL;
using System;
using Sys = Cosmos.System;
namespace Hardware
{
    public class CosmosTime
    {
        byte date;
        byte month;
        byte year;
        byte hour;
        byte minute;
        public byte second { get; set; }

        public CosmosTime()
        {
            date = Cosmos.HAL.RTC.DayOfTheMonth;
            month = Cosmos.HAL.RTC.Month;
            year = Cosmos.HAL.RTC.Year;
            hour = Cosmos.HAL.RTC.Hour;
            minute = Cosmos.HAL.RTC.Minute;
            second = Cosmos.HAL.RTC.Second;
        }

        public bool timerTick() {
            bool res =(second != Cosmos.HAL.RTC.Second);
            second = Cosmos.HAL.RTC.Second;
            return res;
        }

        public String toString()
        {
            String result = "";
            result = month +  "\\" + date + "\\" + year + " " + hour+ ":" + minute + ":" + second;
            return result;
        }
    }
}



