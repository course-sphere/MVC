namespace DataAccessLayer.Repositories
{
    public class QuestionRepository : GenericRepository<DataAccessLayer.Entities.Question>, DataAccessLayer.IRepositories.IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
