using Exam.Context;
using Exam.Dal.Abstract;
using Exam.Dal.Concrete;
using Exam.Entities;
using Exam.Repositories;
using Exam.Service.Abstract;
using Exam.Services.Abstract;
using Exam.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IExaminationService, ExaminationService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IExaminationDal, ExaminationDal>();
builder.Services.AddScoped<ILessonDal, LessonDal>();
builder.Services.AddScoped<IStudentDal, StudentDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Examination}/{action=Index}/{id?}");

app.Run();
