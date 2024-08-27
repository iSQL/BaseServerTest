using BaseServerTest.Shared.Domain;
using BaseServerTest.Shared.Domain.Chat;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.ServiceModel.Channels;

namespace BaseServerTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ClassifiedUser> ClassifiedUsers { get; set; }
        public DbSet<ClassifiedAd> ClassifiedAds { get; set; }
        public DbSet<ClassifiedMessage> ClassifiedMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Put some appointments in
            DateTime date = DateTime.Today;
            builder.Entity<Appointment>().HasData(new Appointment {
                    AppointmentId = 1,
                    Caption = "Šišanje",
                    StartDate = date + (new TimeSpan(0,  14, 0, 0)),
                    EndDate = date + (new TimeSpan(0, 16, 30, 0)),
                    Label = 1,
                    Status = 1
                });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 2,
                Caption = "Kod mehaničara",
                StartDate = date + (new TimeSpan(2, 11, 30, 0)),
                EndDate = date + (new TimeSpan(2, 13, 30, 0)),
                Label = 6,
                Status = 1
            });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 3,
                Caption = "Šetnja sa patikama",
                StartDate = date + (new TimeSpan(1, 8, 0, 0)),
                EndDate = date + (new TimeSpan(1, 8, 30, 0)),
                Label = 2,
                Status = 1
            });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 4,
                Caption = "Gledanje u Mesec",
                StartDate = date + (new TimeSpan(0, 1, 0, 0)),
                EndDate = date + (new TimeSpan(0, 1, 30, 0)),
                Label = 3,
                Status = 1
            });

            builder.Entity<ClassifiedMessage>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassifiedMessage>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassifiedMessage>()
                .HasOne(m => m.ClassifiedAd)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ClassifiedAdId);
        }

    }
}
