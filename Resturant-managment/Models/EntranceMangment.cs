
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{
    public class EntranceMangment : BaseClass
    {
        public DateTime? enter { get; set; }
        public DateTime? leave { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("EmployeeId")]
        public int IdentityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]

        public virtual Employee employee { get; set; }


        

    }
}
