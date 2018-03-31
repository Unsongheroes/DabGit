namespace Handin2._2.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetBestemmerDuBare : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonAdresses", "Person_Cpr", "dbo.People");
            DropIndex("dbo.PersonAdresses", new[] { "Person_Cpr" });
            RenameColumn(table: "dbo.PersonAdresses", name: "Person_Cpr", newName: "PersonCpr");
            AddColumn("dbo.PersonAdresses", "AdresseNr", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonAdresses", "PersonCpr", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonAdresses", "PersonCpr");
            AddForeignKey("dbo.PersonAdresses", "PersonCpr", "dbo.People", "Cpr", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonAdresses", "PersonCpr", "dbo.People");
            DropIndex("dbo.PersonAdresses", new[] { "PersonCpr" });
            AlterColumn("dbo.PersonAdresses", "PersonCpr", c => c.Int());
            DropColumn("dbo.PersonAdresses", "AdresseNr");
            RenameColumn(table: "dbo.PersonAdresses", name: "PersonCpr", newName: "Person_Cpr");
            CreateIndex("dbo.PersonAdresses", "Person_Cpr");
            AddForeignKey("dbo.PersonAdresses", "Person_Cpr", "dbo.People", "Cpr");
        }
    }
}
