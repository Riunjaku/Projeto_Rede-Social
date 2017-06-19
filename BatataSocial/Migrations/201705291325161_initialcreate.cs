namespace BatataSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(nullable: false),
                        UserPhoto = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        StreetName = c.String(),
                        neighborhood = c.String(),
                        EstadoCivil = c.String(),
                        WorkPlace = c.String(),
                        School = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserScraps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Scrap = c.String(nullable: false, maxLength: 250),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerfilViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(nullable: false),
                        UserName = c.String(),
                        UserPhoto = c.String(),
                        FirstName = c.String(maxLength: 40),
                        LastName = c.String(maxLength: 40),
                        BirthDate = c.DateTime(nullable: false),
                        StreetName = c.String(maxLength: 40),
                        neighborhood = c.String(maxLength: 40),
                        EstadoCivil = c.String(maxLength: 40),
                        WorkPlace = c.String(maxLength: 40),
                        School = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScrapViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(),
                        UserName = c.String(),
                        Scrap = c.String(nullable: false, maxLength: 250),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropTable("dbo.ScrapViewModels");
            DropTable("dbo.PerfilViewModels");
            DropTable("dbo.ApplicationUserScraps");
            DropTable("dbo.ApplicationUserInfoes");
        }
    }
}
