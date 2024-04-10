using Microsoft.EntityFrameworkCore;
using SignalR_Chat;   // пространство имен класса ChatHub

var builder = WebApplication.CreateBuilder(args);

// ѕолучаем строку подключени€ из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавл€ем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<MessageContext>(options => options.UseSqlServer(connection));

builder.Services.AddSignalR();  

var app = builder.Build();
// — помощью специального метода расширени€ UseDefaultFiles() можно настроить
// отправку статических веб-страниц по умолчанию без обращени€ к ним по полному пути.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");   // ChatHub будет обрабатывать запросы по пути /chat

app.Run();
