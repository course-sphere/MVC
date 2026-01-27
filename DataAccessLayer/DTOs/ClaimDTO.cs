using DataAccessLayer.Entities;

namespace DataAccessLayer.DTOs
{
    public class ClaimDTO
    {
        public Guid UserId { get; set; }
        public Role Role { get; set; }
    }
}
