namespace Company.Data
{
    public class Bewoner
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int WoningId { get; set; }
        public Woning Woning { get; set; }
    
    }
}
