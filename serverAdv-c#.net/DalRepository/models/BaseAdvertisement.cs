using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DalRepository.models
{

    public abstract class BaseAdvertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        public bool Status { get; set; }

        [Column]
        public string Path { get; set; }

        [Column]
        public string Location { get; set; }

        [Column]
        public string Email { get; set; }
    }
}
