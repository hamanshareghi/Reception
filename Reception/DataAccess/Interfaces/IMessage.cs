using System.Collections.Generic;
using Model.Entities;


namespace DataAccess.Interfaces
{
    public interface IMessage
    {
        List<Message> GetAllMessage();
        Message GetMessageById(int id);
        void AddMessage(Message message);//, IFormFile imgUp);
        void UpdateMessage(Message message);//, IFormFile imgUp);
        void DeleteMessage(Message message);
        bool ExistMessage(int id);
        Message GetFirstMessage();
    }
}
