using MassTransit;

namespace BuildingService.Integrations
{
    public class MessageSender : IMessageSender
    {
        private readonly IBus _bus;

        public MessageSender(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendMessageAsync<T>(T message) where T : class
        {
            try
            {
                await _bus.Publish(message);
                Console.WriteLine($"Message of type {typeof(T).Name} published successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to publish message: {ex.Message}");
                throw;
            }
        }
    }
}
