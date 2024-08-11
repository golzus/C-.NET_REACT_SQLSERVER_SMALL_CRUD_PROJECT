using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalRepository.models
{
    public class AdvertisementByVisits:BaseAdvertisement
    {

        [Column]
        public int VisitsSoFar { get; set; }

        [Column]
        public int DesiredVisits { get; set; }
    }
}
