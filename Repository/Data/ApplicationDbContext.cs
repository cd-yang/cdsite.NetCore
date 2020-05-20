using AspNetCoreTodo.Model.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Repository.Data
{
    /// <summary>
    /// 数据库结构发生修改后，在 Repository 目录下执行:
    ///     dotnet ef migrations add MIGRATION_NAME -s ..\AspNetCoreTodo\
    ///     dotnet ef database update -s ../AspNetCoreTodo/
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 待办事项数据
        /// </summary>
        public DbSet<TodoItem> Items { get; set; }

        /// <summary>
        /// 所有文章
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// 所有作者
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
