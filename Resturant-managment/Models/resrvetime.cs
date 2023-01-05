using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{

    public class resrvetime:BaseClass
    {
        public DateTime ReserveTime { get; set; }
      

       

    }
}
