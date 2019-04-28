namespace Collab.Application.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public bool IsRead { get; set; }
    }
}
