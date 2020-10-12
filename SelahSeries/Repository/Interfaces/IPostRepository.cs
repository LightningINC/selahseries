﻿
using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public interface IPostRepository
    {
        Task<bool> AddPost(Post post);
        Task<Post> GetPost(int postId);
        Task SaveChanges();
        Task DeletePost(int postId);
        Task<PaginatedList<Post>> GetPosts(PaginationParam pageParam);
        Task<PaginatedList<Post>> GetPostsByCategory(PaginationParam pageParam, int categoryId); 
        Task<PaginatedList<Post>> GetPublishedPosts(PaginationParam pageParam);
        Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, int categoryId);
        Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, string category);
        Task<List<Post>> GetPublishedDMPosts();
        Task<List<Post>> GetTopPosts();
        Task<List<Post>> GetPublishedPostsByClaps(int limit);
        Task<bool> UpdatePost(Post post);
        Task ClapPost();
        Task<List<Post>> SearchPost(string searchText);
        Task<List<EmailSubscription>> GetPostSuscribers();
        Task AddPostSuscribers(EmailSubscription emailSuscriber);
        Task UnSuscriberPost(string emailSuscriber);

    }
}
