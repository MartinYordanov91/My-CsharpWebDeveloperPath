namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            if(Inbox.Any(x =>x.Sender == sender))
            {
                Inbox.Remove(Inbox.First(x => x.Sender == sender));
                return true;
            }
            return false;
        }

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox.Clear();
            return count;
        }

        public string GetLongestMessage()
            => Inbox.MaxBy(x => x.Body).ToString();
        public string InboxView()
            => $"Inbox:{Environment.NewLine}{string.Join(Environment.NewLine, Inbox)}";
    }
}