using DataAccess.DataModels;

namespace DataAccess.Interfaces
{
    public interface ILabelRepository : IRepository<Label>
    {
        public Label Get(int id);
    }
}
