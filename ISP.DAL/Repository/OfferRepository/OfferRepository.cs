
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repository.OfferRepository
{
    public class OfferRepository: GenericRepository<Offer>, IOfferRepository
    {
        private readonly ISPContext Context;
        public OfferRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }
        public new async Task<IEnumerable<Offer>> GetAll()
        {
            return await Context.Set<Offer>().Include(o => o.Provider)
                .ToListAsync();
        }
    }
}
