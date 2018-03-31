namespace Handin2._2.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetBestemmerDuBare : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Adresse_VejNavn", "dbo.Adresses");
            DropForeignKey("dbo.People", "AdresseMatches_Id", "dbo.JoinPersonAdresses");
            DropForeignKey("dbo.Matches", "Person_Cpr", "dbo.People");
            DropForeignKey("dbo.Matches", "JoinPersonAdresse_Id", "dbo.JoinPersonAdresses");
            DropForeignKey("dbo.Adresses", "PersonMatches_Id", "dbo.JoinPersonAdresses");
            DropForeignKey("dbo.TelefonNummers", "Person_Cpr", "dbo.People");
            DropIndex("dbo.Adresses", new[] { "PersonMatches_Id" });
            DropIndex("dbo.Matches", new[] { "Adresse_VejNavn" });
            DropIndex("dbo.Matches", new[] { "Person_Cpr" });
            DropIndex("dbo.Matches", new[] { "JoinPersonAdresse_Id" });
            DropIndex("dbo.People", new[] { "AdresseMatches_Id" });
            DropIndex("dbo.TelefonNummers", new[] { "Person_Cpr" });
            RenameColumn(table: "dbo.TelefonNummers", name: "Person_Cpr", newName: "PersonCpr");
            DropPrimaryKey("dbo.Adresses");
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        PersonCpr = c.Int(nullable: false),
                        AdresseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Adresses", t => t.AdresseId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonCpr, cascadeDelete: true)
                .Index(t => t.PersonCpr)
                .Index(t => t.AdresseId);
            
            AddColumn("dbo.Adresses", "AdresseId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Adresses", "VejNavn", c => c.String());
            AlterColumn("dbo.TelefonNummers", "PersonCpr", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Adresses", "AdresseId");
            CreateIndex("dbo.TelefonNummers", "PersonCpr");
            AddForeignKey("dbo.TelefonNummers", "PersonCpr", "dbo.People", "Cpr", cascadeDelete: true);
            DropColumn("dbo.Adresses", "PersonMatches_Id");
            DropColumn("dbo.People", "AdresseMatches_Id");
            DropTable("dbo.JoinPersonAdresses");
            DropTable("dbo.Matches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Adresse_VejNavn = c.String(maxLength: 128),
                        Person_Cpr = c.Int(),
                        JoinPersonAdresse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.JoinPersonAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "AdresseMatches_Id", c => c.Int());
            AddColumn("dbo.Adresses", "PersonMatches_Id", c => c.Int());
            DropForeignKey("dbo.TelefonNummers", "PersonCpr", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "PersonCpr", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.TelefonNummers", new[] { "PersonCpr" });
            DropIndex("dbo.PersonAdresses", new[] { "AdresseId" });
            DropIndex("dbo.PersonAdresses", new[] { "PersonCpr" });
            DropPrimaryKey("dbo.Adresses");
            AlterColumn("dbo.TelefonNummers", "PersonCpr", c => c.Int());
            AlterColumn("dbo.Adresses", "VejNavn", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Adresses", "AdresseId");
            DropTable("dbo.PersonAdresses");
            AddPrimaryKey("dbo.Adresses", "VejNavn");
            RenameColumn(table: "dbo.TelefonNummers", name: "PersonCpr", newName: "Person_Cpr");
            CreateIndex("dbo.TelefonNummers", "Person_Cpr");
            CreateIndex("dbo.People", "AdresseMatches_Id");
            CreateIndex("dbo.Matches", "JoinPersonAdresse_Id");
            CreateIndex("dbo.Matches", "Person_Cpr");
            CreateIndex("dbo.Matches", "Adresse_VejNavn");
            CreateIndex("dbo.Adresses", "PersonMatches_Id");
            AddForeignKey("dbo.TelefonNummers", "Person_Cpr", "dbo.People", "Cpr");
            AddForeignKey("dbo.Adresses", "PersonMatches_Id", "dbo.JoinPersonAdresses", "Id");
            AddForeignKey("dbo.Matches", "JoinPersonAdresse_Id", "dbo.JoinPersonAdresses", "Id");
            AddForeignKey("dbo.Matches", "Person_Cpr", "dbo.People", "Cpr");
            AddForeignKey("dbo.People", "AdresseMatches_Id", "dbo.JoinPersonAdresses", "Id");
            AddForeignKey("dbo.Matches", "Adresse_VejNavn", "dbo.Adresses", "VejNavn");
        }
    }
}
