using BusinessLayer;
using BusinessLayer.IServices;
using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLayer.Requests.GradedItem;
using BusinessLayer.Responses;
using DataAccessLayer;

namespace BusinessLayer.Services
{
    public class GradedItemService : IGradedItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimService _service;

        public GradedItemService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        public async Task<ApiResponse> SubmitQuizAsync(SubmitQuizRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var userId = _service.GetUserClaim().UserId;

                var gradedItem = await _unitOfWork.GradedItems
                    .GetAsync(g => g.GradedItemId == request.GradedItemId);

                if (gradedItem == null)
                    return response.SetNotFound("Quiz not found");

                if (!gradedItem.IsAutoGraded || gradedItem.GradedItemType != GradedItemType.Quiz)
                    return response.SetBadRequest("This quiz is not auto-graded");

                var attempt = new GradedAttempt
                {
                    GradedAttemptId = Guid.NewGuid(),
                    GradedItemId = gradedItem.GradedItemId,
                    UserId = userId,
                    SubmittedAt = DateTime.UtcNow,
                    QuestionSubmissions = new(),
                    Status = GradedAttemptStatus.Submitted
                };

                decimal totalScore = 0;

                foreach (var answer in request.Answers)
                {
                    var question = gradedItem.Questions
                        .First(q => q.QuestionId == answer.QuestionId);

                    if (question.Type == QuestionType.ShortAnswer)
                        continue;

                    var correctOptions = await _unitOfWork.AnswerOptions
                        .GetAllAsync(a => a.QuestionId == question.QuestionId && a.IsCorrect);

                    var isCorrect =
                        correctOptions.Select(o => o.AnswerOptionId).OrderBy(x => x)
                        .SequenceEqual(answer.SelectedAnswerOptionIds.OrderBy(x => x));

                    var questionScore = isCorrect ? question.Points : 0;

                    totalScore += questionScore;

                    attempt.QuestionSubmissions.Add(new QuestionSubmission
                    {
                        QuestionSubmissionId = Guid.NewGuid(),
                        QuestionId = question.QuestionId,
                        Score = questionScore,
                        SubmissionAnswerOptions = answer.SelectedAnswerOptionIds
                            .Select(id => new SubmissionAnswerOption
                            {
                                AnswerOptionId = id
                            }).ToList()
                    });
                }

                attempt.Score = totalScore;
                attempt.Status = GradedAttemptStatus.Submitted;
                await _unitOfWork.GradedAttempts.AddAsync(attempt);
                await _unitOfWork.SaveChangeAsync();

                return response.SetOk(new
                {
                    attempt.Score,
                    MaxScore = gradedItem.MaxScore,
                    attempt.Status
                });
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }

    }
}
