using System.ComponentModel.DataAnnotations;

namespace RandomRestaraunt.Data.Models
{
    public class Restaraunt
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        [Display(Name = "Used Last")]
        public bool UsedLast { get; set; }
    }
}
