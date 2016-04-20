using System.Collections.Generic;

namespace ToDo.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TaskViewModel> YesterdayTasks { get; set; }
        public IEnumerable<TaskViewModel> TodayTasks { get; set; }
        public IEnumerable<TaskViewModel> TomorrowTasks { get; set; }
    }
}
