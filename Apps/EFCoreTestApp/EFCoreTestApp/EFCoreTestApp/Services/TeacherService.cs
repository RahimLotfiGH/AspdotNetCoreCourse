using EFCoreTestApp.AppContexts;
using EFCoreTestApp.Models.Entities;

namespace EFCoreTestApp.Services
{
    public sealed class TeacherService : GenericRepository<Teacher>, ITeacherService
    {

        public TeacherService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }






    }
}
