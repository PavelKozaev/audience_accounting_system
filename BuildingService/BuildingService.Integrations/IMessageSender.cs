namespace BuildingService.Integrations
{
    public interface IMessageSender
    {
        Task SendMessageAsync<T>(T message) where T : class;
    }
}
