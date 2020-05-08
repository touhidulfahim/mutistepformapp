namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieAndCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 60),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Rating = c.String(maxLength: 5),
                        BarcodeImage = c.Binary(),
                        Barcode = c.String(),
                        ImageUrl = c.String(),
                        CategoryVal = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
            DropTable("dbo.Categories");
        }
    }
}
