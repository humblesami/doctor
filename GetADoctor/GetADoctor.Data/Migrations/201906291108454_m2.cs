namespace GetADoctor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "Test2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Test2", c => c.String());
        }
    }
}
