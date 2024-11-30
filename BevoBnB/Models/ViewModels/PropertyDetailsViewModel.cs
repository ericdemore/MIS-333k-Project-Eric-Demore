using System.Collections.Generic;

namespace BevoBnB.ViewModels
{
    public class PropertyDetailsViewModel
    {
        public int PropertyID { get; set; }
        public int PropertyNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }

    public class ReviewViewModel
    {
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
