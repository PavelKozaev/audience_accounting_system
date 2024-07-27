namespace AudienceService.Integrations.Messages
{
    public class BuildingEventMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }
        public string EventType { get; set; }
    }
}
