namespace TicketTracking.Models
{
    public class Bug
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsResolved { get; set; }
        public bool IsDel { get; set; }
        public string Statement { get; set; }

        public Bug()
        {
            Id = string.Empty;
            Name = string.Empty;
            IsResolved = false;
            IsDel = false;
            Statement = string.Empty;
        }

    }

    public class Bug_Create
    {
        public string name { get; set; }
        public string statement { get; set; }

        public Bug_Create() 
        {
            name = "Example";
            statement = "Demo";
        }
    }

    public class Bug_Edit
    {
        public string id { get; set; }
        public string name { get; set; }
        public string statement { get; set; }

        public Bug_Edit()
        {
            id = string.Empty;
            name = String.Empty;
            statement = String.Empty;
        }
        public Bug_Edit(string id, string name, string statement)
        {
            this.id = id;
            this.name = name;
            this.statement = statement;
        }

    }
}
