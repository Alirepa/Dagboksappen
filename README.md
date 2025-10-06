# Dagboksappen


Dagboksappen är en enkel konsolapplikation för att hantera dagboksanteckningar. Du kan lägga till, lista, söka, uppdatera, ta bort och spara/ladda anteckningar till/från en fil.

## Hur man kör appen

1. Klona projekt från github https://github.com/Alirepa/Dagboksappen 
2. Öppna projektet i Visual Studio 2022 eller kör via kommandoraden:
(cd Dagboksappen dotnet run --project Dagboksappen)
3. Följ menyn i konsolen för att hantera dina dagboksanteckningar.

## Exempel på I/O
Välkomen till DagboksAppen -----Meny-----
1.	Skriv ny antecking
2.	Lista alla anteckningar
3.	Sök anteckning på datum
4.	Spara till fil
5.	Ladda från fil
6.	Uppdatera anteckning
7.	Ta bort anteckning
8.	Avsluta Välj ett alternativ (1-8): 1 Lägg till anteckning Ange datum (YYYY-MM-DD): 2025-09-30 Ange anteckningstext Hej, detta är min första anteckning! Anteckning sparaad.


## Reflektion

Jag valde att lagra anteckningarna i en `List<DiaryEntry>` för att enkelt kunna iterera och visa alla anteckningar, samt en `Dictionary<DateTime, DiaryEntry>` för snabb åtkomst vid sökning på datum. Detta ger både flexibilitet och effektivitet. För filhantering används JSON-format via `DiaryService`, vilket är både läsbart och enkelt att serialisera/deserialisera i C#. Felhantering sker främst genom att kontrollera användarens inmatning, t.ex. att datum är giltigt och att texten inte är tom. Programmet ger tydliga felmeddelanden och möjliggör nya försök vid felaktig inmatning. Vid filoperationer hanteras tomma listor och misslyckade laddningar med informativa meddelanden. Sammantaget är strukturen enkel och robust för en mindre applikation, och kan enkelt utökas vid behov.