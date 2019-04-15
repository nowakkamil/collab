using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public bool IsRead { get; set; }
    }
}
