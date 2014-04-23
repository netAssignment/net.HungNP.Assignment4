namespace BookStore_NETMVC.Migrations.Books
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        strBookID = c.String(nullable: false, maxLength: 128),
                        strBookName = c.String(nullable: false, maxLength: 200),
                        strBookContent = c.String(),
                        strCatetoryID = c.String(),
                    })
                .PrimaryKey(t => t.strBookID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        strCategoryID = c.String(nullable: false, maxLength: 128),
                        strCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.strCategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
