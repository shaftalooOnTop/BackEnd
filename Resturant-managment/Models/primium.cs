using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class primium : BaseClass
    {
       public DateTime expiretime  { get; set; }

        public int restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant? Restaurant { get; set; }


        [ForeignKey("PaymentId")]
        public virtual Payment? Payment { get; set; }
        public virtual int PaymentId { get; set; }
    }
}
