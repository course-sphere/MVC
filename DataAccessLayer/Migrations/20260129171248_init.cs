using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    OrderCode = table.Column<long>(type: "bigint", nullable: false),
                    PaymentLinkId = table.Column<string>(type: "text", nullable: false),
                    CheckoutUrl = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    CounterAccountNumber = table.Column<string>(type: "text", nullable: true),
                    CounterAccountName = table.Column<string>(type: "text", nullable: true),
                    CounterAccountBankName = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RawWebhookData = table.Column<string>(type: "text", nullable: true),
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), "en", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3424), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "English", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "ja", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3438), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Japanese", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "ko", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3441), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Korean", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "zh", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3442), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Chinese", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "es", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3444), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Spanish", null, null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "fr", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3446), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "French", null, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "de", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3447), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "German", null, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "vi", new DateTime(2026, 1, 29, 17, 12, 48, 336, DateTimeKind.Utc).AddTicks(3449), new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Vietnamese", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "CreatedAt", "CreatedBy", "Email", "FullName", "Image", "IsDeleted", "IsVerfied", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new DateTime(2026, 1, 29, 17, 12, 48, 340, DateTimeKind.Utc).AddTicks(5414), new Guid("00000000-0000-0000-0000-000000000000"), "Student1@gmail.com", "Student1", null, false, true, new byte[] { 70, 125, 146, 217, 158, 229, 194, 96, 228, 4, 211, 82, 173, 28, 112, 15, 149, 16, 135, 210, 90, 147, 243, 133, 65, 24, 224, 102, 224, 166, 14, 66, 84, 129, 215, 167, 89, 48, 24, 154, 29, 198, 24, 53, 240, 183, 101, 87, 23, 198, 38, 163, 174, 22, 240, 136, 130, 107, 222, 80, 63, 65, 189, 119 }, new byte[] { 58, 14, 60, 95, 68, 64, 132, 246, 245, 249, 212, 61, 247, 190, 29, 35, 116, 200, 118, 120, 137, 227, 45, 176, 125, 46, 17, 219, 145, 8, 107, 132, 15, 210, 128, 28, 38, 79, 50, 210, 190, 114, 92, 211, 155, 28, 40, 125, 89, 161, 133, 210, 19, 75, 186, 2, 245, 227, 61, 160, 49, 47, 88, 103, 117, 24, 55, 4, 187, 95, 95, 107, 198, 223, 33, 95, 170, 133, 27, 32, 236, 153, 202, 165, 98, 152, 62, 71, 129, 162, 56, 5, 207, 186, 101, 155, 130, 18, 89, 19, 250, 80, 76, 133, 81, 67, 24, 240, 69, 226, 190, 192, 163, 31, 240, 37, 199, 171, 15, 27, 228, 34, 68, 97, 177, 18, 223, 168 }, null, 2, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new DateTime(2026, 1, 29, 17, 12, 48, 340, DateTimeKind.Utc).AddTicks(5421), new Guid("00000000-0000-0000-0000-000000000000"), "Student2@gmail.com", "Student2", null, false, true, new byte[] { 252, 226, 93, 93, 216, 223, 117, 255, 11, 145, 152, 29, 142, 206, 90, 216, 122, 153, 219, 83, 144, 214, 99, 239, 2, 57, 73, 245, 75, 214, 4, 12, 148, 111, 4, 3, 9, 116, 185, 48, 239, 126, 131, 121, 2, 165, 247, 168, 211, 214, 10, 242, 113, 225, 133, 223, 60, 126, 126, 165, 235, 77, 37, 156 }, new byte[] { 87, 200, 226, 136, 48, 163, 28, 61, 197, 179, 79, 176, 143, 232, 58, 104, 73, 34, 198, 117, 134, 127, 174, 247, 172, 35, 210, 132, 208, 2, 204, 32, 226, 27, 62, 252, 140, 227, 218, 178, 199, 140, 79, 189, 111, 138, 114, 100, 33, 152, 39, 75, 110, 12, 36, 7, 39, 163, 7, 6, 252, 80, 84, 30, 143, 100, 191, 12, 157, 55, 186, 225, 22, 172, 0, 89, 108, 232, 152, 26, 244, 59, 42, 207, 2, 245, 10, 65, 5, 118, 138, 17, 90, 68, 75, 130, 197, 37, 19, 187, 174, 28, 114, 33, 253, 76, 161, 137, 28, 105, 193, 61, 100, 222, 204, 104, 31, 154, 203, 197, 220, 193, 110, 175, 22, 75, 240, 101 }, null, 2, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new DateTime(2026, 1, 29, 17, 12, 48, 340, DateTimeKind.Utc).AddTicks(5424), new Guid("00000000-0000-0000-0000-000000000000"), "Instructor@gmail.com", "Instructor", null, false, true, new byte[] { 117, 39, 137, 24, 69, 41, 14, 128, 160, 150, 252, 160, 172, 234, 211, 35, 121, 245, 107, 36, 40, 35, 115, 167, 216, 29, 188, 243, 47, 48, 194, 89, 145, 77, 150, 83, 207, 177, 87, 104, 20, 78, 101, 188, 87, 76, 191, 147, 22, 210, 241, 221, 117, 185, 87, 84, 244, 58, 63, 140, 234, 21, 217, 45 }, new byte[] { 186, 48, 39, 20, 120, 220, 121, 92, 148, 231, 215, 173, 112, 38, 114, 25, 128, 222, 24, 219, 155, 84, 173, 110, 93, 172, 249, 137, 171, 31, 94, 66, 84, 58, 53, 61, 135, 168, 65, 39, 14, 89, 91, 229, 149, 118, 51, 133, 8, 170, 112, 3, 191, 47, 14, 11, 119, 22, 207, 171, 82, 105, 229, 107, 228, 159, 158, 79, 77, 153, 42, 183, 107, 61, 129, 128, 3, 185, 89, 79, 101, 203, 124, 89, 129, 160, 133, 212, 143, 3, 35, 168, 104, 9, 88, 244, 221, 101, 157, 75, 39, 246, 56, 12, 112, 18, 23, 97, 176, 210, 158, 30, 47, 157, 211, 158, 14, 26, 25, 157, 136, 201, 102, 11, 116, 135, 183, 251 }, null, 1, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2026, 1, 29, 17, 12, 48, 340, DateTimeKind.Utc).AddTicks(5426), new Guid("00000000-0000-0000-0000-000000000000"), "Admin@gmail.com", "Admin", null, false, true, new byte[] { 175, 167, 223, 218, 40, 210, 91, 42, 189, 58, 19, 28, 192, 169, 181, 165, 196, 67, 135, 230, 24, 176, 176, 208, 146, 5, 203, 196, 87, 240, 2, 106, 43, 59, 61, 186, 169, 99, 104, 166, 75, 219, 233, 130, 168, 66, 112, 51, 104, 96, 19, 248, 211, 123, 126, 12, 183, 133, 3, 28, 116, 184, 182, 34 }, new byte[] { 205, 239, 213, 75, 119, 170, 188, 242, 182, 90, 191, 224, 65, 117, 239, 19, 197, 228, 130, 23, 131, 233, 73, 212, 28, 111, 157, 207, 191, 211, 63, 148, 187, 135, 154, 102, 178, 0, 66, 209, 5, 44, 53, 155, 38, 18, 65, 228, 244, 102, 43, 100, 252, 237, 77, 219, 255, 206, 209, 172, 175, 164, 171, 231, 98, 56, 97, 254, 61, 232, 23, 141, 69, 113, 77, 163, 225, 82, 20, 46, 84, 125, 226, 117, 169, 254, 119, 42, 162, 29, 121, 243, 22, 191, 235, 208, 221, 251, 240, 95, 4, 181, 71, 77, 100, 252, 249, 6, 36, 227, 65, 207, 239, 125, 230, 202, 255, 201, 233, 108, 233, 6, 172, 241, 152, 69, 85, 88 }, null, 0, null, null, null }
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
