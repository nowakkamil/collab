using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public bool IsRead { get; set; }
    }
}
