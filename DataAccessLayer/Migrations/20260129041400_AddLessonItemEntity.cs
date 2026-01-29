using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddLessonItemEntity : Migration
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), "en", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(314), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "English", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "ja", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(327), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Japanese", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "ko", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(331), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Korean", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "zh", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(332), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Chinese", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "es", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(334), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Spanish", null, null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "fr", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(336), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "French", null, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "de", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(337), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "German", null, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "vi", new DateTime(2026, 1, 29, 4, 13, 58, 149, DateTimeKind.Utc).AddTicks(339), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Vietnamese", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "CreatedAt", "CreatedBy", "Email", "FullName", "Image", "IsDeleted", "IsVerfied", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new DateTime(2026, 1, 29, 4, 13, 58, 153, DateTimeKind.Utc).AddTicks(3613), new Guid("00000000-0000-0000-0000-000000000000"), "Student1@gmail.com", "Student1", null, false, true, new byte[] { 255, 43, 201, 3, 140, 238, 21, 134, 217, 199, 247, 133, 15, 214, 63, 114, 227, 39, 165, 91, 125, 95, 170, 111, 106, 94, 234, 187, 133, 239, 92, 233, 251, 197, 56, 234, 99, 67, 214, 26, 222, 191, 20, 250, 34, 129, 112, 66, 22, 185, 116, 90, 150, 174, 148, 136, 111, 219, 108, 66, 165, 44, 39, 65 }, new byte[] { 46, 193, 102, 81, 235, 157, 24, 0, 20, 30, 87, 133, 121, 22, 235, 105, 70, 197, 239, 142, 107, 116, 54, 25, 53, 13, 4, 23, 203, 240, 126, 99, 141, 117, 77, 42, 23, 186, 45, 107, 23, 116, 75, 174, 255, 131, 158, 202, 118, 100, 168, 125, 185, 81, 245, 254, 198, 248, 75, 251, 185, 169, 10, 78, 168, 111, 11, 80, 189, 166, 54, 158, 66, 59, 172, 29, 156, 59, 141, 212, 79, 240, 44, 72, 90, 252, 88, 68, 173, 223, 220, 234, 242, 101, 173, 213, 32, 33, 106, 202, 220, 183, 180, 53, 99, 197, 148, 203, 69, 31, 84, 209, 100, 51, 255, 88, 126, 216, 74, 235, 166, 205, 202, 136, 52, 234, 94, 6 }, null, 0, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new DateTime(2026, 1, 29, 4, 13, 58, 153, DateTimeKind.Utc).AddTicks(3619), new Guid("00000000-0000-0000-0000-000000000000"), "Student2@gmail.com", "Student2", null, false, true, new byte[] { 101, 33, 238, 142, 237, 209, 88, 137, 159, 215, 44, 237, 82, 80, 120, 144, 59, 16, 35, 120, 254, 24, 114, 168, 198, 228, 108, 121, 175, 106, 85, 219, 150, 75, 249, 45, 185, 145, 149, 131, 77, 76, 19, 8, 178, 224, 244, 169, 205, 18, 89, 154, 27, 254, 239, 249, 179, 24, 240, 254, 174, 163, 82, 238 }, new byte[] { 139, 124, 146, 110, 117, 13, 153, 24, 49, 57, 143, 101, 170, 113, 42, 42, 29, 8, 50, 1, 31, 230, 247, 133, 3, 112, 81, 129, 67, 116, 19, 245, 153, 151, 74, 146, 241, 144, 38, 222, 87, 171, 71, 158, 157, 112, 103, 211, 247, 65, 125, 54, 205, 67, 38, 235, 222, 61, 121, 252, 249, 140, 209, 67, 19, 6, 37, 94, 53, 26, 81, 113, 116, 241, 112, 0, 53, 119, 150, 198, 60, 97, 1, 252, 153, 47, 196, 3, 20, 71, 235, 192, 73, 158, 101, 148, 163, 204, 132, 61, 177, 68, 69, 90, 144, 167, 22, 136, 181, 234, 139, 162, 171, 59, 213, 226, 191, 227, 241, 33, 169, 248, 193, 20, 241, 65, 181, 10 }, null, 0, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new DateTime(2026, 1, 29, 4, 13, 58, 153, DateTimeKind.Utc).AddTicks(3622), new Guid("00000000-0000-0000-0000-000000000000"), "Employer@gmail.com", "Instructor", null, false, true, new byte[] { 122, 197, 244, 100, 21, 11, 0, 206, 141, 195, 13, 98, 45, 35, 75, 55, 172, 52, 7, 159, 186, 245, 215, 53, 210, 27, 98, 12, 251, 135, 214, 130, 128, 172, 175, 52, 212, 98, 223, 26, 92, 43, 1, 170, 254, 1, 62, 109, 178, 42, 38, 24, 87, 150, 94, 113, 99, 23, 222, 97, 129, 14, 62, 89 }, new byte[] { 71, 10, 210, 32, 73, 170, 134, 38, 0, 117, 165, 165, 60, 179, 25, 1, 190, 21, 4, 47, 71, 168, 113, 85, 74, 239, 123, 213, 217, 190, 210, 2, 96, 238, 222, 4, 53, 72, 117, 192, 52, 172, 91, 82, 41, 154, 29, 124, 238, 93, 83, 84, 253, 160, 2, 194, 174, 200, 196, 80, 137, 121, 202, 115, 80, 162, 130, 196, 118, 93, 240, 138, 79, 111, 183, 1, 40, 87, 73, 222, 194, 63, 176, 98, 180, 43, 216, 198, 200, 220, 44, 144, 24, 162, 10, 191, 220, 12, 1, 77, 233, 72, 145, 39, 167, 166, 240, 94, 46, 88, 73, 122, 126, 15, 116, 62, 168, 93, 157, 230, 210, 197, 145, 171, 49, 59, 240, 47 }, null, 0, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2026, 1, 29, 4, 13, 58, 153, DateTimeKind.Utc).AddTicks(3623), new Guid("00000000-0000-0000-0000-000000000000"), "Admin@gmail.com", "Admin", null, false, true, new byte[] { 176, 162, 114, 198, 171, 232, 120, 206, 41, 154, 75, 61, 59, 66, 23, 110, 110, 214, 187, 64, 62, 34, 44, 102, 228, 253, 21, 200, 123, 219, 199, 209, 170, 99, 97, 251, 119, 159, 48, 156, 121, 93, 135, 152, 3, 220, 63, 11, 154, 250, 244, 183, 82, 71, 235, 233, 178, 242, 153, 180, 70, 56, 249, 73 }, new byte[] { 231, 15, 144, 222, 237, 87, 10, 181, 40, 221, 60, 140, 120, 229, 225, 192, 208, 60, 222, 206, 225, 128, 117, 148, 149, 249, 22, 71, 247, 39, 196, 71, 192, 52, 59, 182, 79, 75, 106, 249, 3, 172, 23, 145, 223, 211, 68, 1, 35, 44, 197, 134, 66, 241, 10, 175, 135, 191, 164, 19, 7, 38, 58, 55, 85, 204, 66, 8, 208, 132, 147, 177, 137, 248, 121, 127, 94, 215, 241, 226, 11, 26, 5, 46, 64, 114, 45, 118, 78, 71, 91, 136, 146, 100, 251, 108, 119, 43, 30, 64, 213, 232, 252, 195, 51, 106, 105, 104, 92, 34, 84, 68, 175, 72, 230, 218, 108, 67, 38, 5, 155, 89, 71, 254, 147, 128, 129, 179 }, null, 0, null, null, null }
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
