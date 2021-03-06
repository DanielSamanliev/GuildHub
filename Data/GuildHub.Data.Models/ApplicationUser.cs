﻿// ReSharper disable VirtualMemberCallInConstructor
namespace GuildHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Guilds = new HashSet<UserGuild>();
            this.Games = new HashSet<UserGame>();
            this.Trophies = new HashSet<UserTrophy>();
            this.Applications = new HashSet<GuildApplication>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<UserGuild> Guilds { get; set; }

        public virtual ICollection<UserTrophy> Trophies { get; set; }

        public virtual ICollection<UserGame> Games { get; set; }

        public virtual ICollection<GuildApplication> Applications { get; set; }
    }
}
