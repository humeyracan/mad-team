using BaseTypes.Shared;
using BusinessLayer.Dtos;
using DataAccess.DataModels;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class PostObject : BaseBusinessObject, IPostObject
    {
        public List<PostDto> GetAll()
        {
            List<PostDto> posts = new List<PostDto>();
            var repository = FindService<IPostRepository>();
            var result = repository.GetAll();

            foreach (var vote in result)
            {
                posts.Add(new PostDto
                {
                    Id = vote.Id,
                    Title = vote.Title,
                    Active = Convert.ToInt32(vote.Active),
                    PostType = (int)vote.PostType,
                    ParentId = (int)vote.ParentId,
                    AcceptedAnswerId = (int)vote.AcceptedAnswerId,
                    CreationDate = vote.CreationDate,
                    Score = (int)vote.Score,
                    ViewCount = (int)vote.ViewCount,
                    Body = vote.Body,
                    LastEditingDate = (DateTime)vote.LastEditingDate,
                    AnswerCount = (int)vote.AnswerCount,
                    CommentCount = (int)vote.CommentCount,
                    ClosedDate = (DateTime)vote.ClosedDate
                    //User ile ilgili kısım eklenecek.
                });
            }
            return posts;
        }
        public PostDto GetById(int postid)
        {
            var repository = FindService<IPostRepository>();
            var result = repository.GetById(postid);

            return new PostDto
            {
                Id = result.Id,
                Title = result.Title,
                Active = Convert.ToInt32(result.Active),
                PostType = (int)result.PostType,
                ParentId = (int)result.ParentId,
                AcceptedAnswerId = (int)result.AcceptedAnswerId,
                CreationDate = result.CreationDate,
                Score = (int)result.Score,
                ViewCount = (int)result.ViewCount,
                Body = result.Body,
                LastEditingDate = (DateTime)result.LastEditingDate,
                AnswerCount = (int)result.AnswerCount,
                CommentCount = (int)result.CommentCount,
                ClosedDate = (DateTime)result.ClosedDate
                //User ile ilgili kısım eklenecek.
            };

        }
        public async Task UpdatePost(PostDto postDto)
        {
            Post post = new Post { };
            var repository = FindService<IPostRepository>();
            await repository.UpdateAsync(post);
        }
        public void CreatePost(PostDto newPost)
        {
            Post post = new Post { };
            var repository = FindService<IPostRepository>();
            repository.AddAsync(post);
        }
        public void Remove(PostDto postDto)
        {
            Post post = new Post { };
            var repository = FindService<IPostRepository>();
            repository.Remove(post);
        }
        public void RemoveById(int id)
        {
            var repository = FindService<IPostRepository>();
            repository.RemoveById(id);
        }

    }

}
