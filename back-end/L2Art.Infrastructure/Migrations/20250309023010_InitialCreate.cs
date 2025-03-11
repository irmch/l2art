using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L2Art.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommissionId = table.Column<long>(type: "bigint", nullable: false),
                    PricePerUnit = table.Column<long>(type: "bigint", nullable: false),
                    CommissionItemType = table.Column<int>(type: "integer", nullable: false),
                    DurationInDays = table.Column<int>(type: "integer", nullable: false),
                    EpochSecondEndTime = table.Column<int>(type: "integer", nullable: false),
                    SellerName = table.Column<string>(type: "text", nullable: false),
                    TypeOfModification = table.Column<short>(type: "smallint", nullable: false),
                    ObjectId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    StoreItemType = table.Column<long>(type: "bigint", nullable: false),
                    ItemSlot = table.Column<long>(type: "bigint", nullable: false),
                    Enchant = table.Column<short>(type: "smallint", nullable: false),
                    AttributeType = table.Column<short>(type: "smallint", nullable: false),
                    WeaponAttributeStat = table.Column<short>(type: "smallint", nullable: false),
                    WaterAttribute = table.Column<short>(type: "smallint", nullable: false),
                    FireAttribute = table.Column<short>(type: "smallint", nullable: false),
                    EarthAttribute = table.Column<short>(type: "smallint", nullable: false),
                    WindAttribute = table.Column<short>(type: "smallint", nullable: false),
                    DarkAttribute = table.Column<short>(type: "smallint", nullable: false),
                    HolyAttribute = table.Column<short>(type: "smallint", nullable: false),
                    SoulCrystal1 = table.Column<int>(type: "integer", nullable: false),
                    SoulCrystal2 = table.Column<int>(type: "integer", nullable: false),
                    SoulCrystal3 = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    VisualId = table.Column<int>(type: "integer", nullable: false),
                    VisualIdName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AdditionalName = table.Column<string[]>(type: "text[]", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Popup = table.Column<int>(type: "integer", nullable: true),
                    DefaultAction = table.Column<string>(type: "text", nullable: true),
                    UseOrder = table.Column<int>(type: "integer", nullable: true),
                    NameClass = table.Column<int>(type: "integer", nullable: true),
                    Color = table.Column<int>(type: "integer", nullable: true),
                    TooltipTexture = table.Column<string>(type: "text", nullable: true),
                    TooltipBGTexture = table.Column<string>(type: "text", nullable: true),
                    TooltipBGTextureCompare = table.Column<string>(type: "text", nullable: true),
                    TooltipBGDecoTexture = table.Column<string>(type: "text", nullable: true),
                    IsTrade = table.Column<bool>(type: "boolean", nullable: true),
                    IsDrop = table.Column<bool>(type: "boolean", nullable: true),
                    IsDestruct = table.Column<bool>(type: "boolean", nullable: true),
                    IsPrivateStore = table.Column<bool>(type: "boolean", nullable: true),
                    KeepType = table.Column<int>(type: "integer", nullable: true),
                    IsNpcTrade = table.Column<bool>(type: "boolean", nullable: true),
                    IsCommissionStore = table.Column<bool>(type: "boolean", nullable: true),
                    EnchantBless = table.Column<int>(type: "integer", nullable: true),
                    CreateItemsList = table.Column<bool>(type: "boolean", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: true),
                    AuctionCategory = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateShops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemCount = table.Column<int>(type: "integer", nullable: false),
                    VendorName = table.Column<string>(type: "text", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    StoreType = table.Column<byte>(type: "smallint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Z = table.Column<int>(type: "integer", nullable: false),
                    TypeOfModification = table.Column<short>(type: "smallint", nullable: false),
                    ObjectId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    StoreItemType = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    ItemSlot = table.Column<long>(type: "bigint", nullable: false),
                    Enchant = table.Column<short>(type: "smallint", nullable: false),
                    Ls1 = table.Column<int>(type: "integer", nullable: false),
                    Ls2 = table.Column<int>(type: "integer", nullable: false),
                    Ls3 = table.Column<int>(type: "integer", nullable: false),
                    AttributeType = table.Column<short>(type: "smallint", nullable: false),
                    WeaponAttributeStat = table.Column<short>(type: "smallint", nullable: false),
                    WaterAttribute = table.Column<short>(type: "smallint", nullable: false),
                    FireAttribute = table.Column<short>(type: "smallint", nullable: false),
                    EarthAttribute = table.Column<short>(type: "smallint", nullable: false),
                    WindAttribute = table.Column<short>(type: "smallint", nullable: false),
                    DarkAttribute = table.Column<short>(type: "smallint", nullable: false),
                    HolyAttribute = table.Column<short>(type: "smallint", nullable: false),
                    SoulCrystal1 = table.Column<int>(type: "integer", nullable: false),
                    SoulCrystal2 = table.Column<int>(type: "integer", nullable: false),
                    SoulCrystal3 = table.Column<int>(type: "integer", nullable: false),
                    VisualId = table.Column<int>(type: "integer", nullable: false),
                    VisualIdName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "ItemName");

            migrationBuilder.DropTable(
                name: "PrivateShops");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
