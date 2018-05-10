using System;
using System.ComponentModel.DataAnnotations;

namespace PublishingContractManager.Models
{
    public class Contract
    {
        public Contract()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        [Range(1000000000000, 9999999999999)]
        public long BookISBN { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CompletionDate { get; set; }
        [Required]
        public decimal FixedPay { get; set; }
        [Required]
        public int SalesForRoyalties { get; set; }
        [Required]
        [Range(0,100)]
        public decimal RoyaltyRate { get; set; }

        public string Notes { get; set; }
        [Required]
        public bool CompanyApproval { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CompanyApprovalDate { get; set; }
        [Required]
        public bool AuthorApproval { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AuthorApprovalDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        [Required]
        [Display(Name ="Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        [Display(Name = "Representative")]
        public int RepresentativeId { get; set; }
        public Representative Representative { get; set; }

    }
}