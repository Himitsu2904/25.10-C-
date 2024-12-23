using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class YearException : ApplicationException
    {
        public YearException(): base("Некорректный год.") { }
    }

    public class MonthException: ApplicationException
    {
        public MonthException() : base("Некорректный месяц.") { }
    }

    public class DayException: ApplicationException
    {
        public DayException() : base("Некорректное число месяца.") { }
    }

    internal class Date
    {
        private int year;
        private int month;
        private int day;
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 1)
                {
                    throw new YearException();
                }
                year = value;
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new MonthException();
                }
                month = value;
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                if (value < 1 || value > 31)
                {
                    throw new DayException();
                }
                day = value;
            }
        }

        public Date()
        {
            year = 1970;
            month = 1;
            day = 1;
        }
        public Date(int y, int m, int d)
        {
            if (y < 1)
            {
                throw new YearException();
            }
            if (m < 1 || m > 12)
            {
                throw new MonthException();
            }
            if (d < 1 || d > 31)
            {
                throw new DayException();
            }
            year = y;
            month = m;
            day = d;
        }
        public long DifferenceBetween(int y, int m, int d)
        {
            long currentDays = (long)(year * 365 + month * 30.5 + day);
            long inputedDays = (long)(y * 365 + m * 30.5 + d);
            if (inputedDays > currentDays)
            {
                return inputedDays - currentDays;
            }
            else return currentDays - inputedDays;
        }
        public Date ChangeDate(int d)
        {
            long dateInDays = (long)(year * 365 + month * 30.5 + day);
            dateInDays += d;
            year = (int)(dateInDays / 365);
            dateInDays -= (long)(year * 365);
            month = (int)(dateInDays / 30.5);
            dateInDays -= (long)(month * 30.5);
            day = (int)(dateInDays);
            return new Date(year, month, day);
        }
        public void ShowDate()
        {
            try
            {
                this.Equals(null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            if (day < 10)
            {
                Console.Write($"0{day}.");
            }
            else Console.Write(day + ".");
            if (month < 10)
            {
                Console.Write($"0{month}.");
            }
            else Console.Write(month + ".");
            Console.Write(year);
        }
    }

    internal class Employee
    {
        private string FIO;
        private string birthday;
        private string phoneNumber;
        private string email;
        private string position;
        private string[] duties = new string[5];

        public Employee() { }

        public void InputData()
        {
            Console.WriteLine("ВВЕДИТЕ ДАННЫЕ ПРО СОТРУДНИКА:");
            Console.Write("ФИО: ");
            FIO = Console.ReadLine();
            Console.Write("Дата рождения: ");
            birthday = Console.ReadLine();
            Console.Write("Номер телефона: ");
            phoneNumber = Console.ReadLine();
            Console.Write("email: ");
            email = Console.ReadLine();
            Console.Write("Должность: ");
            position = Console.ReadLine();
            Console.Write("Служебные обязанности (5):");
            for (int i = 0; i < duties.Length; i++)
            {
                duties[i] = Console.ReadLine();
            }
        }

        public void ShowData()
        {
            Console.WriteLine("---ИНФОРМАЦИЯ О СОТРУДНИКЕ---");
            Console.WriteLine($"ФИО: {FIO}\nДата рождения: {birthday}\nНомер Телефона: {phoneNumber}");
            Console.WriteLine($"email: {email}\nДолжность: {position}");
            Console.WriteLine("Служебные обязанности:");
            foreach (string d in duties)
            {
                Console.WriteLine("> " + d);
            }
        }

        public string GetFIO() => FIO;
        public string GetBirthday() => birthday;
        public string GetPhoneNumber() => phoneNumber;
        public string GetEmail() => position;
        public string GetPosition() => position;
        public string[] GetDuties() => duties;
        public string GetDuties(int index) => duties[index];

        public void SetPhoneNumber(string value) => phoneNumber = value;
        public void SetEmail(string value) => email = value;
        public void SetPosition(string value) => position = value;
        public void SetDuties(string[] value) => duties = value;
        public void SetDuties(int index, string value) => duties[index] = value;
    }

    internal class Plane
    {
        private string name;
        private string production;
        private string type;
        private int year;

        public Plane() { }

        public Plane(string n, string p, string t, int y)
        {
            name = n;
            production = p;
            type = t;
            year = y;
        }

        public void InputData()
        {
            Console.WriteLine("ВВЕДИТЕ ДАННЫЕ ПРО СОТРУДНИКА:");
            Console.Write("Название: ");
            name = Console.ReadLine();
            Console.Write("Производитель: ");
            production = Console.ReadLine();
            Console.Write("Тип: ");
            type = Console.ReadLine();
            Console.Write("Год выпуска: ");
            year = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowData()
        {
            Console.WriteLine("---ИНФОРМАЦИЯ О САМОЛЁТЕ---");
            Console.WriteLine($"Название: {name}\nПроизводитель: {production}\nТип: {type}\nГод выпуска: {year}");
        }

        public string GetName() => name;
        public string GetProduction() => production;
        public string GetPlainType() => type;
        public int GetYear() => year;

        public void SetName(string value) => name = value;
        public void SetProduction(string value) => production = value;
        public void SetPlainType(string value) => type = value;
        public void SetYear(int value) => year = value;
    }
}