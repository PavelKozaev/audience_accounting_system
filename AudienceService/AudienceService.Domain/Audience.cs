namespace AudienceService.Domain
{
    public class Audience
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; } 
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; }
        public bool IsDeleted { get; set; }  
    }
}
