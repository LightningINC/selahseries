﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.ViewModels;
using Microsoft.AspNetCore.Hosting;
using SelahSeries.Repository;

namespace SelahSeries.Controllers
{
    public class BlogMgtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        public BlogMgtController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
        }
        // GET: BlogMgt
        public async Task<ActionResult> Index()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            var posts = await _postRepo.GetPosts(pageParam); 
            return View(posts.Source);
        }

        // GET: BlogMgt/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var post = await _postRepo.GetPost(id);
            return View(post);
        }

        // GET: BlogMgt/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: BlogMgt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] PostCreateViewModel postVM)
        { 
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if(postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);

                try
                {
                    var post = _mapper.Map<Post>(postVM);
                    post.CreatedAt = DateTime.Now;
                    post.TitleImageUrl = string.IsNullOrWhiteSpace(uploadedImage) ? "defaultPostPhoto.jpg" : uploadedImage;

                    if (await _postRepo.AddPost(post)) return RedirectToAction(nameof(Index));

                    ViewBag.Error = "Unable to add post, please try again or contact administrator";
                    return View();
                }
                catch { return View(); }               
            }
           
            return View(postVM);
            
        }

        private async Task<string> ProcessPhoto(IFormFile postPhoto)
        {
            var uniqueFileName = GetUniqueFileName(postPhoto.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);

            await postPhoto.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }

        // GET: BlogMgt/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var blogPost = await _postRepo.GetPost(id);
            var blogPostVM = _mapper.Map<PostCreateViewModel>(blogPost);
            return View(blogPostVM);
        }

        // POST: BlogMgt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] PostCreateViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if (postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);
                try
                {
                    var editPost = _mapper.Map<Post>(postVM);
                    var post = await _postRepo.GetPost(postVM.PostId);
                    editPost.TitleImageUrl = string.IsNullOrWhiteSpace(uploadedImage) ? post.TitleImageUrl
                        : uploadedImage;
                    await _postRepo.UpdatePost(editPost);
                    return RedirectToAction(nameof(Index));
                }
                catch { return View(); }
            }
            return View();
        }

        // GET: BlogMgt/Delete/5
        public ActionResult Delete(int id)
        {
            _postRepo.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: BlogMgt/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}