using System.ComponentModel.DataAnnotations;

namespace Exam51.Models
{
    public class Form
    {

        [Required(ErrorMessage = "This Field is Required")]
        
        public string To { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string From { get; set; }


        [Required(ErrorMessage = "Subject is Required")]


        public string Subject { get; set; }

        [Required(ErrorMessage = "Body is Required")]
        public string Body { get; set; }

    }
}
