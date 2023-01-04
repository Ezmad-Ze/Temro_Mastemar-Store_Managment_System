using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TemroMastemar.Models;

namespace TemroMastemar.Data
{
    public class ApplicationDbContext : IdentityDbContext<DefaultUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Literature> Literatures { get; set; }
        public DbSet<Children_Literature> C_Literatures { get; set; }
        public DbSet<TakenLiterature> TakenLiteratures { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Plan_and_Report> Plan_and_Report { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Audio> Audios { get; set; }
    }
}
//Made by Endeamlak. Z