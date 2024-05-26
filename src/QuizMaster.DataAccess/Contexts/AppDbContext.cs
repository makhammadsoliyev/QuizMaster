using Microsoft.EntityFrameworkCore;
using QuizMaster.Domain.Entities;

namespace QuizMaster.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<QuizResult> QuizResults { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<QuizApplication> QuizApplications { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .HasOne(question => question.Category)
            .WithMany()
            .HasForeignKey(question => question.CategoryId);

        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(questionAnswer => questionAnswer.QuizApplication)
            .WithMany()
            .HasForeignKey(questionAnswer => questionAnswer.QuizApplicationId);

        modelBuilder.Entity<QuestionAnswer>()
           .HasOne(questionAnswer => questionAnswer.QuestionOption)
           .WithMany()
           .HasForeignKey(questionAnswer => questionAnswer.QuestionOptionId);

        modelBuilder.Entity<QuestionOption>()
            .HasOne(questionOption => questionOption.Question)
            .WithMany(question => question.Options)
            .HasForeignKey(questionOption => questionOption.QuestionId);

        modelBuilder.Entity<Quiz>()
            .HasOne(quiz => quiz.Category)
            .WithMany()
            .HasForeignKey(quiz => quiz.CategoryId);

        modelBuilder.Entity<QuizApplication>()
            .HasOne(quizApplication => quizApplication.Quiz)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.QuizId);

        modelBuilder.Entity<QuizApplication>()
            .HasOne(quizApplication => quizApplication.User)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.UserId);

        modelBuilder.Entity<QuizQuestion>()
            .HasOne(quizQuestion => quizQuestion.Question)
            .WithMany()
            .HasForeignKey(quizQuestion => quizQuestion.QuestionId);

        modelBuilder.Entity<QuizQuestion>()
           .HasOne(quizQuestion => quizQuestion.Quiz)
           .WithMany()
           .HasForeignKey(quizQuestion => quizQuestion.QuizId);

        modelBuilder.Entity<QuizResult>()
           .HasOne(quizResult => quizResult.QuizApplication)
           .WithMany()
           .HasForeignKey(quizResult => quizResult.QuizApplicationId);
    }
}

