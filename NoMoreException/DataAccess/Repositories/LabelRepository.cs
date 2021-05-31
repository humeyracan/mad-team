using DataAccess.DataModels;
using DataAccess.DBContext;
using DataAccess.Dtos;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LabelRepository:ILabelRepository
    {
        public LabelData Get(int id)
        {
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                var query = context.Labels.FirstOrDefault(x => x.Id == id);
                return new LabelData { Id=query.Id, Text=query.Text};
            }
        }
    }
}
