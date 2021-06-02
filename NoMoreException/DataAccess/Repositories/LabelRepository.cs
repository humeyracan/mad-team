using DataAccess.DataModels;
using DataAccess.DBContext;
using DataAccess.Interfaces;
using System.Linq;

namespace DataAccess.Repositories
{
    public class LabelRepository : Repository<Label>, ILabelRepository
    {
        public Label Get(int id)
        {
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                var query = context.Labels.FirstOrDefault(x => x.Id == id);
                return new Label { Id = query.Id, Text = query.Text };
            }
        }
    }
}
