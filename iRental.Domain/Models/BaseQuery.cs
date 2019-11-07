namespace iRental.Domain.Models
{
    public class BaseQuery
    {
        public int PageSize { get; private set; }
        public int PageNumber { get; private set; }

        public BaseQuery(int pageSize = 1000, int pageNumber = 1)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
