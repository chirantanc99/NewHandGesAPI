var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//using System;
//using System.Linq;
//using System.Net;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;




//    class program
//    {



//        public static void Main(string[] args)

//        {
//        download();
//       // BackEnd_proj.Model.ModelFit();


//            //var tst = new TestTsv();
//            //tst.Load();


//        }
//    static void download()
//    {
//        string url = "https://media.istockphoto.com/photos/holding-something-picture-id182912540?b=1&k=20&m=182912540&s=170667a&w=0&h=k5OM9LT4udb0fuQaWMaVf6Gxj4ZjYMlNowWnMg6oSQ0=";
//        using (WebClient client = new WebClient())
//        {
//            client.DownloadFile(new Uri(url), "Validation.jpg");
//        }
//    }

//}








