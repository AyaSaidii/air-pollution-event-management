namespace ControleCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chercheurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CherchPollutionEvents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        solution = c.String(nullable: false, maxLength: 150),
                        ChercheurId = c.Int(nullable: false),
                        PollutEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chercheurs", t => t.ChercheurId, cascadeDelete: true)
                .ForeignKey("dbo.PollutionEvenement", t => t.PollutEventId)
                .Index(t => t.ChercheurId)
                .Index(t => t.PollutEventId);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lieux",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ville = c.String(nullable: false, maxLength: 20),
                        adresse = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PollutionDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        NivPollution = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20),
                        pass = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PollutionEvenement",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        nom = c.String(nullable: false, maxLength: 150),
                        cause = c.String(nullable: false, maxLength: 150),
                        LieuId = c.Int(nullable: false),
                        DataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evenements", t => t.ID)
                .ForeignKey("dbo.Lieux", t => t.LieuId, cascadeDelete: true)
                .ForeignKey("dbo.PollutionDatas", t => t.DataId, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.LieuId)
                .Index(t => t.DataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PollutionEvenement", "DataId", "dbo.PollutionDatas");
            DropForeignKey("dbo.PollutionEvenement", "LieuId", "dbo.Lieux");
            DropForeignKey("dbo.PollutionEvenement", "ID", "dbo.Evenements");
            DropForeignKey("dbo.CherchPollutionEvents", "PollutEventId", "dbo.PollutionEvenement");
            DropForeignKey("dbo.CherchPollutionEvents", "ChercheurId", "dbo.Chercheurs");
            DropIndex("dbo.PollutionEvenement", new[] { "DataId" });
            DropIndex("dbo.PollutionEvenement", new[] { "LieuId" });
            DropIndex("dbo.PollutionEvenement", new[] { "ID" });
            DropIndex("dbo.CherchPollutionEvents", new[] { "PollutEventId" });
            DropIndex("dbo.CherchPollutionEvents", new[] { "ChercheurId" });
            DropTable("dbo.PollutionEvenement");
            DropTable("dbo.Login");
            DropTable("dbo.PollutionDatas");
            DropTable("dbo.Lieux");
            DropTable("dbo.Evenements");
            DropTable("dbo.CherchPollutionEvents");
            DropTable("dbo.Chercheurs");
        }
    }
}
