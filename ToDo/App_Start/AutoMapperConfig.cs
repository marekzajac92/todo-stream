using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Task, TaskViewModel>();
            Mapper.CreateMap<CreateTaskViewModel, Task>()
                .ForMember(e => e.IsDone, conf => conf.MapFrom(vm => false));
            Mapper.CreateMap<IEnumerable<Task>, HomeViewModel>()
                .ForMember(vm => vm.YesterdayTasks,
                    conf => conf.MapFrom(e => e.Where(x => x.Date.Date == DateTime.Now.AddDays(-1).Date)))
                .ForMember(vm => vm.TodayTasks,
                    conf => conf.MapFrom(e => e.Where(x => x.Date.Date == DateTime.Now.Date.Date)))
                .ForMember(vm => vm.TomorrowTasks,
                    conf => conf.MapFrom(e => e.Where(x => x.Date.Date == DateTime.Now.AddDays(1).Date)));
        }
    }
}