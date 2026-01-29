using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    IsVerfied = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    RejectReason = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    PendingBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalWithdrawn = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ProgressPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EnrolledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    WalletTransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BalanceAfterTransaction = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.WalletTransactionId);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrollmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    IsSuccess = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EstimatedMinutes = table.Column<int>(type: "integer", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonItems",
                columns: table => new
                {
                    LessonItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonItems", x => x.LessonItemId);
                    table.ForeignKey(
                        name: "FK_LessonItems_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessonProgresses",
                columns: table => new
                {
                    LessonProgressId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWatchedSecond = table.Column<int>(type: "integer", nullable: true),
                    CompletionPercent = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonProgresses", x => x.LessonProgressId);
                    table.ForeignKey(
                        name: "FK_UserLessonProgresses_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLessonProgresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradedItems",
                columns: table => new
                {
                    GradedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxScore = table.Column<int>(type: "integer", nullable: false),
                    IsAutoGraded = table.Column<bool>(type: "boolean", nullable: false),
                    GradedItemType = table.Column<int>(type: "integer", nullable: false),
                    SubmissionGuidelines = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradedItems", x => x.GradedItemId);
                    table.ForeignKey(
                        name: "FK_GradedItems_LessonItems_LessonItemId",
                        column: x => x.LessonItemId,
                        principalTable: "LessonItems",
                        principalColumn: "LessonItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonResources",
                columns: table => new
                {
                    LessonResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ResourceType = table.Column<int>(type: "integer", nullable: false),
                    ResourceUrl = table.Column<string>(type: "text", nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    TextContent = table.Column<string>(type: "text", nullable: true),
                    DurationInSeconds = table.Column<long>(type: "bigint", nullable: true),
                    IsDownloadable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonResources", x => x.LessonResourceId);
                    table.ForeignKey(
                        name: "FK_LessonResources_LessonItems_LessonItemId",
                        column: x => x.LessonItemId,
                        principalTable: "LessonItems",
                        principalColumn: "LessonItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradedAttempts",
                columns: table => new
                {
                    GradedAttemptId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GradedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttemptNumber = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GradedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Score = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxScore = table.Column<int>(type: "integer", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    SubmittedText = table.Column<string>(type: "text", nullable: true),
                    FileUrl = table.Column<string>(type: "text", nullable: true),
                    AudioUrl = table.Column<string>(type: "text", nullable: true),
                    Feedback = table.Column<string>(type: "text", nullable: true),
                    GradedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradedAttempts", x => x.GradedAttemptId);
                    table.ForeignKey(
                        name: "FK_GradedAttempts_GradedItems_GradedAttemptId",
                        column: x => x.GradedAttemptId,
                        principalTable: "GradedItems",
                        principalColumn: "GradedItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradedAttempts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    GradedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: true),
                    Explanation = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_GradedItems_GradedItemId",
                        column: x => x.GradedItemId,
                        principalTable: "GradedItems",
                        principalColumn: "GradedItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerOptions",
                columns: table => new
                {
                    AnswerOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Explanation = table.Column<string>(type: "text", nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOptions", x => x.AnswerOptionId);
                    table.ForeignKey(
                        name: "FK_AnswerOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSubmissions",
                columns: table => new
                {
                    QuestionSubmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    GradedAttemptId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerText = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<decimal>(type: "numeric", nullable: true),
                    IsAutoGraded = table.Column<bool>(type: "boolean", nullable: false),
                    Feedback = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSubmissions", x => x.QuestionSubmissionId);
                    table.ForeignKey(
                        name: "FK_QuestionSubmissions_GradedAttempts_GradedAttemptId",
                        column: x => x.GradedAttemptId,
                        principalTable: "GradedAttempts",
                        principalColumn: "GradedAttemptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSubmissions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionAnswerOptions",
                columns: table => new
                {
                    SubmissionAnswerOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionSubmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionAnswerOptions", x => x.SubmissionAnswerOptionId);
                    table.ForeignKey(
                        name: "FK_SubmissionAnswerOptions_AnswerOptions_AnswerOptionId",
                        column: x => x.AnswerOptionId,
                        principalTable: "AnswerOptions",
                        principalColumn: "AnswerOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmissionAnswerOptions_QuestionSubmissions_QuestionSubmiss~",
                        column: x => x.QuestionSubmissionId,
                        principalTable: "QuestionSubmissions",
                        principalColumn: "QuestionSubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Code", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "en", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8864), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "English", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "ja", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8875), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Japanese", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "ko", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8877), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Korean", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "zh", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8878), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Chinese", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "es", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8879), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Spanish", null, null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "fr", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8881), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "French", null, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "de", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8882), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "German", null, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "vi", new DateTime(2026, 1, 28, 23, 58, 33, 813, DateTimeKind.Utc).AddTicks(8883), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Vietnamese", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "CreatedAt", "CreatedBy", "Email", "FullName", "Image", "IsDeleted", "IsVerfied", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new DateTime(2026, 1, 28, 23, 58, 33, 818, DateTimeKind.Utc).AddTicks(1467), new Guid("00000000-0000-0000-0000-000000000000"), "Student1@gmail.com", "Student1", null, false, true, new byte[] { 8, 20, 6, 53, 33, 107, 242, 26, 88, 252, 125, 52, 226, 34, 168, 21, 101, 143, 201, 163, 94, 180, 206, 163, 50, 20, 33, 5, 22, 97, 72, 114, 108, 208, 34, 53, 59, 62, 181, 141, 80, 156, 11, 24, 115, 123, 149, 182, 24, 223, 41, 120, 247, 163, 61, 198, 158, 144, 125, 23, 38, 214, 188, 78 }, new byte[] { 118, 33, 95, 21, 242, 154, 60, 149, 81, 165, 13, 195, 28, 170, 27, 137, 183, 39, 56, 254, 53, 104, 148, 207, 230, 97, 120, 73, 236, 143, 209, 96, 94, 83, 77, 223, 64, 233, 179, 154, 13, 184, 24, 237, 10, 168, 127, 189, 37, 76, 10, 75, 152, 245, 28, 149, 181, 160, 18, 102, 239, 237, 235, 241, 144, 33, 105, 58, 149, 46, 201, 165, 96, 199, 22, 243, 156, 58, 59, 4, 236, 125, 215, 216, 189, 249, 102, 160, 74, 187, 100, 237, 200, 249, 47, 140, 255, 46, 186, 78, 77, 147, 184, 164, 246, 250, 150, 123, 168, 20, 19, 249, 253, 193, 102, 20, 202, 148, 5, 157, 159, 19, 254, 145, 94, 103, 220, 171 }, null, 0, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new DateTime(2026, 1, 28, 23, 58, 33, 818, DateTimeKind.Utc).AddTicks(1477), new Guid("00000000-0000-0000-0000-000000000000"), "Student2@gmail.com", "Student2", null, false, true, new byte[] { 100, 238, 229, 175, 9, 128, 153, 71, 160, 2, 23, 147, 92, 244, 210, 135, 130, 242, 130, 20, 91, 8, 91, 209, 236, 26, 113, 172, 74, 50, 75, 234, 4, 32, 72, 12, 106, 141, 68, 52, 163, 147, 29, 83, 84, 22, 94, 150, 33, 44, 78, 246, 78, 59, 210, 41, 70, 76, 87, 133, 13, 157, 253, 120 }, new byte[] { 176, 147, 59, 195, 134, 9, 243, 109, 23, 225, 162, 1, 69, 217, 174, 247, 55, 40, 233, 80, 172, 154, 207, 208, 109, 101, 124, 133, 63, 32, 46, 43, 170, 219, 217, 228, 46, 122, 181, 141, 130, 237, 46, 93, 35, 141, 73, 110, 234, 32, 48, 13, 252, 254, 190, 176, 192, 97, 136, 109, 248, 127, 140, 173, 83, 232, 201, 159, 246, 105, 145, 86, 138, 215, 160, 146, 248, 89, 84, 189, 180, 208, 24, 83, 153, 35, 164, 37, 216, 2, 30, 101, 231, 32, 117, 186, 170, 99, 100, 205, 21, 114, 104, 219, 223, 245, 206, 25, 201, 130, 196, 21, 178, 252, 1, 113, 140, 10, 20, 233, 217, 50, 64, 148, 249, 36, 233, 71 }, null, 0, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new DateTime(2026, 1, 28, 23, 58, 33, 818, DateTimeKind.Utc).AddTicks(1480), new Guid("00000000-0000-0000-0000-000000000000"), "Employer@gmail.com", "Instructor", null, false, true, new byte[] { 25, 241, 155, 56, 191, 147, 220, 19, 50, 51, 152, 171, 17, 12, 235, 21, 100, 57, 26, 153, 110, 150, 155, 164, 154, 176, 209, 165, 20, 224, 106, 94, 135, 115, 119, 209, 219, 224, 117, 230, 61, 24, 38, 116, 181, 80, 196, 225, 221, 6, 204, 178, 158, 59, 56, 169, 233, 213, 34, 243, 144, 189, 52, 44 }, new byte[] { 73, 243, 175, 222, 159, 216, 81, 233, 66, 208, 3, 194, 253, 110, 141, 210, 142, 250, 109, 59, 3, 143, 124, 67, 228, 176, 93, 186, 231, 227, 211, 2, 82, 59, 193, 7, 69, 127, 29, 137, 29, 254, 162, 96, 243, 6, 55, 251, 156, 204, 46, 172, 133, 223, 233, 70, 2, 144, 177, 131, 101, 132, 125, 108, 145, 41, 95, 27, 246, 141, 254, 89, 229, 98, 156, 205, 125, 87, 255, 42, 251, 244, 14, 212, 137, 25, 131, 83, 113, 136, 176, 228, 11, 214, 132, 19, 194, 229, 242, 20, 58, 232, 231, 29, 252, 206, 167, 239, 92, 157, 202, 9, 71, 22, 241, 170, 152, 25, 164, 55, 90, 27, 70, 156, 166, 85, 199, 118 }, null, 0, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2026, 1, 28, 23, 58, 33, 818, DateTimeKind.Utc).AddTicks(1481), new Guid("00000000-0000-0000-0000-000000000000"), "Admin@gmail.com", "Admin", null, false, true, new byte[] { 107, 242, 92, 132, 119, 173, 73, 17, 183, 2, 83, 196, 81, 51, 93, 39, 186, 175, 193, 96, 40, 15, 104, 139, 115, 238, 168, 194, 16, 30, 114, 68, 82, 231, 129, 185, 122, 158, 146, 105, 83, 12, 121, 140, 136, 219, 110, 236, 226, 20, 14, 158, 123, 19, 193, 91, 239, 237, 65, 118, 19, 212, 124, 71 }, new byte[] { 50, 34, 17, 142, 173, 240, 117, 233, 58, 54, 34, 175, 226, 56, 26, 86, 188, 22, 253, 117, 106, 10, 191, 41, 129, 96, 144, 208, 182, 232, 2, 124, 160, 127, 46, 98, 153, 190, 141, 152, 97, 41, 158, 1, 80, 119, 49, 18, 13, 252, 171, 245, 245, 101, 152, 48, 14, 225, 27, 159, 36, 91, 15, 253, 78, 141, 3, 202, 43, 93, 125, 38, 46, 213, 175, 65, 212, 20, 232, 98, 16, 151, 152, 161, 70, 48, 205, 78, 0, 18, 67, 100, 58, 143, 214, 130, 154, 100, 32, 147, 65, 51, 82, 42, 129, 165, 122, 250, 244, 199, 76, 124, 136, 33, 196, 103, 25, 164, 163, 121, 149, 44, 76, 116, 78, 112, 149, 71 }, null, 0, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_QuestionId",
                table: "AnswerOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GradedAttempts_UserId",
                table: "GradedAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GradedItems_LessonItemId",
                table: "GradedItems",
                column: "LessonItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonItems_LessonId",
                table: "LessonItems",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonResources_LessonItemId",
                table: "LessonResources",
                column: "LessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CourseId",
                table: "Payments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EnrollmentId",
                table: "Payments",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GradedItemId",
                table: "Questions",
                column: "GradedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubmissions_GradedAttemptId",
                table: "QuestionSubmissions",
                column: "GradedAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubmissions_QuestionId",
                table: "QuestionSubmissions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionAnswerOptions_AnswerOptionId",
                table: "SubmissionAnswerOptions",
                column: "AnswerOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionAnswerOptions_QuestionSubmissionId",
                table: "SubmissionAnswerOptions",
                column: "QuestionSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonProgresses_LessonId",
                table: "UserLessonProgresses",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonProgresses_UserId",
                table: "UserLessonProgresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletId",
                table: "WalletTransactions",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonResources");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SubmissionAnswerOptions");

            migrationBuilder.DropTable(
                name: "UserLessonProgresses");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "AnswerOptions");

            migrationBuilder.DropTable(
                name: "QuestionSubmissions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "GradedAttempts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GradedItems");

            migrationBuilder.DropTable(
                name: "LessonItems");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
