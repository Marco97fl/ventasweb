using Microsoft.EntityFrameworkCore.Migrations;

namespace ventasweb.Data.Migrations
{
    public partial class relacionesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarrito_Carrito_carritoId",
                table: "DetalleCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoria_Departamento_departamentoId",
                table: "SubCategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoria",
                table: "SubCategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleCarrito",
                table: "DetalleCarrito");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarrito_carritoId",
                table: "DetalleCarrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "descuento",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubCategoria");

            migrationBuilder.DropColumn(
                name: "detalleCarritoId",
                table: "DetalleCarrito");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "DetalleCarrito");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "DetalleCarrito");

            migrationBuilder.RenameTable(
                name: "SubCategoria",
                newName: "SubCategorias");

            migrationBuilder.RenameTable(
                name: "DetalleCarrito",
                newName: "DetalleCarritos");

            migrationBuilder.RenameTable(
                name: "Departamento",
                newName: "Departamentos");

            migrationBuilder.RenameTable(
                name: "Carrito",
                newName: "Carritos");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "SubCategorias",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoria_departamentoId",
                table: "SubCategorias",
                newName: "IX_SubCategorias_DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "carritoId",
                table: "DetalleCarritos",
                newName: "CarritoId");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "Departamentos",
                newName: "DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "carritoId",
                table: "Carritos",
                newName: "CarritoId");

            migrationBuilder.AlterColumn<string>(
                name: "nombreProducto",
                table: "productos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fabricante",
                table: "productos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "productos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "descripcionProd",
                table: "productos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "peso",
                table: "productos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "precioProd",
                table: "productos",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "proveedor",
                table: "productos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "volumen",
                table: "productos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "nombreSubCategoria",
                table: "SubCategorias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "SubCategorias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoriaId",
                table: "SubCategorias",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "DetalleCarritos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DetalleCarritos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantidadProd",
                table: "DetalleCarritos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "precioLinea",
                table: "DetalleCarritos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "nombreDepartamento",
                table: "Departamentos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lugarEntrega",
                table: "Carritos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "metodoPago",
                table: "Carritos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tarifaEnvioId",
                table: "Carritos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "Carritos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Carritos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategorias",
                table: "SubCategorias",
                column: "SubCategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleCarritos",
                table: "DetalleCarritos",
                columns: new[] { "CarritoId", "ProductoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos",
                column: "DepartamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos",
                column: "CarritoId");

            migrationBuilder.CreateTable(
                name: "cantidadProductos",
                columns: table => new
                {
                    cantidadProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stockProd = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cantidadProductos", x => x.cantidadProductoId);
                    table.ForeignKey(
                        name: "FK_cantidadProductos_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "impuestos",
                columns: table => new
                {
                    impuestoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomImpuesto = table.Column<string>(nullable: false),
                    valorImpuesto = table.Column<double>(nullable: false),
                    SubCategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_impuestos", x => x.impuestoId);
                    table.ForeignKey(
                        name: "FK_impuestos_SubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "SubCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomTag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "tarifaEnvios",
                columns: table => new
                {
                    tarifaEnvioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valorTarifa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarifaEnvios", x => x.tarifaEnvioId);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: false),
                    primerNomb = table.Column<string>(nullable: false),
                    primerApell = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: false),
                    pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "tag_prods",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_prods", x => new { x.ProductoId, x.tagId });
                    table.ForeignKey(
                        name: "FK_tag_prods_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_prods_tags_tagId",
                        column: x => x.tagId,
                        principalTable: "tags",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regiones",
                columns: table => new
                {
                    regionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRegion = table.Column<string>(nullable: false),
                    tarifaEnvioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regiones", x => x.regionId);
                    table.ForeignKey(
                        name: "FK_regiones_tarifaEnvios_tarifaEnvioId",
                        column: x => x.tarifaEnvioId,
                        principalTable: "tarifaEnvios",
                        principalColumn: "tarifaEnvioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_SubCategoriaId",
                table: "productos",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarritos_ProductoId",
                table: "DetalleCarritos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_tarifaEnvioId",
                table: "Carritos",
                column: "tarifaEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_usuarioId",
                table: "Carritos",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_cantidadProductos_ProductoId",
                table: "cantidadProductos",
                column: "ProductoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_impuestos_SubCategoriaId",
                table: "impuestos",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_regiones_tarifaEnvioId",
                table: "regiones",
                column: "tarifaEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_tag_prods_tagId",
                table: "tag_prods",
                column: "tagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_tarifaEnvios_tarifaEnvioId",
                table: "Carritos",
                column: "tarifaEnvioId",
                principalTable: "tarifaEnvios",
                principalColumn: "tarifaEnvioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_usuarios_usuarioId",
                table: "Carritos",
                column: "usuarioId",
                principalTable: "usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarritos_Carritos_CarritoId",
                table: "DetalleCarritos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarritos_productos_ProductoId",
                table: "DetalleCarritos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_SubCategorias_SubCategoriaId",
                table: "productos",
                column: "SubCategoriaId",
                principalTable: "SubCategorias",
                principalColumn: "SubCategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Departamentos_DepartamentoId",
                table: "SubCategorias",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_tarifaEnvios_tarifaEnvioId",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_usuarios_usuarioId",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarritos_Carritos_CarritoId",
                table: "DetalleCarritos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarritos_productos_ProductoId",
                table: "DetalleCarritos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_SubCategorias_SubCategoriaId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Departamentos_DepartamentoId",
                table: "SubCategorias");

            migrationBuilder.DropTable(
                name: "cantidadProductos");

            migrationBuilder.DropTable(
                name: "impuestos");

            migrationBuilder.DropTable(
                name: "regiones");

            migrationBuilder.DropTable(
                name: "tag_prods");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "tarifaEnvios");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_SubCategoriaId",
                table: "productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategorias",
                table: "SubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleCarritos",
                table: "DetalleCarritos");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarritos_ProductoId",
                table: "DetalleCarritos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_tarifaEnvioId",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_usuarioId",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "descripcionProd",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "precioProd",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "proveedor",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "volumen",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "SubCategoriaId",
                table: "SubCategorias");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetalleCarritos");

            migrationBuilder.DropColumn(
                name: "cantidadProd",
                table: "DetalleCarritos");

            migrationBuilder.DropColumn(
                name: "precioLinea",
                table: "DetalleCarritos");

            migrationBuilder.DropColumn(
                name: "metodoPago",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "tarifaEnvioId",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Carritos");

            migrationBuilder.RenameTable(
                name: "SubCategorias",
                newName: "SubCategoria");

            migrationBuilder.RenameTable(
                name: "DetalleCarritos",
                newName: "DetalleCarrito");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                newName: "Departamento");

            migrationBuilder.RenameTable(
                name: "Carritos",
                newName: "Carrito");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "SubCategoria",
                newName: "departamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategorias_DepartamentoId",
                table: "SubCategoria",
                newName: "IX_SubCategoria_departamentoId");

            migrationBuilder.RenameColumn(
                name: "CarritoId",
                table: "DetalleCarrito",
                newName: "carritoId");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Departamento",
                newName: "departamentoId");

            migrationBuilder.RenameColumn(
                name: "CarritoId",
                table: "Carrito",
                newName: "carritoId");

            migrationBuilder.AlterColumn<string>(
                name: "nombreProducto",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "fabricante",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "productos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "descuento",
                table: "productos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "precio",
                table: "productos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "nombreSubCategoria",
                table: "SubCategoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "departamentoId",
                table: "SubCategoria",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubCategoria",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "carritoId",
                table: "DetalleCarrito",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "detalleCarritoId",
                table: "DetalleCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "DetalleCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "precio",
                table: "DetalleCarrito",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "nombreDepartamento",
                table: "Departamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "lugarEntrega",
                table: "Carrito",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoria",
                table: "SubCategoria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleCarrito",
                table: "DetalleCarrito",
                column: "detalleCarritoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "departamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito",
                column: "carritoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_carritoId",
                table: "DetalleCarrito",
                column: "carritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarrito_Carrito_carritoId",
                table: "DetalleCarrito",
                column: "carritoId",
                principalTable: "Carrito",
                principalColumn: "carritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoria_Departamento_departamentoId",
                table: "SubCategoria",
                column: "departamentoId",
                principalTable: "Departamento",
                principalColumn: "departamentoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
