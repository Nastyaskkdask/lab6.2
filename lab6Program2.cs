using System;

namespace QuadraticSolver
{
    public class QuadraticEquation
    {
        private double a;
        private double b;
        private double c;

        public double A
        {
            get => a;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Коэффициент 'a' не может быть равен 0.");
                a = value;
            }
        }

        public double B
        {
            get => b;
            set => b = value;
        }

        public double C
        {
            get => c;
            set => c = value;
        }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double[] CalculateRoots()
        {
            double d = b * b - 4 * a * c;
            if (d > 0)
            {
                double root1 = (-b + Math.Sqrt(d)) / (2 * a);
                double root2 = (-b - Math.Sqrt(d)) / (2 * a);
                return new double[] { root1, root2 };
            }
            else if (d == 0)
            {
                double root = -b / (2 * a);
                return new double[] { root };
            }
            else
            {
                return new double[0]; // Нет действительных корней
            }
        }

        public override string ToString()
        {
            return $"Уравнение: {a}x^2 + {b}x + {c} = 0";
        }

        // Перегрузка унарного оператора ++
        public static QuadraticEquation operator ++(QuadraticEquation eq)
        {
            return new QuadraticEquation(eq.A + 1, eq.B + 1, eq.C + 1);
        }

        // Перегрузка унарного оператора --
        public static QuadraticEquation operator --(QuadraticEquation eq)
        {
            return new QuadraticEquation(eq.A - 1, eq.B - 1, eq.C - 1);
        }

        // Приведение к double (дискриминант)
        public static implicit operator double(QuadraticEquation eq)
        {
            return eq.B * eq.B - 4 * eq.A * eq.C;
        }

        // Приведение к bool (true, если есть действительные корни)
        public static explicit operator bool(QuadraticEquation eq)
        {
            double d = eq.B * eq.B - 4 * eq.A * eq.C;
            return d >= 0;
        }

        // Перегрузка оператора ==
        public static bool operator ==(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            return eq1.A == eq2.A && eq1.B == eq2.B && eq1.C == eq2.C;
        }

        // Перегрузка оператора !=
        public static bool operator !=(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            return !(eq1 == eq2);
        }

        public override bool Equals(object obj)
        {
            return obj is QuadraticEquation eq && this == eq;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Решение квадратного уравнения вида ax^2 + bx + c = 0");

                double a = ReadDouble("Введите коэффициент a (не 0): ");
                while (a == 0)
                {
                    Console.WriteLine("Ошибка: коэффициент 'a' не может быть 0.");
                    a = ReadDouble("Введите коэффициент a (не 0): ");
                }

                double b = ReadDouble("Введите коэффициент b: ");
                double c = ReadDouble("Введите коэффициент c: ");

                QuadraticEquation eq = new QuadraticEquation(a, b, c);
                Console.WriteLine("\n" + eq);

                // Вывод корней
                double[] roots = eq.CalculateRoots();
                if (roots.Length == 0)
                    Console.WriteLine("Уравнение не имеет действительных корней.");
                else
                {
                    Console.WriteLine("Корни уравнения:");
                    foreach (var r in roots)
                        Console.WriteLine($"x = {r}");
                }

                // Проверка неявного приведения к double (дискриминант)
                double d = eq;
                Console.WriteLine($"Дискриминант: {d}");

                // Проверка явного приведения к bool
                if ((bool)eq)
                    Console.WriteLine("Уравнение имеет действительные корни.");
                else
                    Console.WriteLine("Уравнение не имеет действительных корней.");

                // Проверка ++ и --
                QuadraticEquation eqInc = ++eq;
                QuadraticEquation eqDec = --eq;

                Console.WriteLine($"\nПосле ++ : {eqInc}");
                Console.WriteLine($"После -- : {eqDec}");

                // Сравнение двух уравнений
                QuadraticEquation eq2 = new QuadraticEquation(a, b, c);
                Console.WriteLine($"\neq == eq2: {eq == eq2}");
                Console.WriteLine($"eq != eq2: {eq != eq2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double ReadDouble(string message)
        {
            double value;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Некорректный ввод. Повторите: ");
            }
            return value;
        }
    }
}