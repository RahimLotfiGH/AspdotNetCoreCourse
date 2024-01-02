namespace WebApplication_01.AppCode
{
    public class MyGenericClass<TType1, TType2>
    {

        public TType1 Id1 { get; set; }

        public TType2 Id2 { get; set; }


        public TType1 ShowValue(TType2 type2)
        {

            var dataType2 = typeof(TType2);

            return Id1;
        }


    }
}
