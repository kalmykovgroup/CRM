using CRST_ServerAPI.Data;
using Dapper;
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.MySqlClient;
using System.Data;

#nullable disable

namespace CRST_ServerAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      /*      List<User> users = new List<User>() {
                new User(){

                },
                new User(){
                },
            };
             

            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                foreach (var user in users)
                {
                   db.Query<User>($"INSERT INTO user (name) VALUES ({user.Name})");
                }
    
            }
*/
           

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
