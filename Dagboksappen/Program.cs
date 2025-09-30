
using System.ComponentModel;

namespace Dagboksappen
{
    internal class Program
    {

        private static List<DiaryEntry> entries = new List<DiaryEntry>();
        private static Dictionary<DateTime,DiaryEntry> entriesDict = new Dictionary<DateTime, DiaryEntry>();
        private static DiaryService diaryService = new DiaryService();


        static void Main(string[] args)
        {
            Console.WriteLine("Välkomen till DagboksAppen");


            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine() ;

                switch (choice) 
                {
                case "1":
                        AddEntry();
                        break;
                case "2":
                        ListEntries();
                        break;
                case "3":
                        SearchEntryStub();
                        break;
                case "4":
                        SaveToFileStub();
                        break;
                case "5":
                        LoadFromFileStub();
                        break;
                case "6":
                        UpdateEntryStub();
                        break;
                case "7":
                        DeleteEntryStub();
                        break;
                case "8":
                        Console.WriteLine("Hej då!");
                        return;
                default:
                        Console.WriteLine("Ogiltig val Försök igen.");
                        break;

                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        static void ShowMenu()
        {
            Console.WriteLine("-----Meny-----");
            Console.WriteLine("1. Skriv ny antecking");
            Console.WriteLine("2. Lista alla anteckningar");
            Console.WriteLine("3. Sök anteckning på datum");
            Console.WriteLine("4. Spara till fil");
            Console.WriteLine("5. Ladda från fil");
            Console.WriteLine("6. Uppdatera anteckning");
            Console.WriteLine("7. Ta bort anteckning");
            Console.WriteLine("8. Avsluta");
            Console.Write("Välj ett alternativ (1-8): ");
        }




        static void AddEntry()
        {
            Console.WriteLine("Lägg till anteckning");

            DateTime date = GetValidDate();
            string text = GetValidText();

            var newEntry = new DiaryEntry { Date = date.Date, Text = text };
            entries.Add(newEntry);
            entriesDict[date.Date] = newEntry;

            Console.WriteLine("Anteckning sparaad.");
        }

        static DateTime GetValidDate()
        {
            
            while (true)
            {
                Console.Write("Ange datum (YYYY-MM-DD): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out DateTime date))
                {
                    return date;
                }
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
            }
        }


        static string GetValidText()
        {
            while (true)
            {
                Console.Write("Ange anteckningstext ");
                string text = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }
                Console.WriteLine("Anteckningen får inte vara tom, försök igen");
            }
        }

        static void ListEntries()
        {
            Console.WriteLine("Lista anteckningar");

            if (!entries.Any())
            {
                Console.WriteLine("Inga anteckningar hittades");
                return;
            }

            foreach (var entry in entries.OrderBy(e => e.Date))
            {
                Console.WriteLine($"{entry.Date:yyyy-MM-dd}: {entry.Text}");
            }
            Console.WriteLine($"Totalt: {entries.Count} anteckningar");
        }

        static void SearchEntryStub()
        {
            Console.WriteLine("Sök anteckning");
        }

        static void SaveToFileStub()
        {
            Console.WriteLine("Spara till fil");
        }

        static void LoadFromFileStub()
        {
            Console.WriteLine("Läs från fil");
        }

        static void UpdateEntryStub()
        {
            Console.WriteLine("Updatera anteckning");
        }

        static void DeleteEntryStub()
        {
            Console.WriteLine("Ta bort anteckning");
        }
         
    }
}
