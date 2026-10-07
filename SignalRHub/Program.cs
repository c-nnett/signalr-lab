using SignalRHub.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
    }); 
});

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

/**
 * CORS (Cross-Origin Resource Sharing) is a security feature implemented by web browsers to restrict web pages from making requests to a different domain than the one that served the web page. 
 * It is a mechanism that allows servers to specify who can access their resources and how they can be accessed.
 * 
 * In this code snippet, the app.UseCors() method is called to enable CORS for the application. 
 * This means that the application will allow cross-origin requests based on the CORS policy defined earlier in the code.
 * 
 * The CORS policy defined in this code allows any origin to access the resources of the application, allows any header, and allows only GET and POST methods. 
 * It also allows credentials to be included in the requests.
 */
app.UseCors();

app.MapRazorPages();

/**
 * The map method is used to define a route for the SignalR hub. In this case, the route is "/chathub", which means that clients can connect to the ChatHub by sending requests to this URL.
 */
app.MapHub<ChatHub>("/chathub");

app.Run();