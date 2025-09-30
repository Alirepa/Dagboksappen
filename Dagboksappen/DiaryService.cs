using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dagboksappen
{
    public class DiaryService
    {
        private const string DataFile = "diary.json";
        
        public void SaveEntries (List<DiaryEntry> entries)
        {
            try 
            { 
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(DataFile, json);
                Console.WriteLine("Anteckningar sparade!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid sparande {ex.Message}");
            }
        }

        public List<DiaryEntry> LoadEntries()
        {
            try 
            { 
                if (!File.Exists(DataFile))
                {
                    Console.WriteLine("Ingen sparad anteckningar hittades.");
                    return new List<DiaryEntry>();
                }
                string json = File.ReadAllText(DataFile);
                var entries = JsonSerializer.Deserialize<List<DiaryEntry>>(json);

                if (entries == null)
                {
                    Console.WriteLine("Inga anteckningar hittades i filen.");
                    return new List<DiaryEntry>();
                }
                Console.WriteLine($"Laddade {entries.Count} anteckningar från fil");
                return entries;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Ingen sparad fil hittades, skapar tom lista ");
                return new List<DiaryEntry>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Fel i fillformat: {ex.Message} skapar tom lista");
                return new List<DiaryEntry>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett oväntad fel uppstod vid insläsning {ex.Message}");
                return new List<DiaryEntry>();
            }
        }
    }
}
