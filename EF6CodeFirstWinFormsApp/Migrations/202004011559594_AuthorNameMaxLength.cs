namespace EF6CodeFirstWinFormsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorNameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
        }
    }
}
