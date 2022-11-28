using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{

    public class resrvetime
    {
        public DateTime ReserveTime { get; set; }
        public virtual ICollection<Table> Tables { get; set; }

       

    }
}
