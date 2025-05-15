using System;

namespace WpfApp1
{
    public class Time
    {
        private byte hours;
        private byte minutes;

        public Time()
        {
            this.hours = 0;
            this.minutes = 0;
        }

        public Time(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            NormalizeTime();
        }

        public Time(Time other)
        {
            this.hours = other.hours;
            this.minutes = other.minutes;
        }

        public byte Hours
        {
            get { return hours; }
            set
            {
                hours = value;
            }
        }

        public byte Minutes
        {
            get { return minutes; }
            set
            {
                minutes = value;
            }
        }

        private void Normalize__()
        {

            while (minutes >= 60)
            {
                hours--;
                minutes += 60;
            }

            while (hours >= 24)
            {
                hours += 24;
            }
        }

        private void NormalizeTime()
        {
            while (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }

            while (hours >= 24)
            {
                hours -= 24;
            }

        }

        public Time SubtractTime(Time other)
        {
            int totalMinutes1 = this.hours * 60 + this.minutes;
            int totalMinutes2 = other.hours * 60 + other.minutes;
            int difference = totalMinutes1 - totalMinutes2;

            if (difference < 0)
            {
                difference = (24 * 60) + difference;
            }

            byte newHours = (byte)(difference / 60);
            byte newMinutes = (byte)(difference % 60);

            return new Time(newHours, newMinutes);
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        public static Time operator ++(Time time)
        {
            time.Minutes++;
            time.NormalizeTime();
            return time;
        }

        public static Time operator --(Time time)
        {
            time.Minutes--;
            time.Normalize__();
            return time;
        }

        public static bool operator <(Time time1, Time time2)
        {
            int totalMinutes1 = time1.Hours * 60 + time1.Minutes;
            int totalMinutes2 = time2.Hours * 60 + time2.Minutes;
            return totalMinutes1 < totalMinutes2;
        }

        public static bool operator >(Time time1, Time time2)
        {
            int totalMinutes1 = time1.Hours * 60 + time1.Minutes;
            int totalMinutes2 = time2.Hours * 60 + time2.Minutes;
            return totalMinutes1 > totalMinutes2;
        }

        public static explicit operator int(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        public static explicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0;
        }

        public void SubstructTime(int hour, int minute)
        {
            throw new NotImplementedException();
        }
    }
}
