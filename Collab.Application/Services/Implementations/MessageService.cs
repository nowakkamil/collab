using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MessageService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MessageDto> CreateMessageAsync(MessageDto messageDto)
        {

            var newMessage = _mapper.Map<Message>(messageDto);
            await _dbContext.AddAsync(newMessage);
            await _dbContext.SaveChangesAsync();

            return messageDto;
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _dbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
    
            return _mapper.Map<MessageDto>(message);
        }
    }
}
