using hm9.Models;

namespace hm10.DataBase
{

    public class CalculatedExpression
    {
        public int Id { get; set; }
        public decimal Val1 { get; set; }
        public decimal Val2 { get; set; }
        public Operation Op { get; set; }
        public decimal? Result { get; set; }
    }
}