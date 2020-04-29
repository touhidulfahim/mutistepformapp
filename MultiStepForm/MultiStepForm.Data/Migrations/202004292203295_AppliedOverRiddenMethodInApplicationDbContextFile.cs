namespace MultiStepForm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedOverRiddenMethodInApplicationDbContextFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Address", "StudentId", "dbo.tb_Student");
            DropForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department");
            DropForeignKey("dbo.tb_StudentCourse", "CourseId", "dbo.tb_CourseInfo");
            DropForeignKey("dbo.tb_StudentCourse", "StudentId", "dbo.tb_Student");
            AddForeignKey("dbo.tb_Address", "StudentId", "dbo.tb_Student", "StudentId");
            AddForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department", "DepartmentId");
            AddForeignKey("dbo.tb_StudentCourse", "CourseId", "dbo.tb_CourseInfo", "CourseId");
            AddForeignKey("dbo.tb_StudentCourse", "StudentId", "dbo.tb_Student", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_StudentCourse", "StudentId", "dbo.tb_Student");
            DropForeignKey("dbo.tb_StudentCourse", "CourseId", "dbo.tb_CourseInfo");
            DropForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department");
            DropForeignKey("dbo.tb_Address", "StudentId", "dbo.tb_Student");
            AddForeignKey("dbo.tb_StudentCourse", "StudentId", "dbo.tb_Student", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.tb_StudentCourse", "CourseId", "dbo.tb_CourseInfo", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.tb_Student", "DepartmentId", "dbo.tb_Department", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.tb_Address", "StudentId", "dbo.tb_Student", "StudentId", cascadeDelete: true);
        }
    }
}
