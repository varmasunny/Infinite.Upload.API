using System.ComponentModel.DataAnnotations;

namespace Infinite.Upload.API.Models
{
    public class UploadImage
    {
      
            public int Id { get; set; }
            [Required]
            public string ImageUrl { get; set; }
            public string ImageName { get; set; }
           
     
        
    }
}
