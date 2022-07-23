namespace MusicDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Music : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Autors", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Autors", new[] { "Song_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Autors");
        }
    }
}
