using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
        // Класс для проверки ввода
        public class InputValidator
    {
        public static byte GetValidByte(string prompt)
        {
            byte number;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                isValid = byte.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("Ошибка: Введите целое число от 0 до 255.");
                }
            } while (!isValid);

            return number;
        }
    }

    public class Time
    {
        private byte hours;
        private byte minutes;

        // Конструктор по умолчанию
        public Time()
        {
            this.hours = 0;
            this.minutes = 0;
        }

        // Конструктор с параметрами
        public Time(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            NormalizeTime();
        }

        // Конструктор копирования
        public Time(Time other)
        {
            this.hours = other.hours;
            this.minutes = other.minutes;
        }

        // Свойства для доступа к полям
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

        // Метод для нормализации времени (приведения к допустимым значениям)
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
                difference = (24 * 60) + difference; // Переход в предыдущие сутки
            }

            byte newHours = (byte)(difference / 60);
            byte newMinutes = (byte)(difference % 60);

            return new Time(newHours, newMinutes);
        }

        // Перегрузка метода ToString()
        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        // Перегрузка унарного оператора ++ (добавление минуты)
        public static Time operator ++(Time time)
        {
            time.Minutes++;
            time.NormalizeTime();
            return time;
        }

        // Перегрузка унарного оператора -- (вычитание минуты)
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

        // Явное приведение типа к int (количество минут)
        public static explicit operator int(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        // Явное приведение типа к bool (true, если не равно нулю)
        public static explicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0;
        }

        // Перегрузка оператора <
        public static bool operator <(Time time1, Time time2)
        {
            return (int)time1 < (int)time2;
        }

        // Перегрузка оператора >
        public static bool operator >(Time time1, Time time2)
        {
            return (int)time1 > (int)time2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ввод времени 1
            Console.WriteLine("Введите время 1:");
            byte hours1 = InputValidator.GetValidByte("Часы: ");
            byte minutes1 = InputValidator.GetValidByte("Минуты: ");
            Time time1 = new Time(hours1, minutes1);

            // Копирование времени 1 во время 2
            Time time2 = new Time(time1);
            Console.WriteLine($"\nВремя 2 (копия времени 1): {time2}");

            // Ввод времени 3
            Console.WriteLine("\nВведите время 3, которое нужно вычесть из времени 1:");
            byte hours3 = InputValidator.GetValidByte("Часы: ");
            byte minutes3 = InputValidator.GetValidByte("Минуты: ");
            Time time3 = new Time(hours3, minutes3);

            // Вычитание времени 3 из времени 1
            Time time4 = time1.SubtractTime(time3);
            Console.WriteLine($"\nВремя 1 ({time1}) - Время 3 ({time3}) = {time4}");

            Console.WriteLine("\nТестирование перегруженных операторов:");
            // ++
            Time time5 = new Time(time1.Hours, time1.Minutes);
            Console.WriteLine($"Начальное время: {time5}");
            time5++;
            Console.WriteLine($"После time++: {time5}");

            // --
            Time time6 = new Time(time1.Hours, time1.Minutes);
            Console.WriteLine($"Начальное время: {time6}");
            time6--;
            Console.WriteLine($"После time--: {time6}");

            // Получаем время для преобразования в минуты
            Console.WriteLine("\nВведите время для преобразования в минуты:");
            byte convertHours = InputValidator.GetValidByte("Часы: ");
            byte convertMinutes = InputValidator.GetValidByte("Минуты: ");
            Time time7 = new Time(convertHours, convertMinutes);
            int totalMinutes = (int)time7;
            Console.WriteLine($"Время {time7} в минутах: {totalMinutes}");

            // Приведение к bool (ввод для проверки не нужен)
            Time time8 = new Time(0, 0);
            Time time9 = new Time(10, 20);
            Console.WriteLine($"Время {time8} приведено к bool: {(bool)time8}");
            Console.WriteLine($"Время {time9} приведено к bool: {(bool)time9}");

            // Получаем время для сравнения
            Console.WriteLine("\nВведите первое время для сравнения:");
            byte compare1Hours = InputValidator.GetValidByte("Часы: ");
            byte compare1Minutes = InputValidator.GetValidByte("Минуты: ");
            Time time10 = new Time(compare1Hours, compare1Minutes);

            Console.WriteLine("Введите второе время для сравнения:");
            byte compare2Hours = InputValidator.GetValidByte("Часы: ");
            byte compare2Minutes = InputValidator.GetValidByte("Минуты: ");
            Time time11 = new Time(compare2Hours, compare2Minutes);

            Console.WriteLine($"Время {time10} < {time11}: {time10 < time11}");
            Console.WriteLine($"Время {time10} > {time11}: {time10 > time11}");

            Console.ReadKey();
        }
    }
}
