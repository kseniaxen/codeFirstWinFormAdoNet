namespace EF6CodeFirstWinFormsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Publishers", "Address", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Address", c => c.String());
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String());
        }
    }
}
