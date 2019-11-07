using iRental.Domain.Entities.Base;

namespace iRental.Domain.Entities.Images
{
    public interface IImage : IBaseEntity
    {
        string Title { get; set; }
        string Path { get; set; }
        long ParentEntityId { get; set; }
    }
}
