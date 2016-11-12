namespace Biblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoautores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nacionalidad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibroAutors",
                c => new
                    {
                        Libro_Id = c.Int(nullable: false),
                        Autor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Libro_Id, t.Autor_Id })
                .ForeignKey("dbo.Libroes", t => t.Libro_Id, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.Autor_Id, cascadeDelete: true)
                .Index(t => t.Libro_Id)
                .Index(t => t.Autor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibroAutors", "Autor_Id", "dbo.Autors");
            DropForeignKey("dbo.LibroAutors", "Libro_Id", "dbo.Libroes");
            DropIndex("dbo.LibroAutors", new[] { "Autor_Id" });
            DropIndex("dbo.LibroAutors", new[] { "Libro_Id" });
            DropTable("dbo.LibroAutors");
            DropTable("dbo.Autors");
        }
    }
}
