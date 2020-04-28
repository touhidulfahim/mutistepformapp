namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.String(),
                        MobileNo = c.String(),
                        RegistrationNo = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_Student");
        }
    }
}
