using AutoMapper;
using coolblue_assesment.Data;
using coolblue_assesment.Dtos;
using coolblue_assesment.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnBuilder = new SqlConnectionStringBuilder();

sqlConnBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnBuilder.ConnectionString));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Routes -> Dto -> Services -> Repositories ->  AppDbContext  - vicaversa

app.MapGet("/", () => {
     return "Alles voor een glimlach!";
});

app.MapGet("api/v1/getProduct", (IProductService service, int id) => {
   
    ProductReadDto? productReadDto = service.getProduct(id);

    if(productReadDto != null){
        return Results.Ok(productReadDto);
    }else{
        return Results.NotFound("Product Not Found");
    }
});

app.MapGet("api/v1/getProductType", (IProductTypeService service, int id) => {
   
    ProductTypeReadDto? productTypeReadDto = service.getProductType(id);

    if(productTypeReadDto != null){
        return Results.Ok(productTypeReadDto);
    }else{
        return Results.NotFound("ProductType Not Found");
    }
});

app.MapGet("api/v1/getInsuranceCost",  (IInsuranceService service, int id) => {
   
    InsuranceCostReadDto? insuranceCostReadDto = service.getInsuranceCost(id);

    if(insuranceCostReadDto != null){
        return Results.Ok(insuranceCostReadDto);
    }else{
        return Results.NotFound("Product Not Found");
    }
});

// I left this here to show i ran the bulkupdate. Not the nice way but i ran out of time because of datamodelrelationship issue
app.MapGet("bd7ca01ddbc2RunBulkUpdate", (AppDbContext context) =>
{
    BulkImport bulkImport = new BulkImport(context);

    String productJsonFile = app.Environment.ContentRootPath + "/Resources/products.json";
    String productTypeJsonFile = app.Environment.ContentRootPath + "/Resources/productTypes.json";

    bulkImport.startBulkImport(productJsonFile, productTypeJsonFile);

    return Results.Ok("Has been run");
});

app.Run();
