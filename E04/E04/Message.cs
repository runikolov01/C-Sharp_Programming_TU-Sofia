using System;
using System.Collections.Generic;
using System.Linq;

public class Message
{
    public string Author { get; }
    public string Text { get; }
    public DateTime CreatedAt { get; }
    public bool IsModified { get; set; }

    public Message(string author, string text)
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Text = text ?? throw new ArgumentNullException(nameof(text));
        CreatedAt = DateTime.Now;
        IsModified = false;
    }
}