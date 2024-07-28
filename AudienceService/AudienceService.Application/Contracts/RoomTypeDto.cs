using System.ComponentModel.DataAnnotations;

namespace AudienceService.Application.Contracts
{
    public enum RoomTypeDto
    {
        [Display(Name = "Лекционная")]
        Lecture,

        [Display(Name = "Для практических занятий")]
        Practical,

        [Display(Name = "Спортивный зал")]
        Gym
    }
}
