using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add service and create Policy with options

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
         sqlServerOptionsAction: sqlOptions =>
         {
             sqlOptions.EnableRetryOnFailure(maxRetryCount:10,maxRetryDelay:TimeSpan.FromSeconds(30),errorNumbersToAdd:null);
         }
        );
   


});


//builder.Services.Configure<FormOptions>(options =>
//{
//    options.ValueLengthLimit = int.MaxValue;
//    options.MultipartBodyLengthLimit = int.MaxValue;
//    options.MultipartHeadersLengthLimit = int.MaxValue;

//});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;



});

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
var app = builder.Build();

app.UseCors(
      options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
  );

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
    RequestPath = new PathString("/Images")
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(builder =>
//builder.WithOrigins("http://expo2022-001-site1.itempurl.com/"));
//builder.WithOrigins("http://localhost:4200/")
//);
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();
app.MapControllers();

app.Run();
