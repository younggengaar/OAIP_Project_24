using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_24_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        c:
            Console.Write("Введите номер задания:");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        N1();
                    }
                    goto c;
                case 2:
                    {
                        N2();
                    }
                    goto c;
                case 3:
                    {
                        N3();
                    }
                    goto c;
                default:
                    {
                        Console.WriteLine("Неправильный номер задания.");
                    }
                    goto c;
            }
        }
        struct Ученик
        {
            public int ПорядковыйНомер;
            public string ФИО;
            public int ОценкаПо1;
            public int ОценкаПо2;
            public int ОценкаПо3;
        }
        struct Пациент
        {
            public string Фамилия;
            public string Имя;
            public string Отчество;
            public int НомерМедКарты;
            public string Диагноз;
        }
        struct Предмет
        {
            public int ПорядковыйНомер;
            public string Наименование;
            public double Вес;
        }
        public static void N1()
        {
            Console.Write("Введите количество учеников:");
            int N = int.Parse(Console.ReadLine());
            Ученик[] ученики = new Ученик[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите информацию о {i + 1}-м ученике:");
                ученики[i].ПорядковыйНомер = i + 1;

                Console.WriteLine("Введите Ф.И.О.:");
                ученики[i].ФИО = Console.ReadLine();

                Console.WriteLine("Введите оценку по первому предмету:");
                ученики[i].ОценкаПо1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите оценку по второму предмету:");
                ученики[i].ОценкаПо2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите оценку по третьему предмету:");
                ученики[i].ОценкаПо3 = int.Parse(Console.ReadLine());
            }
            int количествоОтличников = 0;
            int количествоХорошистов = 0;
            int количествоТроечников = 0;
            foreach (var ученик in ученики)
            {
                double средняяОценка = (ученик.ОценкаПо1 + ученик.ОценкаПо2 + ученик.ОценкаПо3) / 3;
                if (средняяОценка == 5.0)
                {
                    количествоОтличников++;
                    Console.WriteLine($"Ученик: {ученик.ФИО} - Отличник");
                }
                else if (средняяОценка == 4.0 && средняяОценка <= 4.9)
                {
                    количествоХорошистов++;
                    Console.WriteLine($"Ученик: {ученик.ФИО} - Хорошист");
                }
                else if (средняяОценка == 3.0 && средняяОценка <= 3.9)
                {
                    количествоТроечников++;
                    Console.WriteLine($"Ученик: {ученик.ФИО} - Троечник");
                }
            }
            Console.WriteLine($"Количество отличников: {количествоОтличников}");
            Console.WriteLine($"Количество хорошистов: {количествоХорошистов}");
            Console.WriteLine($"Количество троечников: {количествоТроечников}");
            Console.ReadLine();
        }
        public static void N2()
        {
            Console.Write("Введите количество пациентов:");
            int N = int.Parse(Console.ReadLine());
            Пациент[] пациенты = new Пациент[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите информацию о {i + 1}-м пациенте:");
                Console.WriteLine("Фамилия:");
                пациенты[i].Фамилия = Console.ReadLine();

                Console.WriteLine("Имя:");
                пациенты[i].Имя = Console.ReadLine();

                Console.WriteLine("Отчество:");
                пациенты[i].Отчество = Console.ReadLine();

                Console.WriteLine("Номер медицинской карты:");
                пациенты[i].НомерМедКарты = int.Parse(Console.ReadLine());

                Console.WriteLine("Диагноз:");
                пациенты[i].Диагноз = Console.ReadLine();
            }
            Console.WriteLine("Введите диагноз для поиска:");
            string искомыйДиагноз = Console.ReadLine();
            Console.WriteLine($"Список пациентов с диагнозом \"{искомыйДиагноз}\":");
            foreach (var пациент in пациенты)
            {
                if (пациент.Диагноз == искомыйДиагноз)
                {
                    Console.WriteLine($"Фамилия: {пациент.Фамилия}, Имя: {пациент.Имя}, Отчество: {пациент.Отчество}, Номер медицинской карты: {пациент.НомерМедКарты}");
                }
                else
                {
                    Console.WriteLine("Пациентов с таким диагнозом не найдено.");
                }
            }
            Console.ReadLine();
        }
        public static void N3()
        {
            Console.Write("Введите количество предметов:");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число:");
            }
            Предмет[] предметы = new Предмет[N]; 
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите информацию о {i + 1}-м предмете:");
                предметы[i].ПорядковыйНомер = i + 1;

                Console.WriteLine("Введите наименование:");
                предметы[i].Наименование = Console.ReadLine();

                Console.WriteLine("Введите вес:");
                while (!double.TryParse(Console.ReadLine(), out предметы[i].Вес) || предметы[i].Вес <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите другое число:");
                }
            }
            double суммаВесов = 0;
            foreach (var предмет in предметы)
            {
                суммаВесов += предмет.Вес;
            }
            double среднийВес = суммаВесов / N;
            Console.WriteLine("Информация о предметах, чей вес больше среднего арифметического:");
            foreach (var предмет in предметы)
            {
                if (предмет.Вес > среднийВес)
                {
                    Console.WriteLine($"Порядковый номер: {предмет.ПорядковыйНомер}, Наименование: {предмет.Наименование}, Вес: {предмет.Вес}");
                }
            }
            Console.ReadLine();
        }
    }
}
