namespace iRental.ViewModel.ViewModels
{
    public class AdvertListResponse
    {
        public string Id { get; set; }
        public string MainPhotoUrl { get; set; }
        public bool IsFavorite { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public float Rating { get; set; }
        public int CountRated { get; set; }
        public int CountBeds { get; set; }
        public int CountRooms { get; set; }
        public int CountBathrooms { get; set; }
    }
}
