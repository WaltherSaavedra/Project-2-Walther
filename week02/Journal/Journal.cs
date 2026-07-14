using System;
using System.Collections.Generic;
using System.IO;
 
class Journal
{
    private List<string> _Questionnaire = new List<string>();
    private List<Entry> _entries = new List<Entry>();
    private Random _randomGenerator = new Random();
    private int _lastPromptIndex = -1;
 
    public Journal()
    {
        _Questionnaire.Add("Who was the most interesting person I interacted with today?");
        _Questionnaire.Add("What was the best part of my day tell me?");
        _Questionnaire.Add("How did I see the hand of the Lord in my life today?");
        _Questionnaire.Add("What was the strongest emotion I felt today?");
        _Questionnaire.Add("If I had one thing I could do over today, what would it be?");
    }
 
    public void WriteNewEntry()
    {
        int index = _randomGenerator.Next(_Questionnaire.Count);
 
        
        while (_Questionnaire.Count > 1 && index == _lastPromptIndex)
        {
            index = _randomGenerator.Next(_Questionnaire.Count);
        }
        _lastPromptIndex = index;
 
        string prompt = _Questionnaire[index];
 
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
 
        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
    }
 
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
 
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save the journal: {ex.Message}");
        }
    }
 
    public void LoadFromFile(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Entry> loadedEntries = new List<Entry>();
 
            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");
                if (parts.Length < 3)
                {
                    continue;
                }
 
                string date = parts[0];
                string prompt = parts[1];
                string entryText = parts[2];
 
                loadedEntries.Add(new Entry(date, prompt, entryText));
            }
 
            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename}.");
        }
        catch (FileNotFoundException)
        {
        Console.WriteLine($"Could not find the file '{filename}'.");
        }
        catch (Exception ex)
        {
        Console.WriteLine($"Could not load the journal: {ex.Message}");
        }
    }
}
