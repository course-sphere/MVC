namespace DataAccessLayer.Repositories
{
    public class PaymentRepository : GenericRepository<DataAccessLayer.Entities.Payment>, DataAccessLayer.IRepositories.IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
