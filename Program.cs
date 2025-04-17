using System;


namespace ConsoleApp2
{ 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---| Тестирование класса Time |---");
            Console.WriteLine(new string('_', 34));

            Console.WriteLine("Введите время 1:");
            byte hours1 = InputValidator.GetValidByte("Часы: ");
            byte minutes1 = InputValidator.GetValidByte("Минуты: ");
            Time time1 = new Time(hours1, minutes1);


            Time time2 = new Time(time1);
            Console.WriteLine($"\nВремя 2 (копия времени 1): {time2}");
            Console.WriteLine(new string('_', 34));

            Console.WriteLine("\nВведите время 3, которое нужно вычесть из времени 1:");
            byte hours3 = InputValidator.GetValidByte("Часы: ");
            byte minutes3 = InputValidator.GetValidByte("Минуты: ");
            Time time3 = new Time(hours3, minutes3);

            Time time4 = time1.SubtractTime(time3);
            Console.WriteLine($"\n{time1} - {time3} = {time4}");

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

            Console.WriteLine(new string('_', 34));
            Console.WriteLine("\nВведите время для преобразования в минуты:");
            byte convertHours = InputValidator.GetValidByte("Часы: ");
            byte convertMinutes = InputValidator.GetValidByte("Минуты: ");
            Time time7 = new Time(convertHours, convertMinutes);
            int totalMinutes = (int)time7;
            Console.WriteLine($"Время {time7} в минутах: {totalMinutes}");

            Time time8 = new Time(0, 0);
            Time time9 = new Time(10, 20);
            Console.WriteLine($"Время {time8} приведено к bool: {(bool)time8}");
            Console.WriteLine($"Время {time9} приведено к bool: {(bool)time9}");
            Console.WriteLine(new string('_', 34));

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

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
