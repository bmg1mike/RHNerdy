using Application;
using Application.Interfaces;
using AutoMapper;
using Data;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class DependencyContainer 
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddAutoMapper(typeof(NerdyMapper));
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IGenreService, GenreService>();
        }
    }
}
