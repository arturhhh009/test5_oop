using Lab5_App.Classes;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int variant = 2;


        Console.WriteLine($"Варіант: {variant}");
        Console.WriteLine($"C13 =  {variant % 13}\n");

        try
        {
            Apartment myHome = new Apartment();

            // Прилади
            var lgFridge = new Fridge("Холодильник LG", 250, 0.2, -3);
            var samsungOven = new Oven("Духовка Samsung", 2500, 1.5, "Гриль");
            var macbook = new Computer("MacBook Pro", 95, 0.05, "Apple M2", 16);

            myHome.AddAppliance(lgFridge);
            myHome.AddAppliance(samsungOven);
            myHome.AddAppliance(macbook);

            // Увімкнення деяких приладів
            lgFridge.PlugIn();
            macbook.PlugIn();

            // Перевірка дій
            Console.WriteLine("=========== Всі прилади в квартирі ===========");
            Console.WriteLine(myHome.ShowAllAppliances());

            Console.WriteLine($"\nЗагальна потужність увімкнених приладів: {myHome.CalculateTotalPower()} Вт");

            Console.WriteLine("\n=========== Сортування за потужністю ===========");
            var sortListAppl = myHome.SortByPower();
            Console.WriteLine(string.Join("\n", sortListAppl));

            Console.WriteLine("\n=========== Пошук приладу (Випромунювання: 0.1 - 1.0 мкТл) ===========");
            var found = myHome.FindByRadiationRange(0.1, 1.0);
            found.ForEach(a => Console.WriteLine(a));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }
    }
}