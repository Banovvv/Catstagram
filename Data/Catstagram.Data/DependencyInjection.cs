using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catstagram.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatstagramRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
