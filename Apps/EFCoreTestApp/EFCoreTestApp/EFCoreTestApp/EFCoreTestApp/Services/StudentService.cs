using EFCoreTestApp.AppContexts;
using EFCoreTestApp.Models.Entities;

namespace EFCoreTestApp.Services
{
    public sealed class StudentService : GenericRepository<Student>, IStudentService
    {
        
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }






    }
}
