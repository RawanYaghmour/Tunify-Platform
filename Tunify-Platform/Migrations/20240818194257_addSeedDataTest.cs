using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Song",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Album",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "British singer-songwriter, known for her deep, emotional ballads.", "Adele" },
                    { 2, "American singer-songwriter and performer, known for his dynamic stage presence and hit singles.", "Bruno Mars" }
                });

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Playlist",
                columns: new[] { "PlaylistId", "Created_Date", "Playlist_Name", "UserId" },
                values: new object[] { 3, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vibes3", 1 });

            migrationBuilder.InsertData(
                table: "PlaylistSongs",
                columns: new[] { "PlaylistSongsId", "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlbumId", "ArtistId", "Genre" },
                values: new object[] { 2, 2, "Pop" });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "SubscriptionId", "Price", "Subscription_Type" },
                values: new object[,]
                {
                    { 1, 7.9900000000000002, "Starter" },
                    { 2, 14.0, "Deluxe" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "Album_Name", "ArtistId", "Release_Date" },
                values: new object[,]
                {
                    { 1, "25", 1, new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "24K Magic", 2, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_ArtistId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Song",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artist",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Album",
                newName: "AlbumId");

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Song",
                keyColumn: "SongId",
                keyValue: 2,
                columns: new[] { "AlbumId", "ArtistId", "Genre" },
                values: new object[] { 1, 1, "Hip Hop" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
