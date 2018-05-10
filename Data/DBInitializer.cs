using PublishingContractManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishingContractManager.Data
{
    public class DBInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            if(context.Representatives.Any())
            {
                return;
            }

            var reps = new Representative[]
            {
                new Representative{FirstName="Will",LastName="Sasso",Username="WSasso",Password="W1llIsC00l"},
                new Representative{FirstName="Martin",LastName="VanSmelt",Username="VanSmelt",Password="5mellM3"},
                new Representative{FirstName="Jill",LastName="Shooter",Username="JShooter",Password="ShootinSh00t3r"},
                new Representative{FirstName="Stacy",LastName="Smith",Username="SSmith",Password="Password1"}
            };
            foreach(Representative r in reps)
            {
                context.Representatives.Add(r);
            }
            context.SaveChanges();

            var authors = new Author[]
            {
                new Author{FirstName="Jason",LastName="Nobody",Telephone="(543)755-1234",EMail="JNobody@gmail.com"},
                new Author{FirstName="Sharon",LastName="Somebody",Telephone="(333)932-6633",EMail="SharonSAuthor@gmail.com"},
                new Author{FirstName="Barbara",LastName="Stills",Telephone="(976)365-1884",EMail="BStills@gmail.com"},
                new Author{FirstName="Matthew",LastName="Corey",Telephone="(345)222-4378",EMail="MCorey@gmail.com"},
                new Author{FirstName="Carmilla",LastName="Fentez",Telephone="(735)277-6388",EMail="CFentez@gmail.com"}
            };
            foreach(Author a in authors)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

            var contracts = new Contract[]
            {
                new Contract{AuthorId=1,RepresentativeId=1,BookTitle="The Bad Book",BookISBN=1423586432645,PageCount=557,CompletionDate=DateTime.Parse("2018-07-22"),FixedPay=750.50M,SalesForRoyalties=500,RoyaltyRate=4.4M,Notes="Sell on Amazon only.",CompanyApproval=true,CompanyApprovalDate=DateTime.Parse("2018-04-21"), AuthorApproval=true,AuthorApprovalDate=DateTime.Parse("2018-04-23"), CreationDate=DateTime.Parse("2018-04-18") },
                new Contract{AuthorId=2,RepresentativeId=1,BookTitle="The Bad Book",BookISBN=1423586432645,PageCount=557,CompletionDate=DateTime.Parse("2018-07-22"),FixedPay=1050.00M,SalesForRoyalties=750,RoyaltyRate=8.4M,Notes="Sell on Amazon only.",CompanyApproval=true,CompanyApprovalDate=DateTime.Parse("2018-04-21"), AuthorApproval=true,AuthorApprovalDate=DateTime.Parse("2018-04-22"), CreationDate=DateTime.Parse("2018-04-18") },
                new Contract{AuthorId=3,RepresentativeId=2,BookTitle="A Better Book",BookISBN=1428374665645,PageCount=700,CompletionDate=DateTime.Parse("2018-08-20"),FixedPay=800.00M,SalesForRoyalties=500,RoyaltyRate=6.7M,CompanyApproval=true,CompanyApprovalDate=DateTime.Parse("2018-04-21"), AuthorApproval=true,AuthorApprovalDate=DateTime.Parse("2018-04-23"), CreationDate=DateTime.Parse("2018-04-19") },
                new Contract{AuthorId=4,RepresentativeId=4,BookTitle="Quite The Book",BookISBN=8276640342645,PageCount=233,CompletionDate=DateTime.Parse("2018-06-08"),FixedPay=500.99M,SalesForRoyalties=500,RoyaltyRate=4.4M,CompanyApproval=true,CompanyApprovalDate=DateTime.Parse("2018-04-21"), AuthorApproval=true,AuthorApprovalDate=DateTime.Parse("2018-04-22"), CreationDate=DateTime.Parse("2018-04-20") },
                new Contract{AuthorId=5,RepresentativeId=4,BookTitle="This Book",BookISBN=1420046432645,PageCount=425,CompletionDate=DateTime.Parse("2018-07-15"),FixedPay=625.50M,SalesForRoyalties=500,RoyaltyRate=5.0M,Notes="Still need author approval.",CompanyApproval=true,CompanyApprovalDate=DateTime.Parse("2018-04-20"), AuthorApproval=false, CreationDate=DateTime.Parse("2018-04-20") },
                new Contract{AuthorId=3,RepresentativeId=2,BookTitle="An Even Better Book",BookISBN=5573586439334,PageCount=701,CompletionDate=DateTime.Parse("2019-01-10"),FixedPay=1200.00M,SalesForRoyalties=1200,RoyaltyRate=18.50M,Notes="Still need company approval.",CompanyApproval=false,AuthorApproval=true,AuthorApprovalDate=DateTime.Parse("2018-04-21"), CreationDate=DateTime.Parse("2018-04-21") }
            };
            foreach(Contract c in contracts)
            {
                context.Contracts.Add(c);
            }
            context.SaveChanges();

        }
    }
}
