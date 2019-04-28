using Collab.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> CreateMessageAsync(Message message);
        Task<Message> GetMessageByIdAsync(int id);
        Task<List<Message>> GetMessagesBySenderIdAsync(int id);
        Task<List<Message>> GetMessagesByReceiverIdAsync(int id);
        Task<bool> DeleteMessageByIdAsync(int id);
    }
}
