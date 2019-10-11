﻿namespace iRental.ViewModel.ViewModels
{
    public class AdvertItemResponse
    {
        public string Id { get; set; }
        public string[] PhotosUrl { get; set; }
        public bool IsFavorite { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public int CountBeds { get; set; }
        public int CountRooms { get; set; }
        public int CountBathrooms { get; set; }
        public int Area { get; set; }

        public AdvertOwner Owner { get; set; }

        public AdvertItemResponse()
        {
            Owner = new AdvertOwner();
        }
    }

    public class AdvertOwner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public float Rating { get; set; }
        public float CountRated { get; set; }
    }
}
