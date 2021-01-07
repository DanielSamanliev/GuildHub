namespace GuildHub.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventUser> EventsUsers { get; set; }

        public DbSet<ForumPost> ForumPosts { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameTag> GamesTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Guild> Guilds { get; set; }

        public DbSet<GuildAlly> GuildsAllies { get; set; }

        public DbSet<GuildTrophy> GuildsTrophies { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<LikeableEntity> LikeableEntities { get; set; }

        public DbSet<LikeableEntityLike> LikeableEntitiesLikes { get; set; }

        public DbSet<Trophy> Trophies { get; set; }

        public DbSet<UserGuild> UsersGuilds { get; set; }

        public DbSet<UserTrophy> UsersTrophies { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<GuildTag> GuildsTags { get; set; }

        public DbSet<Setting> Settings { get; set; }

        // For saving user usernames in each game
        public DbSet<UserGame> UsersGames { get; set; }

        public DbSet<GuildApplication> GuildApplications { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventUser>()
                .HasKey(x => new { x.EventId, x.UserId });

            builder.Entity<GameTag>()
                .HasKey(x => new { x.GameId, x.TagId });

            builder.Entity<GuildAlly>()
                .HasKey(x => new { x.GuildOneId, x.GuildTwoId });

            builder.Entity<GuildTrophy>()
                .HasKey(x => new { x.GuildId, x.TrophyId });

            builder.Entity<LikeableEntityLike>()
                .HasKey(x => new { x.LikeableEntityId, x.UserId });

            builder.Entity<UserGuild>()
                .HasKey(x => new { x.GuildId, x.UserId });

            builder.Entity<UserTrophy>()
                .HasKey(x => new { x.TrophyId, x.UserId });

            builder.Entity<Guild>()
                .HasMany(x => x.Allies).WithOne(x => x.GuildTwo);

            builder.Entity<GuildTag>()
                .HasKey(x => new { x.GuildId, x.TagId });

            builder.Entity<UserGame>()
                .HasKey(x => new { x.UserId, x.GameId });

            builder.Entity<GuildApplication>()
                .HasKey(x => new { x.UserId, x.GuildId });

            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
