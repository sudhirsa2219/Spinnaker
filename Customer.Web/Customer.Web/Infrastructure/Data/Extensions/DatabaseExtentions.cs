using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;
public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        
        ValidateorCreateDB(context);

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static void ValidateorCreateDB(ApplicationDbContext? context)
    {
        Console.WriteLine("Inside ValidateorCreateDB");
        var constr = context.Database.GetConnectionString();
        var db = constr.Split(";")[1].Split("=")[1];

        var newConStr = constr.Replace(db, "master");
        bool result = false;
        try
        {
            SqlConnection conn = new SqlConnection(newConStr);
            var sqlQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", db);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    conn.Open();
                    var databaseID = cmd.ExecuteScalar();
                    
                    if(databaseID == null)
                    {
                        Console.WriteLine($"Creating database {db}");
                        cmd.CommandText = $"CREATE DATABASE {db};";
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception {ex}");
        }
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCustomerAsync(context);
    }

    private static async Task SeedCustomerAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }
    }
}
