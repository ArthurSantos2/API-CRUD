namespace AplicativoAPI.Entities
{
    public class Mastermind
    {
        public Guid Id { get; set; }
        public string NameMastermind { get; set; }
        public string MastermindDescription { get; set; }
        public string PupilId { get; set;}
        public string AreaName { get; set;}
    }
}