// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordApi;

namespace WordApi.Migrations
{
    [DbContext(typeof(WordMasterDbContext))]
    partial class WordMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WordApi.Entities.AnswerStastistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AskCount")
                        .HasColumnType("int");

                    b.Property<int>("CorrectCount")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordDefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnswerStastistics");
                });

            modelBuilder.Entity("WordApi.Entities.WordDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WordDefinitions");
                });

            modelBuilder.Entity("WordApi.Entities.WordMeaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Meaning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WordDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordDefinitionId");

                    b.ToTable("WordMeanings");
                });

            modelBuilder.Entity("WordApi.Entities.WordMeaning", b =>
                {
                    b.HasOne("WordApi.Entities.WordDefinition", "WordDef")
                        .WithMany("Meanings")
                        .HasForeignKey("WordDefinitionId");

                    b.Navigation("WordDef");
                });

            modelBuilder.Entity("WordApi.Entities.WordDefinition", b =>
                {
                    b.Navigation("Meanings");
                });
#pragma warning restore 612, 618
        }
    }
}
