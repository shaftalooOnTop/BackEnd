namespace Resturant_managment.Models
{
    public class ReserveTable
    {
        public int trCode { get; set; }
        public virtual List<resrvetime> time { get; set; }


    }
}
