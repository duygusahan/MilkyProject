using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.BusinnessLayer.Concrete;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.EntityFramework;
using MilkyProject.EntityLayer.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<ISliderService , SliderManager>();   
builder.Services.AddScoped<ISliderDal , EfSliderDal>();   


builder.Services.AddScoped<IProductService, ProductManager>();  
builder.Services.AddScoped<IProductDal , EfProductDal>();

builder.Services.AddScoped<IServiceService , ServiceManager>(); 
builder.Services.AddScoped<IServiceDal , EfServiceDal>(); 

builder.Services.AddScoped<IEmployeService , EmployeManager>();
builder.Services.AddScoped<IEmployeDal , EfEmployeDal>();  

builder.Services.AddScoped<IGalleryService , GalleryManager>(); 
builder.Services.AddScoped<IGalleryDal , EfGalleryDal>();   

builder.Services.AddScoped<IAdressDal , EfAdressDal>(); 
builder.Services.AddScoped<IAdressService , AdressManager>();   

builder.Services.AddScoped<ITestimonialDal , EfTestimonialDal>();   
builder.Services.AddScoped<ITestimonialService , TestimonialManager>(); 

builder.Services.AddScoped<INewsletterDal , EfNewsletterDal>();
builder.Services.AddScoped<INewsletterService ,  NewsletterManager>();

builder.Services.AddScoped<IContactDal , EfContactDal>();   
builder.Services.AddScoped<IContactService , ContactManager>(); 

builder.Services.AddScoped<ISocialMediaDal , EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService , SocialMediaManager>(); 

builder.Services.AddScoped<IJobDal , EfJobDal>();
builder.Services.AddScoped<IJobService , JobManager>(); 

builder.Services.AddControllersWithViews().AddJsonOptions(options=>options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<MilkyContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MilkyContext>();

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
