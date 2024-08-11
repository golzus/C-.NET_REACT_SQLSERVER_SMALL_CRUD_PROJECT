//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// ����� ������� CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost3000",
//        builder => builder
//            .WithOrigins("http://localhost:3000") // ���� ����� ���
//            .AllowAnyHeader()
//            .AllowAnyMethod());
//});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// ����� ����� �������� �-CORS
//app.UseCors("AllowLocalhost3000");

//app.UseAuthorization();

//app.MapControllers();

//app.Run();using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ����� ������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder => builder
            .WithOrigins("http://localhost:3000") // ���� ����� ���
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ����� ������� - ����� ������� CORS
app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

