using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class PostObject : BaseBusinessObject, IPostObject
    {
        public List<PostDto> GetAll()
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetAll();

            return MappingFactory.MapList<Post, PostDto>(result);            
        }
        public PostDto GetById(int postid)
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetById(postid);

            return MappingFactory.Map<Post, PostDto>(result);
        }

        public PostDto GetPostById(int postid)
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetPostById(postid);

            return MappingFactory.Map<Post, PostDto>(result);
        }
        public List<PostDto> GetByParentId(int parentid)
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetByParentId(parentid);
            return MappingFactory.MapList<Post, PostDto>(result);
        }
 
        public async Task UpdatePost(PostDto postDto)
        {
            var repository = FindService<IPostRepository>();
            await repository.UpdateAsync(MappingFactory.Map<PostDto, Post>(postDto));
        }
        public void CreatePost(PostDto newPost)
        {
            var repository = FindService<IPostRepository>();
            repository.AddAsync(MappingFactory.Map<PostDto, Post>(newPost));
        }
        public void Remove(PostDto postDto)
        {
            var repository = FindService<IPostRepository>();
            repository.Remove(MappingFactory.Map<PostDto, Post>(postDto));
        }
        public void RemoveById(int id)
        {
            var repository = FindService<IPostRepository>();
            repository.RemoveById(id);
        }

        public List<PostDto> GetAllActiveQuestions()
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetAllActiveQuestions();
            return MappingFactory.MapList<Post, PostDto>(result);
        }
    }
}
