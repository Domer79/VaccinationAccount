namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        MiddleName = c.String(maxLength: 200),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Snils = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Name, t.LastName, t.MiddleName }, name: "IX_Patient_Name_LastName_MiddleName")
                .Index(t => t.Snils, name: "IX_Patient_Snils");
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Preparation = c.String(nullable: false),
                        Approval = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patients", "IX_Patient_Snils");
            DropIndex("dbo.Patients", "IX_Patient_Name_LastName_MiddleName");
            DropTable("dbo.Vaccinations");
            DropTable("dbo.Patients");
        }
    }
}
