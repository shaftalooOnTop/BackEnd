using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{

    public class resrvetime
    {
        public DateTime ReserveTime { get; set; }

        public int UserId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("UserId")]
        public virtual UserModel? UserModel { get; set; }

    }
}
