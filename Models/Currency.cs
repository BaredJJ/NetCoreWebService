namespace WebService.Models
{
    public class Currency
    {
        public virtual int Id{get;set;}
        public virtual int NumCode { get; set; }
        public virtual string CharCode { get; set; }
        public virtual double Nominal { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
