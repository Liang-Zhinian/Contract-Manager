using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublishingContractManager.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string EMail { get; set; }

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