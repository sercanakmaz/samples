using AspNetBuilerplate.Sample1.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AspNetBuilerplate.Sample1.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Sample1DbContext _context;

        public InitialHostDbBuilder(Sample1DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
