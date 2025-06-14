﻿using LocalMindApi.Models.ChatDetails;
using LocalMindApi.Models.Chats;
using LocalMindApi.Models.UserAdditionalDetails;
using LocalMindApi.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocalMindApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAdditionalDetail> UserAdditionalDetails { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatDetail> ChatDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAdditionalDetail>()
                .HasOne(userAdditionalDetail => userAdditionalDetail.User)
                .WithOne(user => user.UserAdditionalDetail)
                .HasForeignKey<UserAdditionalDetail>(
                    userAdditionalDetail => userAdditionalDetail.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
