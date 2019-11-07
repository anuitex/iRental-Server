using iRental.Domain.Entities.Base;

namespace iRental.Domain.Entities.Items
{
    public interface IAdditionalOptions :IBaseEntity
    {
        string Title { get; set; }
        string Icon { get; set; }
    }
}
