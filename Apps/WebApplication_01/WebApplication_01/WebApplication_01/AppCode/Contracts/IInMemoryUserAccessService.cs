namespace WebApplication_01.AppCode.Contracts
{
    public interface IInMemoryUserAccessService
    {
        void Add(long userId, int[] userAccess);

        void Delete(long userId);

        bool IsExists(long userId);

        int[] Get(long userId);

    }
}
