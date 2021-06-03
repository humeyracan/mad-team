using BusinessLayer.Dtos;
using DataAccess.DataModels;
using Shared.BaseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public interface IPostObject: IBusinessObject
    {
        //public PostDto Get(int id);
        public List<PostDto> GetAll();
        public PostDto GetById(int postId);
        Task UpdatePost(PostDto votedto);
        void CreatePost(PostDto votedto);
        void Remove(PostDto votedto);
        void RemoveById(int id);

    }
}