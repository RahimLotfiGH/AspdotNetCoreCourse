namespace WebApplication_01.AppCode
{
    public class GenericRepo<TEntity, TModel>
                            where TEntity : BaseEntity
                            where TModel : class
    {

        public int Add(TEntity entity)
        {

            //todo

            return entity.Id;
        }

    }
}
