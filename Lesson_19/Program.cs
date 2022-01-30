using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_19
{
    class Comp
    {
        public int Id { get; set; }
        public string NameComp { get; set; }
        public string TypeProc { get; set; }
        public double FrequencyProc { get; set; }
        public int SizeRAM { get; set; }
        public int SizeROM { get; set; }
        public int SizeVideo { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<Comp> listComp = new List<Comp>()
            {
                new Comp() { Id = 1, NameComp = "Acer", TypeProc = "AMD", FrequencyProc = 2.4, SizeRAM = 32, SizeROM = 512, SizeVideo = 1024, Price = 54000, Quantity = 2 },
                new Comp() { Id = 2, NameComp = "Asus", TypeProc = "Intel", FrequencyProc = 2.1, SizeRAM = 16, SizeROM = 1024, SizeVideo = 2048, Price = 49500, Quantity = 3 },
                new Comp() { Id = 3, NameComp = "MSI", TypeProc = "AMD", FrequencyProc = 3.3, SizeRAM = 32, SizeROM = 2048, SizeVideo = 3072, Price = 98000, Quantity = 1 },
                new Comp() { Id = 4, NameComp = "Lenovo", TypeProc = "Intel", FrequencyProc = 1.8, SizeRAM = 8, SizeROM = 256, SizeVideo = 1024, Price = 24000, Quantity = 10 },
                new Comp() { Id = 5, NameComp = "HP", TypeProc = "AMD", FrequencyProc = 2.6, SizeRAM = 8, SizeROM = 512, SizeVideo = 1024, Price = 36000, Quantity = 15 },
                new Comp() { Id = 6, NameComp = "Apple", TypeProc = "M1", FrequencyProc = 2.4, SizeRAM = 8, SizeROM = 256, SizeVideo = 2048, Price = 89900, Quantity = 7 },
                new Comp() { Id = 7, NameComp = "Samsung", TypeProc = "Intel", FrequencyProc = 2.8, SizeRAM = 16, SizeROM = 1024, SizeVideo = 2048, Price = 61500, Quantity = 30 }
            };
            #region Определить все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.Write("Введите тип процессора(AMD/Intel/M1): ");
            string typeProc = Console.ReadLine();
            List<Comp> proc = (from d in listComp
                               where d.TypeProc == typeProc
                               select d).ToList();
            foreach (Comp c in proc)
            {
                Console.WriteLine($"{c.Id,-2}{c.NameComp,-8}{c.TypeProc,-8}{c.FrequencyProc,-8}{c.SizeRAM,-8}{c.SizeROM,-8}{c.SizeVideo,-8}{c.Price,-8}{c.Quantity,-8}");
            }
            Console.WriteLine();
            #endregion
            #region Определить все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя
            Console.Write("Введите объем ОЗУ(8/16/32): ");
            int sizeRAM = Convert.ToInt32(Console.ReadLine());
            List<Comp> ram = (from d in listComp
                              where d.SizeRAM >= sizeRAM
                              select d).ToList();
            foreach (Comp c in ram)
            {
                Console.WriteLine($"{c.Id,-2}{c.NameComp,-8}{c.TypeProc,-8}{c.FrequencyProc,-8}{c.SizeRAM,-8}{c.SizeROM,-8}{c.SizeVideo,-8}{c.Price,-8}{c.Quantity,-8}");
            }
            Console.WriteLine();
            #endregion
            #region Вывести весь список, отсортированный по увеличению стоимости;
            Console.WriteLine("Список компьютеров отсортированных по увеличению стоимости");
            List<Comp> order = (from d in listComp
                                orderby d.Price
                                select d).ToList();
            foreach (Comp c in order)
            {
                Console.WriteLine($"{c.Id,-2}{c.NameComp,-8}{c.TypeProc,-8}{c.FrequencyProc,-8}{c.SizeRAM,-8}{c.SizeROM,-8}{c.SizeVideo,-8}{c.Price,-8}{c.Quantity,-8}");
            }
            Console.WriteLine();
            #endregion
            #region Вывести весь список, сгруппированный по типу процессора
            Console.WriteLine("Группировка компьютеров по типу процессора:");
            var group = (from d in listComp
                         group d by d.TypeProc);
            foreach (IGrouping<string, Comp> g in group)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine($"{t.Id,-2}{t.NameComp,-8}{t.TypeProc,-8}{t.FrequencyProc,-8}{t.SizeRAM,-8}{t.SizeROM,-8}{t.SizeVideo,-8}{t.Price,-8}{t.Quantity,-8}");
                Console.WriteLine();
            }
            #endregion
            #region Найти самый дорогой и самый бюджетный компьютер
            Console.WriteLine("Самый дорогой компьютер:");
            var max = (from d in listComp
                       select d.Price).Max();
            Console.WriteLine($"{max}");
            Console.WriteLine();
            Console.WriteLine("Самый бюджетный компьютер:");
            var min = (from d in listComp
                       select d.Price).Min();
            Console.WriteLine($"{min}");
            Console.WriteLine();
            #endregion
            #region Есть ли хотя бы один компьютер в количестве не менее 30 штук?
            Console.WriteLine("Есть ли хотя бы один компьютер в количестве не менее 30 штук?");
            bool quantity = (from d in listComp
                            where d.Quantity >= 30
                            select d).Any();
            if (quantity)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }
            #endregion
            Console.ReadKey();
        }
    }
}
