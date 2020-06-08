using CdSite.Model.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CdSite.Repository.Data
{
    /// <summary>
    /// 数据库结构发生修改后，在 Repository 目录下执行:
    ///     dotnet ef migrations add MIGRATION_NAME -s ..\CdSite\
    ///     dotnet ef database update -s ../CdSite/
    /// 
    /// 若有字段删除，报错：SQLite does not support this migration operation ('DropColumnOperation')
    /// 解决方案：
    ///     1: remove current database
    ///     2. dotnet ef migrations remove -s ../CdSite/
    ///     3. dotnet ef migrations add initialCommit -s ../CdSite/
    ///     4: dotnet ef database update -s ../CdSite/
    /// /// 
    /// TODO: 下次 Model 变动时，将 /Data 移动到 Model 工程下
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
