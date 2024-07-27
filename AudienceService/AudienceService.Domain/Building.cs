namespace AudienceService.Domain
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Audience> Audiences { get; set; }
    }
}
