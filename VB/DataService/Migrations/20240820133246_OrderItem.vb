Imports System
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace DataService.Migrations

    ''' <inheritdoc/> 
    Public Partial Class OrderItem
        Inherits Migration

        ''' <inheritdoc/> 
        Protected Overrides Sub Up(ByVal migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(name:="OrderItems", columns:=Function(table) New With {.Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"), .ProductName = table.Column(Of String)(type:="nvarchar(max)", nullable:=False), .UnitPrice = table.Column(Of Decimal)(type:="decimal(18,2)", nullable:=False), .Quantity = table.Column(Of Integer)(type:="int", nullable:=False), .Discount = table.Column(Of Single)(type:="real", nullable:=False), .OrderDate = table.Column(Of DateTime)(type:="datetime2", nullable:=False)}, constraints:=Function(table)
                table.PrimaryKey("PK_OrderItems", Function(x) x.Id)
            End Function)
        End Sub

        ''' <inheritdoc/> 
        Protected Overrides Sub Down(ByVal migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(name:="OrderItems")
        End Sub
    End Class
End Namespace
