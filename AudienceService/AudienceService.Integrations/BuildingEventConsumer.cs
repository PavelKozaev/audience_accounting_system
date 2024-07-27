using AudienceService.Application.Contracts;
using AudienceService.Application.Services;
using AudienceService.Integrations.Messages;
using MassTransit;

namespace AudienceService.Integrations
{
    public class BuildingEventConsumer : IConsumer<BuildingEventMessage>
    {        
        private readonly IBuildingService _buildingService;

        public BuildingEventConsumer(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        public async Task Consume(ConsumeContext<BuildingEventMessage> context)
        {
            var message = context.Message;

            switch (message.EventType)
            {
                case "Created":
                    await _buildingService.AddBuildingAsync(new BuildingDto
                    {
                        Id = message.Id,
                        Name = message.Name
                    });
                    break;

                case "Updated":
                    await _buildingService.UpdateBuildingAsync(message.Id, new BuildingDto
                    {
                        Id = message.Id,
                        Name = message.Name
                    });
                    break;

                case "Deleted":
                    await _buildingService.DeleteBuildingAsync(message.Id);
                    break;

                default:                    
                    break;
            }
        }
    }
}
