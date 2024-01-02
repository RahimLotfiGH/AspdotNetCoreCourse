using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppCode.Contracts;
using WebApplication_01.AppCode.Services;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class CalcController : Controller
    {
        private CalcVm _calcVm;

        private readonly ICalcService _calcService;

        public CalcController(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public IActionResult Index()
        {

            var sum = _calcService.Sum(10, 20);


            return View(new CalcVm());
        }

        public IActionResult Run(CalcVm calcVm)
        {
            _calcVm = calcVm;

            DoCalc();

            return View("Index", _calcVm);
        }

        private void DoCalc()
        {

            _calcVm.Result = ResultCalc();

            _calcVm.NumberTwo = _calcVm.Result;

            _calcVm.NumberOne = 0;

        }

        private int ResultCalc()
        {
            int result = 0;

            switch (_calcVm.Operation)
            {
                case ECalcOperation.Sum:
                    result = _calcVm.NumberTwo + _calcVm.NumberOne; break;

                case ECalcOperation.Min:
                    result = _calcVm.NumberTwo - _calcVm.NumberOne; break;

                case ECalcOperation.Mul:
                    result = _calcVm.NumberTwo * _calcVm.NumberOne; break;

                case ECalcOperation.Div:
                    result = _calcVm.NumberTwo / _calcVm.NumberOne; break;
            }

            return result;
        }

    }
}