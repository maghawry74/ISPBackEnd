
namespace ISP.DAL.Repository.OfferRepository
{
    public class OfferRepository: GenericRepository<Offer>, IOfferRepository
    {
        private readonly ISPContext Context;
        public OfferRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }
    }
}
