namespace Server
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
 

    public class MyDbContext : DbContext
    {

        public MyDbContext()
            : base("name=Streets")
        {
            Database.SetInitializer(new Initializer());
        }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Postcode> Postcodes { get; set; }

    }

    public class Initializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {

            Postcode postcode1 = new Postcode() { Index = "28800" };
            Postcode postcode2 = new Postcode() { Index = "46400" };
            Postcode postcode3 = new Postcode() { Index = "7803" };
            Postcode postcode4 = new Postcode() { Index = "32251" };
            Postcode postcode5 = new Postcode() { Index = "629008" };

            Postcode postcode6 = new Postcode() { Index = "5925" };
            Postcode postcode7 = new Postcode() { Index = " 89400 " };
            Postcode postcode8 = new Postcode() { Index = "083067" };
            Postcode postcode9 = new Postcode() { Index = "56528" };
            Postcode postcode10 = new Postcode() { Index = "31931" };

            context.Postcodes.Add(postcode1);
            context.Postcodes.Add(postcode2);
            context.Postcodes.Add(postcode3);
            context.Postcodes.Add(postcode4);
            context.Postcodes.Add(postcode5);
            context.Postcodes.Add(postcode6);
            context.Postcodes.Add(postcode7);
            context.Postcodes.Add(postcode8);
            context.Postcodes.Add(postcode9);
            context.Postcodes.Add(postcode10);

            context.SaveChanges();



            Street street1 = new Street() { Name = "07943 Bayside Crossing" , Postcode= postcode1 };
            Street street2 = new Street() { Name = "9575 Ridge Oak Trail", Postcode = postcode2 };
            Street street3 = new Street() { Name = "27701 Becker Road", Postcode = postcode3 };
            Street street4 = new Street() { Name = "69 Di Loreto Road", Postcode = postcode4 };
            Street street5 = new Street() { Name = "65358 Elka Terrace", Postcode = postcode5 };

            Street street6 = new Street() { Name = "09 Old Gate Junction", Postcode = postcode7 };
            Street street7 = new Street() { Name = "8488 Lukken Parkway", Postcode = postcode6 };
            Street street8 = new Street() { Name = "33 Commercial Alley", Postcode = postcode8 };
            Street street9 = new Street() { Name = "9271 Hanson Trail", Postcode = postcode10 };
            Street street10 = new Street() { Name = "9 1st Place", Postcode = postcode9 };



            Street street11 = new Street() { Name = "3353 Merry Avenue", Postcode = postcode3 };
            Street street12 = new Street() { Name = "9218 Alpine Parkway", Postcode = postcode2 };
            Street street13 = new Street() { Name = "429 School Crossing", Postcode = postcode5 };
            Street street14 = new Street() { Name = "16323 Utah Junction", Postcode = postcode7 };
            Street street15 = new Street() { Name = "008 Ruskin Court", Postcode = postcode10 };

            Street street16 = new Street() { Name = "9644 Stang Terrace", Postcode = postcode8 };
            Street street17 = new Street() { Name = "585 Jackson Pass", Postcode = postcode1 };
            Street street18 = new Street() { Name = "11821 Alpine Terrace", Postcode = postcode2 };
            Street street19 = new Street() { Name = "27983 Bunting Crossing", Postcode = postcode3 };
            Street street20 = new Street() { Name = "7 Dahle Center", Postcode = postcode5 };


            Street street21 = new Street() { Name = "5042 Summit Hill", Postcode = postcode6 };
            Street street22 = new Street() { Name = "7 Kennedy Terrace", Postcode = postcode2 };
            Street street23 = new Street() { Name = "309 Crest Line Street", Postcode = postcode3 };
            Street street24 = new Street() { Name = "30009 Melody Parkway", Postcode = postcode1 };
            Street street25 = new Street() { Name = "8964 Vera Avenue", Postcode = postcode2 };




            context.Streets.Add(street1);
            context.Streets.Add(street2);
            context.Streets.Add(street3);
            context.Streets.Add(street4);
            context.Streets.Add(street5);

            context.Streets.Add(street6);
            context.Streets.Add(street7);
            context.Streets.Add(street8);
            context.Streets.Add(street9);
            context.Streets.Add(street10);

            context.Streets.Add(street11);
            context.Streets.Add(street12);
            context.Streets.Add(street13);
            context.Streets.Add(street14);
            context.Streets.Add(street15);

            context.Streets.Add(street16);
            context.Streets.Add(street17);
            context.Streets.Add(street18);
            context.Streets.Add(street19);
            context.Streets.Add(street20);

            context.Streets.Add(street21);
            context.Streets.Add(street22);
            context.Streets.Add(street23);
            context.Streets.Add(street24);
            context.Streets.Add(street25);



            context.SaveChanges();










        }
    }

    public class Street
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int PostcodeId { get; set; }

        public virtual Postcode Postcode { get; set; }
    }
    public class Postcode
    {
        public int Id { get; set; }
        [Required]
        public string Index { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}