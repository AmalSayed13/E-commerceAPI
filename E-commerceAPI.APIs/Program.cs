using E_commerceAPI.DAL;
using E_commerceAPI.BL;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using E_commerceAPI.APIs;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Data.Context;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBLServices();
builder.Services.AddDALServices(builder.Configuration);
#endregion

#region Identity

builder.Services.AddIdentityCore<User>(options => { 
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<EcommerceContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
    // configure used authentication
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault";
})
    //define the authentication scheme
    .AddJwtBearer("MyDefault",options =>
    {
        var KeyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
        var KeyInBytes = Encoding.ASCII.GetBytes(KeyFromConfig);
        var Key = new SymmetricSecurityKey(KeyInBytes);
       
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = Key,

        };
    });

var app = builder.Build();

# region MiddleWare

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var assetsDirectoryPath = Path.Combine(builder.Environment.ContentRootPath, "Assets");
Directory.CreateDirectory(assetsDirectoryPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(assetsDirectoryPath),
    RequestPath = "/assets"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion