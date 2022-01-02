using System;

namespace PersonalProjectBookLibraryApi.Model
{
    public class Photo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsMain { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
