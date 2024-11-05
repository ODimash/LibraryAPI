using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<LibraryContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddControllers();
}
