namespace EAMS.API.DTOs
{
    public class LogsDto
    {
        public string Action { get; set; }
        public int AccommodationId { get; set; }
        public int UserId { get; set; }
        public int? OrganisationId { get; set; }
    }
}