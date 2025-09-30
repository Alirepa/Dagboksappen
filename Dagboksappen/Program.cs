
using System.ComponentModel;
using System.Security.Permissions;

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
                        SearchEntry();
                        break;
                case "4":
                        SaveToFile();
                        break;
                case "5":
                        LoadFromFile();
                        break;
                case "6":
                        UpdateEntry();
                        break;
                case "7":
                        DeleteEntry();
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

        static void SearchEntry()
        {
            Console.WriteLine("Sök anteckning");

            Console.WriteLine("Ange datum att söka efter (YYYY-MM-DD)");
            string searchDate = Console.ReadLine();

            if (DateTime.TryParse(searchDate, out DateTime searchDateTime))
            {
                var date = searchDateTime.Date;


                //för vg
                if (entriesDict.TryGetValue(date, out DiaryEntry? entry))
                {
                    Console.WriteLine($"Hittade anteckning för {date:yyyy-MM-dd}:");
                    Console.WriteLine($"Text: {entry.Text}");
                }
                else
                {

                   var foundEntries = entries.Where(e => e.Date == date).ToList();
                    if (foundEntries.Any())
                    {
                        Console.WriteLine($"Hittade {foundEntries.Count} anteckning för {date:yyyy-MM-dd}:");

                        foreach (var foundEntry in foundEntries)
                        {
                            Console.WriteLine($"Text: {foundEntry.Text}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ingen anteckning hittades för {date:yyyy-MM-dd}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
            }
        }

        static void SaveToFile()
        {
            if (!entries.Any()) 
            {
                Console.WriteLine("Inga anteckningar att spara");
            }
            diaryService.SaveEntries(entries);
        }

        static void LoadFromFile()
        {
            entries = diaryService.LoadEntries();

            entriesDict.Clear();
            foreach (var entry in entries)
            {
                entriesDict[entry.Date] = entry;
            }   
        }

        static void UpdateEntry()
        {
            Console.WriteLine("Updatera anteckning");

            if (!entries.Any()) 
            {
                Console.WriteLine("Inga anteckningar att uppdatera");
                return;
            }

            Console.Write("Ange datum för anteckningen att uppdatera (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) 
            {
            Console.WriteLine("Ogiltigt datumformat");
                return;
            }

            date = date.Date;

            if (entriesDict.TryGetValue(date, out DiaryEntry? existingEntry)) 
            {
                Console.WriteLine($"Nuvarande anteckning för {date:YYYY-MM-DD}: ");
                Console.WriteLine($"Text: {existingEntry.Text}");
                Console.WriteLine("Ange ny text (lämna tom för att behålla nuvarande): ");
                string newText = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newText)) 
                {
                existingEntry.Text = newText;
                Console.WriteLine("Anteckning uppdaterad.");
                }
                else
                {
                    Console.WriteLine("Ingen ändring gjordes.");
                }
            }
            else 
            {
                Console.WriteLine("Ingen anteckning hittades för det datumet");
                Console.WriteLine("Använd 'Lista alla anteckningar' för att se tillgängliga datum");
            }

        }

        static void DeleteEntry()
        {
            Console.WriteLine("Ta bort anteckning");

            if (!entries.Any()) 
            {
                Console.WriteLine("Inga anteckningar att ta bort");
                return;
            }
            Console.Write("Ange dattum för anteckningen att ta bort (YYYY-MM-DD):  ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Ogiltig datumformat");
                return;
            }
            date = date.Date;
            if (entriesDict.TryGetValue(date, out DiaryEntry? éntryToRemove)) 
            {
            Console.WriteLine("Anteckning som kommer att tas bort: ");
            Console.WriteLine($"Datum {éntryToRemove.Date:yyyy-MM-dd}: ");
            Console.WriteLine($"Text: {éntryToRemove.Text}");
            Console.WriteLine("Är du säker på att du vill ta bort denna anteckning (j/n): ");

            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "j" || confirmation.ToLower() == "ja")  
            {
                    entries.Remove(éntryToRemove);
                    entriesDict.Remove(date);
                    Console.WriteLine("Anteckning borttagen!");
            }
            else
            {
                    Console.WriteLine("Borttagen avbruten");
            }
            }
            else 
            {
                Console.WriteLine("Ingen anteckning hittades för det datumet");
                Console.WriteLine("Använd 'Lista alla anteckningar' för att se tillgängliga datum");
            }
        }
         
    }
}
