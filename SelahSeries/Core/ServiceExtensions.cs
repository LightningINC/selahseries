﻿using Microsoft.Extensions.DependencyInjection;
using SelahSeries.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Core
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IHardBookRepository, HardBookRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ISoftBookRepository, SoftBookRepository>();

            return services;
        }
    }
}
