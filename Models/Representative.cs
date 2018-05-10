using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PublishingContractManager.Models
{
    public class Representative
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
    }
}