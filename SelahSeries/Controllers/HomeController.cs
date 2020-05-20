﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;
using SelahSeries.Services;
using SelahSeries.ViewModels;

namespace SelahSeries.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        
        public HomeController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment, IEmailService emailService)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _emailService = emailService;
    
            hostingEnvironment = environment;
        }
        
        [Route("Home/Index")]
        [HttpGet("{pageIndex}")]
        [Route("/")]
        public async Task<IActionResult> Index(int pageIndex, string category)
        {
           PostHomeViewModel postHomeVM = new PostHomeViewModel();
           int page = (pageIndex == 0)? 1 : pageIndex;
           var pageParam = new PaginationParam
            {
                PageIndex = page,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            var dontMiss =_postRepo.GetPublishedDMPosts();
            var dontMissVM = _mapper.Map<List<PostListViewModel>>(dontMiss);
            postHomeVM.DontMiss = dontMissVM;

            PaginatedList<Post> latestArticles;
            if (category == "all" || category == null )
            {
                latestArticles = await _postRepo.GetPublishedPosts(pageParam);          
            }
            else {
                latestArticles = await _postRepo.GetPublishedPostsByCategory(pageParam, category);
            }
            postHomeVM.TotalPostCount = latestArticles.TotalCount;
            var latestArticlesVM = _mapper.Map<List<PostListViewModel>>(latestArticles.Source);
            postHomeVM.LatestArticle = latestArticlesVM;

            ViewData["Category"] = category;
            return View(postHomeVM);
        }

        public List<PostListViewModel> Map(PaginatedList<Post> section)
        {
            return _mapper.Map<List<PostListViewModel>>(section);
            
        }

      

        public IActionResult About()
        {
           

            return View();
        }

        [Route("Home/About/Read_More")]
        public IActionResult Read_More()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
           
            return View();
        }

        [HttpPost]
        [Route("home/contact")]
        public async Task<ActionResult> Contact([FromForm] string name, string email, string subject, string message)
        {
           
            try
            {
                message = "Name: " + name + "\n" + "Email Address: " + email + "\n" + "Message: " + message;
                await _emailService.SendEmail(subject, message);
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
            catch(Exception) {
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
