using System.ComponentModel.DataAnnotations;

namespace identity.Models.Data
{
    public class Configurations
    {
        [Key]
        public int ConfigurationID { get; set; }
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
