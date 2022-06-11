using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class TeamMember : CoreEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string SkypeLink { get; set; }
        public string TelegramLink { get; set; }
        public string LinkedinLink { get; set; }
    }
}