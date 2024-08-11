using System.ComponentModel.DataAnnotations.Schema;

namespace DTO_Enteties_Common
{
    public class AdvertisementByVisitsDTO
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string Path { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public int VisitsSoFar { get; set; }

        public int DesiredVisits { get; set; }

    }
}
