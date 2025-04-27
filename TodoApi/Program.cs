using TodoApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ToDoDB>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 41))));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1" });
});
builder.Services.AddCors(option => option.AddPolicy("AllowAll",
    p => p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));


var app = builder.Build();
app.UseCors("AllowAll");


    

app.MapGet("/getAll", async (ToDoDB context) =>
await context.Items.ToListAsync());

app.MapPost("/add",async (ToDoDB context,string name) =>
{var MyItem=new Item{Name = name, IsComplete=false};
     context.Items.Add(MyItem);
     await context.SaveChangesAsync();});

app.MapPut("/update/{id}",async (ToDoDB context,int id) =>
{var MyItem=await context.Items.FindAsync(id);
     if(MyItem!=null) {MyItem.IsComplete=MyItem.IsComplete==true?false:true;}
     await context.SaveChangesAsync();}); 

app.MapDelete("/delete/{id}",async (ToDoDB context,int id) =>
{var MyItem=await context.Items.FindAsync(id);
     if(MyItem!=null) {context.Items.Remove(MyItem); 
     await context.SaveChangesAsync();} });

app.MapGet("/",() => "ToDoApi is runing!");
app.UseSwagger();
    app.UseSwaggerUI();

app.Run();
