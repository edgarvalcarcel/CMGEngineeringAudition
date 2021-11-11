using AspNetCoreHero.Abstractions.Domain;
using AspNetCoreHero.EntityFrameworkCore.Auditing;
using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.Contexts;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using CMGEngineeringAudition.Domain.Common;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.DbContexts
{
    public class ApplicationDbContext : AuditableContext, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTime;
        //private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>().ToList())
            {
                var entityType = entry.Entity.GetType().Name;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.NowUtc;
                        //entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDate = _dateTime.NowUtc;
                        //entry.Entity.LastUpdateBy = _authenticatedUser.UserId;
                        break;
                } 
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(19,4)");
            }
        }
    }
}
