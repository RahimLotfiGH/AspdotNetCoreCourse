using System.ComponentModel;

namespace WebApplication_01.Models
{
    public enum ECalcOperation
    {
        [Description("جمع")]
        Sum,

        [Description("تفریق")]
        Min,

        [Description("ضرب")]
        Mul,

        [Description("تقسیم")]
        Div

    }
}
