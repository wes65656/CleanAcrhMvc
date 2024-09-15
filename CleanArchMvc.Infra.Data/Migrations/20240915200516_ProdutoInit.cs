using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) VALUES " +
                   "('Martelo', 'Martelo de aço forjado', 29.99, 50, 'martelo.jpg', 1)," +
                   "('Chave de Fenda', 'Chave de fenda com cabo ergonômico', 9.99, 100, 'chave_fenda.jpg', 1)");
            
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) VALUES " +
                   "('Estetoscópio', 'Estetoscópio profissional', 199.99, 30, 'estetoscopio.jpg', 2)," +
                   "('Termômetro Digital', 'Termômetro digital com leitura rápida', 24.99, 80, 'termometro.jpg', 2)");
            
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) VALUES " +
                   "('Lápis', 'Lápis HB número 2', 0.99, 200, 'lapis.jpg', 3)," +
                   "('Caderno', 'Caderno espiral 100 folhas', 7.99, 150, 'caderno.jpg', 3)");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products WHERE CategoryId IN (1, 2, 3)");
        }
    }
}
