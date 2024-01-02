using EFCoreTestApp.AppContexts;
using EFCoreTestApp.Models.Entities;

namespace EFCoreTestApp.Services
{
    public interface ITeacherService : IGenericRepository<Teacher>
    {
    }
}
