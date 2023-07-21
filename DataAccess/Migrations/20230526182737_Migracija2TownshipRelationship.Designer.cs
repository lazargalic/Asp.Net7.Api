﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Asp2023DbContext))]
    [Migration("20230526182737_Migracija2TownshipRelationship")]
    partial class Migracija2TownshipRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalDescription")
                        .HasMaxLength(445)
                        .HasColumnType("nvarchar(445)");

                    b.Property<DateTime>("Beggin")
                        .HasColumnType("datetime2");

                    b.Property<int>("CategoryDesignArticleId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryDimensionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(745)
                        .HasColumnType("nvarchar(745)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainContent")
                        .HasMaxLength(6445)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainPicturePath")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<string>("NameArticle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("NonRegisteredUserId")
                        .HasColumnType("int");

                    b.Property<string>("Quote")
                        .HasMaxLength(385)
                        .HasColumnType("nvarchar(385)");

                    b.Property<int>("TownshipId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Beggin");

                    b.HasIndex("CategoryDesignArticleId");

                    b.HasIndex("CategoryDimensionId");

                    b.HasIndex("End");

                    b.HasIndex("NameArticle");

                    b.HasIndex("NonRegisteredUserId")
                        .IsUnique()
                        .HasFilter("[NonRegisteredUserId] IS NOT NULL");

                    b.HasIndex("TownshipId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Domain.ArticleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alt")
                        .HasMaxLength(110)
                        .HasColumnType("nvarchar(110)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(245)
                        .HasColumnType("nvarchar(245)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleImages");
                });

            modelBuilder.Entity("Domain.ArticleUserEmotion", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("EmotionId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "UserId");

                    b.HasIndex("EmotionId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleUserEmotions");
                });

            modelBuilder.Entity("Domain.CategoryComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryDimensionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("NameCategoryComment")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("StylePath")
                        .IsRequired()
                        .HasMaxLength(245)
                        .HasColumnType("nvarchar(245)");

                    b.HasKey("Id");

                    b.HasIndex("NameCategoryComment")
                        .IsUnique();

                    b.ToTable("CategoryComments");
                });

            modelBuilder.Entity("Domain.CategoryDesignArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DesignPath")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("nvarchar(240)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("NameDesign")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("NameDesign")
                        .IsUnique();

                    b.ToTable("CategoryDesignArticle");
                });

            modelBuilder.Entity("Domain.CategoryDimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dimension")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Dimension")
                        .IsUnique();

                    b.ToTable("CategoryDimensions");
                });

            modelBuilder.Entity("Domain.CommentArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryCommentId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryDimensionId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasMaxLength(245)
                        .HasColumnType("nvarchar(245)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParrentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CategoryCommentId");

                    b.HasIndex("CategoryDimensionId");

                    b.HasIndex("ParrentCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentArticles");
                });

            modelBuilder.Entity("Domain.CommentArticleSticker", b =>
                {
                    b.Property<int>("CommentArticleId")
                        .HasColumnType("int");

                    b.Property<int>("StickerId")
                        .HasColumnType("int");

                    b.HasKey("CommentArticleId", "StickerId");

                    b.HasIndex("StickerId");

                    b.ToTable("CommentArticleStickers");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameCompany")
                        .IsRequired()
                        .HasMaxLength(115)
                        .HasColumnType("nvarchar(115)");

                    b.HasKey("Id");

                    b.HasIndex("NameCompany")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameCountry")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)");

                    b.HasKey("Id");

                    b.HasIndex("NameCountry")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Emotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NameEmotion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("NameEmotion")
                        .IsUnique();

                    b.ToTable("Emotions");
                });

            modelBuilder.Entity("Domain.NonRegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("NonRegisteredUser");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("NameRole")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Sticker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("NameSticker")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("StickerPath")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("nvarchar(240)");

                    b.HasKey("Id");

                    b.HasIndex("NameSticker")
                        .IsUnique();

                    b.ToTable("Stickers");
                });

            modelBuilder.Entity("Domain.Township", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("NameTownship")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NameTownship")
                        .IsUnique();

                    b.ToTable("Townships");
                });

            modelBuilder.Entity("Domain.UseCaseRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UseCaseRole");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdentityNumber")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.UserCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("Domain.Article", b =>
                {
                    b.HasOne("Domain.CategoryDesignArticle", "CategoryDesignArticle")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryDesignArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.CategoryDimension", "CategoryDimension")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryDimensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.NonRegisteredUser", "NonRegisteredUser")
                        .WithOne("Article")
                        .HasForeignKey("Domain.Article", "NonRegisteredUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Township", "Township")
                        .WithMany("Articles")
                        .HasForeignKey("TownshipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryDesignArticle");

                    b.Navigation("CategoryDimension");

                    b.Navigation("NonRegisteredUser");

                    b.Navigation("Township");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.ArticleImage", b =>
                {
                    b.HasOne("Domain.Article", "Article")
                        .WithMany("ArticleImages")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Domain.ArticleUserEmotion", b =>
                {
                    b.HasOne("Domain.Article", "Article")
                        .WithMany("ArticleUserEmotions")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Emotion", "Emotion")
                        .WithMany("ArticleUserEmotions")
                        .HasForeignKey("EmotionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("ArticleUserEmotions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Emotion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.CommentArticle", b =>
                {
                    b.HasOne("Domain.Article", "Article")
                        .WithMany("CommentArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.CategoryComment", "CategoryComment")
                        .WithMany("CommentArticles")
                        .HasForeignKey("CategoryCommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.CategoryDimension", "CategoryDimension")
                        .WithMany("CommentArticles")
                        .HasForeignKey("CategoryDimensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.CommentArticle", "ParentComment")
                        .WithMany("ChildComments")
                        .HasForeignKey("ParrentCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.User", "User")
                        .WithMany("CommentArticles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("CategoryComment");

                    b.Navigation("CategoryDimension");

                    b.Navigation("ParentComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.CommentArticleSticker", b =>
                {
                    b.HasOne("Domain.CommentArticle", "CommentArticle")
                        .WithMany("CommentArticleStickers")
                        .HasForeignKey("CommentArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Sticker", "Sticker")
                        .WithMany("CommentArticleStickers")
                        .HasForeignKey("StickerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CommentArticle");

                    b.Navigation("Sticker");
                });

            modelBuilder.Entity("Domain.Township", b =>
                {
                    b.HasOne("Domain.Country", "Country")
                        .WithMany("Townships")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.UseCaseRole", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany("UseCaseRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.UserCompany", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("UserCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("UserCompanys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Article", b =>
                {
                    b.Navigation("ArticleImages");

                    b.Navigation("ArticleUserEmotions");

                    b.Navigation("CommentArticles");
                });

            modelBuilder.Entity("Domain.CategoryComment", b =>
                {
                    b.Navigation("CommentArticles");
                });

            modelBuilder.Entity("Domain.CategoryDesignArticle", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Domain.CategoryDimension", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("CommentArticles");
                });

            modelBuilder.Entity("Domain.CommentArticle", b =>
                {
                    b.Navigation("ChildComments");

                    b.Navigation("CommentArticleStickers");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Navigation("UserCompany");
                });

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.Navigation("Townships");
                });

            modelBuilder.Entity("Domain.Emotion", b =>
                {
                    b.Navigation("ArticleUserEmotions");
                });

            modelBuilder.Entity("Domain.NonRegisteredUser", b =>
                {
                    b.Navigation("Article")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Navigation("UseCaseRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Sticker", b =>
                {
                    b.Navigation("CommentArticleStickers");
                });

            modelBuilder.Entity("Domain.Township", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("ArticleUserEmotions");

                    b.Navigation("Articles");

                    b.Navigation("CommentArticles");

                    b.Navigation("UserCompanys");
                });
#pragma warning restore 612, 618
        }
    }
}
