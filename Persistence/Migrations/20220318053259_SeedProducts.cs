using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,CategoryId) " +
           "VALUES('Caderno espiral','Caderno espiral 100 fôlhas',7.45,50,1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,CategoryId) " +
            "VALUES('Estojo escolar','Estojo escolar cinza',5.65,70,1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,CategoryId) " +
            "VALUES('Borracha escolar','Borracha branca pequena',3.25,80,1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,CategoryId) " +
            "VALUES('Calculadora escolar','Calculadora simples',15.39,20,2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
