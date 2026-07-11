using System;

class Entry 
{
    private string _date = "";
    private string _promptText = "";
    private string _entryText = ""; 

    
    public Entry(string prompt, string entryText)
    {
        _promptText = prompt;
        _entryText = entryText;
        _date = DateTime.Now.ToShortDateString();
    }

        public void Display()
    {
        Console.WriteLine($"{_date}: {_promptText}"); 
        Console.WriteLine(_entryText);
        Console.WriteLine(); 
    }
}