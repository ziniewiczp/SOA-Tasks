namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorSurname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "public.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("public.Books");
            DropTable("public.Authors");
        }
    }
}
