using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPMini.API;
using ZPMini.API.Controllers;
using ZPMini.Factory.Factory;
using ZPMini.Factory.Interface;
using ZPMini.Logic;

namespace ZPMini.Test
{
    public static class ControllerTestAssembly
    {
        public static Mapper GetAutoMapper()
        {
            var cfg = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AutomapperConfiguration())
            );
            return new Mapper(cfg);
        }
    }
}
