namespace AplicativoAPI.Entities
{
    public class Pupil
    {
        public Pupil()
        {
            Masterminds = new List<Mastermind>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}
        public List<Mastermind> Masterminds { get; set; }
        public bool IsDeleted { get; set; }
        
        public void Update(string name, string description, DateTime createdDate, DateTime updateDate)
        {
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updateDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
