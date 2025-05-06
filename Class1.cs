using System;

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
            NormalizeTime();
        }
    }

    public byte Minutes
    {
        get { return minutes; }
        set
        {
            minutes = value;
            NormalizeTime();
        }
    }

    private void NormalizeTime()
    {
        while (minutes >= 60)
        {
            hours++;
            minutes -= 60;
        }

        while (minutes < 0)
        {
            hours--;
            minutes += 60;
        }

        while (hours >= 24)
        {
            hours -= 24;
        }

        while (hours < 0)
        {
            hours += 24;
        }
    }

    // Метод для вычитания времени
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

    // Перегрузки
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
        if (time.minutes == 0)
        {
            time.hours--;
            if (time.hours < 0)
            {
                time.hours = 23;
            }
            time.minutes = 59;
        }
        else
        {
            time.minutes--;
        }

        time.NormalizeTime();
        return time;
    }
    
    public static bool operator <(Time time1, Time time2)
    {
        return (int)time1 < (int)time2;
    }
    
    public static bool operator >(Time time1, Time time2)
    {
        return (int)time1 > (int)time2;
    }

    public static explicit operator int(Time time)
    {
        return time.Hours * 60 + time.Minutes;
    }

    public static explicit operator bool(Time time)
    {
        return time.Hours != 0 || time.Minutes != 0;
    }
}
