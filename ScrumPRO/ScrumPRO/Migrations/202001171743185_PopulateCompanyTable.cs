namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCompanyTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Companies(Id, Name, Location) VALUES (1, 'Aca', 'Nis') ");
        }
        
        public override void Down()
        {
        }
    }
}
