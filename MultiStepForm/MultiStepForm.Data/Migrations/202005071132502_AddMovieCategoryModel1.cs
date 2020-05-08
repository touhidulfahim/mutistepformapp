namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieCategoryModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_MovieCategory",
                c => new
                    {
                        MovieCategoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .Index(t => t.CategoryId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_MovieCategory", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.tb_MovieCategory", "CategoryId", "dbo.Categories");
            DropIndex("dbo.tb_MovieCategory", new[] { "MovieId" });
            DropIndex("dbo.tb_MovieCategory", new[] { "CategoryId" });
            DropTable("dbo.tb_MovieCategory");
        }
    }
}
