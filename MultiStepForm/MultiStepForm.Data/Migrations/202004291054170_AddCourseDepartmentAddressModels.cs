namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseDepartmentAddressModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        IsMailing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.tb_Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.tb_Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.tb_CourseInfo",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.tb_StudentCourse",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        AssignDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.tb_CourseInfo", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.tb_Student", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Student", "DepartmentId");
            AddForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_StudentCourse", "StudentId", "dbo.tb_Student");
            DropForeignKey("dbo.tb_StudentCourse", "CourseId", "dbo.tb_CourseInfo");
            DropForeignKey("dbo.tb_Address", "StudentId", "dbo.tb_Student");
            DropForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department");
            DropIndex("dbo.tb_StudentCourse", new[] { "CourseId" });
            DropIndex("dbo.tb_StudentCourse", new[] { "StudentId" });
            DropIndex("dbo.tb_Student", new[] { "DepartmentId" });
            DropIndex("dbo.tb_Address", new[] { "StudentId" });
            DropColumn("dbo.tb_Student", "DepartmentId");
            DropTable("dbo.tb_StudentCourse");
            DropTable("dbo.tb_CourseInfo");
            DropTable("dbo.tb_Department");
            DropTable("dbo.tb_Address");
        }
    }
}
