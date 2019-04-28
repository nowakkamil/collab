using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collab.Web.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;

        public MessageController(
            IMessageService messageService,
            IApplicationUserService applicationUserService,
            IMapper mapper)
        {
            _messageService = messageService ??
                throw new ArgumentNullException(nameof(messageService));
            _applicationUserService = applicationUserService ??
                throw new ArgumentNullException(nameof(applicationUserService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody]MessageDto messageDto)
        {
            var sender = _applicationUserService
                .GetApplicationUserByIdAsync(messageDto.SenderID);

            if (sender == null)
            {
                return BadRequest();
            }

            var receiver = _applicationUserService
                .GetApplicationUserByIdAsync(messageDto.ReceiverID);

            if (receiver == null)
            {
                return BadRequest();
            }

            var message = _mapper.Map<Message>(messageDto);
            message = await _messageService.CreateMessageAsync(message);

            if (message == null)
            {
                return BadRequest();
            }

            messageDto = _mapper.Map<MessageDto>(message);
            return Ok(messageDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _messageService
                .GetMessageByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            var messageDto = _mapper.Map<MessageDto>(message);

            return Ok(messageDto);
        }

        [HttpGet("messages/sender/{id}")]
        public async Task<IActionResult> GetMessagesBySenderId(int id)
        {
            var messages = await _messageService.GetMessagesBySenderIdAsync(id);

            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }

            var messagesDto = _mapper.Map<List<MessageDto>>(messages);
            return Ok(messagesDto);
        }

        [HttpGet("messages/receiver/{id}")]
        public async Task<IActionResult> GetMessagesByReceiverId(int id)
        {
            var messages = await _messageService.GetMessagesByReceiverIdAsync(id);

            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }

            var messagesDto = _mapper.Map<List<MessageDto>>(messages);
            return Ok(messagesDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageById(int id)
        {
            var result = await _messageService.DeleteMessageByIdAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
