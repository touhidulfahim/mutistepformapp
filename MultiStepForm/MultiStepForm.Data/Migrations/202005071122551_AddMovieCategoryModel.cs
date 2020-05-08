namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "CategoryVal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CategoryVal", c => c.String());
        }
    }
}
