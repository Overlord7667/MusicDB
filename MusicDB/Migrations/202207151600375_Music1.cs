namespace MusicDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Music1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Autors", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Autors", new[] { "Song_Id" });
            CreateTable(
                "dbo.SongAutors",
                c => new
                    {
                        Song_Id = c.Int(nullable: false),
                        Autor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_Id, t.Autor_Id })
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.Autor_Id, cascadeDelete: true)
                .Index(t => t.Song_Id)
                .Index(t => t.Autor_Id);
            
            DropColumn("dbo.Autors", "Song_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Autors", "Song_Id", c => c.Int());
            DropForeignKey("dbo.SongAutors", "Autor_Id", "dbo.Autors");
            DropForeignKey("dbo.SongAutors", "Song_Id", "dbo.Songs");
            DropIndex("dbo.SongAutors", new[] { "Autor_Id" });
            DropIndex("dbo.SongAutors", new[] { "Song_Id" });
            DropTable("dbo.SongAutors");
            CreateIndex("dbo.Autors", "Song_Id");
            AddForeignKey("dbo.Autors", "Song_Id", "dbo.Songs", "Id");
        }
    }
}
