using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleRepository.Context.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221023120000_Initial")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ArticleRepository.Models.Article", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("UNIQUEIDENTIFIER");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<string>("Text")
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Articles");

                b.HasData(
                    new
                    {
                        Id = new Guid("0751883D-1E7D-4E97-AFBB-4857C71F24CD"),
                        Title = "Article 1",
                        Text = "Text of article 1"
                    },
                    new
                    {
                        Id = new Guid("0751883D-1E7D-4E97-AFBB-4857C71EEEEE"),
                        Title = "Article 2",
                        Text = System.DBNull.Value
                    });
            });
#pragma warning restore 612, 618
        }
    }
}