namespace PoC_NIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nip = c.String(),
                        Regon = c.String(),
                        Krs = c.String(),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        StreetNumber = c.String(),
                        PostalCode = c.String(),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyFound = c.Int(),
                        Phrase = c.String(),
                        HttpHeaders = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyFound)
                .Index(t => t.CompanyFound);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SearchLogs", "CompanyFound", "dbo.Companies");
            DropIndex("dbo.SearchLogs", new[] { "CompanyFound" });
            DropTable("dbo.SearchLogs");
            DropTable("dbo.Companies");
        }
    }
}
