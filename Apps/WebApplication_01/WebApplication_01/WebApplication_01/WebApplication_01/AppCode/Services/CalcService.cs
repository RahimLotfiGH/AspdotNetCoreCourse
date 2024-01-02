using WebApplication_01.AppCode.Contracts;

namespace WebApplication_01.AppCode.Services
{
    public class CalcService : ICalcService
    {
        public int Sum(int numberOne, int numberTwo) => numberOne + numberTwo;

        public int Min(int numberOne, int numberTwo) => numberOne - numberTwo;

        public int Mul(int numberOne, int numberTwo) => numberOne * numberTwo;

        public int Div(int numberOne, int numberTwo) => numberOne / numberTwo;

    }
}
