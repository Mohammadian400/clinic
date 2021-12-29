using Data;

namespace Logic.Repositories
{
    public abstract class Repository
    {
        protected readonly ClinicContext DbContext;

        public Repository(ClinicContext context)
        {
            DbContext = context;
        }
    }
}
