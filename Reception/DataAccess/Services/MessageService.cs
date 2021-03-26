using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Data.Context;
using Model.Entities;



namespace DataAccess.Services
{
    public class MessageService : IMessage
    {
        private DataContext _context;

        public MessageService(DataContext context)
        {
            _context = context;
        }
        public List<Message> GetAllMessage()
        {
            return _context.Messages.ToList();
        }

        public Message GetMessageById(int id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            return message;
        }

        public void AddMessage(Message message)
        {

            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {

            _context.Messages.Update(message);
            _context.SaveChanges();
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }

        public bool ExistMessage(int id)
        {
            return _context.Messages.Any(m => m.Id == id);
        }

        public Message GetFirstMessage()
        {
            return _context.Messages
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
        }
    }
}
