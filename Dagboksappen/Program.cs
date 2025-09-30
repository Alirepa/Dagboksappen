
namespace Dagboksappen
{
    internal class Program
    {

        private static List<DiaryEntry> entries = new List<DiaryEntry>();
        private static DiaryService diaryService= new DiaryService();
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
                        AddEntryStub();
                        break;
                case "2":
                        ListEntriesStub();
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



         static void DeleteEntryStub()
        {
            Console.WriteLine("Ta bort anteckning");
        }

        private static void UpdateEntryStub()
        {
            Console.WriteLine("Updatera anteckning");
        }

        private static void LoadFromFileStub()
        {
            Console.WriteLine("Läs från fil"); 
        }

        private static void SaveToFileStub()
        {
            Console.WriteLine("Spara till fil");
        }

        private static void SearchEntryStub()
        {
            Console.WriteLine("Sök anteckning");
        }

        private static void ListEntriesStub()
        {
            Console.WriteLine("Lista anteckningar");
        }

        private static void AddEntryStub()
        {
            Console.WriteLine("LÄgg till anteckning");
        }
    }
}
