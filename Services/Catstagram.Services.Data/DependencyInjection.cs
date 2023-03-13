using Catstagram.Services.Data.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Catstagram.Services.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatstagramServices(this IServiceCollection services)
        {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }
    }
}
