namespace SalonVencanica.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    //automatski generisan klasa kao posledica 'Code-first' metode koriscene za generisanje 'Users' tabele u bazi
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //kod ispod je zakomentarisan jer tabelu 'Products' vec imamo u bazi na osnovu 'Database first' metode

            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Description = c.String(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Category = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ProductId);
            
            //ovde se kreira tabela 'Users' u bazi na osnovu unapred zadatog koda
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            //DropTable("dbo.Products");
        }
    }
}
