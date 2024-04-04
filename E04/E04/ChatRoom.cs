using System;
using System.Collections.Generic;
using System.Linq;

public class ChatRoom
{
    public string Name { get; set; }
    public List<Contact> Users { get; set; }
    public List<Message> Messages { get; set; }

    public ChatRoom(string name)
    {
        Name = name;
        Users = new List<Contact>();
        Messages = new List<Message>();
    }

    public void AddUser(Contact user) => Users.Add(user);

    public void AddMessage(Message message) => Messages.Add(message);

    public (string, int, string) GetRoomStatistics()
    {
        var userWithMostMessages = Users
            .Select(u => new
            {
                User = u.Name,
                MessageCount = Messages.Count(m => m.Author == u.Name),
                ShortestMessage = Messages.Where(m => m.Author == u.Name).OrderBy(m => m.Text.Length).FirstOrDefault()?.Text
            })
            .OrderByDescending(u => u.MessageCount)
            .FirstOrDefault();

        return (userWithMostMessages?.User ?? "", userWithMostMessages?.MessageCount ?? 0, userWithMostMessages?.ShortestMessage ?? "");
    }
}