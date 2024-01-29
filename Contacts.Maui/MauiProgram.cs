namespace Contacts.Maui;

using Contacts.Maui.Repositories;
using Contacts.Maui.Views;

using Microsoft.Extensions.Logging;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<AddContactPage>();
        builder.Services.AddSingleton<EditContactPage>();
        builder.Services.AddSingleton<IContactsRepository, ContactsRepository>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
