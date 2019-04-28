using AutoMapper;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Message> CreateMessageAsync(Message message)
        {
            await _dbContext.AddAsync(message);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return message;
            }

            return null;
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            var message = await _dbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            return message;
        }

        public async Task<List<Message>> GetMessagesByReceiverIdAsync(int id)
        {
            var messages = await _dbContext.Messages
                .Include(r => r.Receiver)
                .Where(m => m.Receiver.Id == id)
                .ToListAsync();

            return messages;
        }

        public async Task<List<Message>> GetMessagesBySenderIdAsync(int id)
        {
            var messages = await _dbContext.Messages
                .Include(s => s.Sender)
                .Where(m => m.Sender.Id == id)
                .ToListAsync();

            return messages;
        }

        public async Task<bool> DeleteMessageByIdAsync(int id)
        {
            var message = await _dbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            if (message == null)
            {
                return false;
            }

            _dbContext.Messages.Remove(message);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
