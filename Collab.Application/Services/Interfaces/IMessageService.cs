using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IMessageService
    {
        // get message by id, create message
        Task<MessageDto> GetMessageByIdAsync(int id);
        Task<MessageDto> CreateMessageAsync(MessageDto messageDto);
    }
}
