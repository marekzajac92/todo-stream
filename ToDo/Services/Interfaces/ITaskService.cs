using ToDo.ViewModels;

namespace ToDo.Services.Interfaces
{
    public interface ITaskService
    {
        HomeViewModel GetTasks();
        void Create(CreateTaskViewModel task);
        void Remove(int? id);
        void Done(int? id);
    }
}
