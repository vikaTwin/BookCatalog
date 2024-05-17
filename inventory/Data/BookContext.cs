using inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace inventory.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) {
            var connection = (Microsoft.Data.SqlClient.SqlConnection)Database.GetDbConnection();
            var tokenProv = new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider();
            connection.AccessToken = tokenProv.GetAccessTokenAsync("https://database.windows.net/").Result;
         }

        public DbSet<Book> Books  {get; set;}  
        
    }    
}
    
        