namespace WebApplication_01.AppCode.Contracts
{
    public interface ICalcService
    {
        int Sum(int numberOne, int numberTwo);

        int Min(int numberOne, int numberTwo);

        int Mul(int numberOne, int numberTwo);

        int Div(int numberOne, int numberTwo);

    }
}
