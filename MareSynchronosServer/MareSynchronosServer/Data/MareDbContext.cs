﻿using MareSynchronosServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MareSynchronosServer.Data
{
    public class MareDbContext : DbContext
    {
        public MareDbContext(DbContextOptions<MareDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FileCache> Files { get; set; }
        public DbSet<ClientPair> ClientPairs { get; set; }
        public DbSet<ForbiddenUploadEntry> ForbiddenUploadEntries { get; set; }
        public DbSet<Banned> BannedUsers { get; set; }
        public DbSet<Auth> Auth { get; set; }
        public DbSet<LodeStoneAuth> LodeStoneAuth { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auth>().ToTable("auth");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasIndex(c => c.CharacterIdentification);
            modelBuilder.Entity<FileCache>().ToTable("file_caches");
            modelBuilder.Entity<FileCache>().HasIndex(c => c.UploaderUID);
            modelBuilder.Entity<ClientPair>().ToTable("client_pairs");
            modelBuilder.Entity<ClientPair>().HasKey(u => new { u.UserUID, u.OtherUserUID });
            modelBuilder.Entity<ClientPair>().HasIndex(c => c.UserUID);
            modelBuilder.Entity<ClientPair>().HasIndex(c => c.OtherUserUID);
            modelBuilder.Entity<ForbiddenUploadEntry>().ToTable("forbidden_upload_entries");
            modelBuilder.Entity<Banned>().ToTable("banned_users");
            modelBuilder.Entity<LodeStoneAuth>().ToTable("lodestone_auth");
        }
    }
}
