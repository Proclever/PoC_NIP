namespace PoC_NIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SearchLogUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchLogs", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.SearchLogs", "Found", c => c.Boolean(nullable: false));
            AddColumn("dbo.SearchLogs", "HttpRequestHeaders", c => c.String(nullable: false));
            DropColumn("dbo.SearchLogs", "HttpHeaders");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SearchLogs", "HttpHeaders", c => c.String());
            DropColumn("dbo.SearchLogs", "HttpRequestHeaders");
            DropColumn("dbo.SearchLogs", "Found");
            DropColumn("dbo.SearchLogs", "Created");
        }
    }
}
