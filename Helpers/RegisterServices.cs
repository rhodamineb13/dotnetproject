using dotnetproject.Repository;
using dotnetproject.Usecase;

namespace dotnetproject.Helpers;

public static class ServiceRegistrations {
    public static IServiceCollection AddBookService(this IServiceCollection services) {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookUsecase, BookUsecase>();
        return services;
    }
}