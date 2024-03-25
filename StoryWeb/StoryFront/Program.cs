using StoryFront;
using StoryFront.Services;
using StoryFront.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

SD.storyAPIBase = builder.Configuration["ServiceUrls:storyAPI"];
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpClient<IStoryService, StoryService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddHttpClient<IChapterService, ChapterService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddHttpClient<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpClient<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();

builder.Services.AddHttpContextAccessor();

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

