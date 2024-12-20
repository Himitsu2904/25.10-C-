using System;
using System.Security.Cryptography;
using System.Text;
using Class;

class Program
{
    #region Функции для шифра Цезаря
    static string Encrypt(string str, int shift = 3)
    {
        StringBuilder newStr = new StringBuilder();
        newStr.Append(str);
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                if (char.IsUpper(str[i]))
                {
                    newStr[i] = char.ToLower(newStr[i]);
                }
                newStr[i] += (char)shift;
                if (newStr[i] > 'z')
                {
                    newStr[i] -= (char)26;
                }
                else if (newStr[i] < 'a')
                {
                    newStr[i] += (char)26;
                }
                if (char.IsUpper(str[i]))
                {
                    newStr[i] = char.ToUpper(newStr[i]);
                }
            }
        }
        str = newStr.ToString();
        return str;
    }
    static string Decrypt(string str, int shift = 3)
    {
        return Encrypt(str, 26 - shift);
    }

    static string SlavicEncrypt(string str, int shift = 3)
    {
        StringBuilder newStr = new StringBuilder();
        newStr.Append(str);
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                if (char.IsUpper(str[i]))
                {
                    newStr[i] = char.ToLower(newStr[i]);
                }
                newStr[i] += (char)shift;
                if (newStr[i] > 'я')
                {
                    newStr[i] -= (char)33;
                }
                else if (newStr[i] < 'а')
                {
                    newStr[i] += (char)33;
                }
                if (char.IsUpper(str[i]))
                {
                    newStr[i] = char.ToUpper(newStr[i]);
                }
            }
        }
        str = newStr.ToString();
        return str;
    }
    static string SlavicDecrypt(string str, int shift = 3)
    {
        return SlavicEncrypt(str, 33 - shift);
    }
    #endregion

    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        #region 3. Шифр Цезаря
        Console.WriteLine("What is the language of your message?");
        Console.WriteLine("a) English\t b)Ukrainian/Russian");
        char lang = Convert.ToChar(Console.ReadLine());
        Console.Write("Enter string: ");
        string str = Console.ReadLine();
        if (lang == 'a')
        {
            str = Encrypt(str);
            Console.WriteLine("Encrypted sentence: " + str);
            str = Decrypt(str);
        }
        else if (lang == 'b')
        {
            str = SlavicEncrypt(str);
            Console.WriteLine("Encrypted sentence: " + str);
            str = SlavicDecrypt(str);
        }
        Console.WriteLine("Decrypted sentence: " + str);
        #endregion

        #region 5. Подсчет введеного арифметического выражения
        str = null;
        Console.Write("Enter arithmethic problem: ");
        str = Console.ReadLine();
        string[] problemElements = str.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        double result = Convert.ToDouble(problemElements[0]);
        for (int i = 1; i < problemElements.Length; i+=2)
        {
            if (problemElements[i] == "+")
            {
                result += Convert.ToDouble(problemElements[i + 1]);
            }
            else if (problemElements[i] == "-")
            {
                result -= Convert.ToDouble(problemElements[i + 1]);
            }
        }
        Console.WriteLine("Calculation result = " + result);
        #endregion

        #region 6. Замена первой буквы на верхний регистр
        str = null;
        Console.WriteLine("Enter text:");
        str = Console.ReadLine();
        string[] sentences = str.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        StringBuilder temp = new StringBuilder();
        str = null;
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = sentences[i].TrimStart();
            temp.Append(sentences[i]);
            temp[0] = char.ToUpper(temp[0]);
            sentences[i] = temp.ToString();
            str += (sentences[i] + ". ");
            temp.Clear();
        }
        Console.WriteLine(str);
        #endregion

        #region 7. Проверка на недопустимые слова
        str = null;
        str = @"
        To be, or not to be, that is the question,
        Whether 'tis nobler in the mind to suffer
        The slings and arrows of outrageous fortune,
        Or to take arms against a sea of troubles,
        And by opposing end them? To die: to sleep;
        No more; and by a sleep to say we end
        The heart-ache and the thousand natural shocks
        That flesh is heir to, 'tis a consummation
        Devoutly to be wish'd. To die, to sleep";
        Console.WriteLine(str);
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Which word will be banned? ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        string banned = Console.ReadLine();
        int length = banned.Length;
        string[] words = str.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        temp.Clear();
        for (int j = 0; j < length; j++)
        {
            temp.Append('*');
        }
        for (int i = 0; i < words.Length; i++)
        {
            if ( !(words[i].Contains(' ')) )
            {
                if (words[i] == banned)
                {
                    words[i] = temp.ToString();
                }
            }
        }
        temp.Clear();
        for (int i = 0; i < words.Length; i++)
        {
            temp.Append(words[i] + " ");
        }
        str = null;
        str = temp.ToString();
        Console.WriteLine("Censored text:" + str);
        #endregion
        Console.WriteLine();
        
        #region Демонстрация класса Date
        //try
        //{
        //    Date date = new Date(2022, 7, 5);
        //}
        //catch(Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
        //date.ShowDate();
        //Console.WriteLine();
        
        //Console.Write("Changed date: ");
        //date.ChangeDate(47);
        //date.ShowDate();
        //Console.WriteLine();

        //Console.Write("Difference betweeen 12.11.2022 and ");
        //date.ShowDate();
        //Console.WriteLine(" = " + date.DifferenceBetween(2022, 11, 12));
        //Console.WriteLine();
        #endregion

        #region Демонстрация класса Employee
        Employee employee = new Employee();
        employee.InputData();
        employee.ShowData();
        Console.WriteLine();
        #endregion

        #region Демонстрация класса Plane
        Plane plane = new Plane();
        plane.InputData();
        plane.ShowData();
        #endregion
    }
}