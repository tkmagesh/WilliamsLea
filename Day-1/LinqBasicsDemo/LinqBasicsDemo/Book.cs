namespace LinqBasicsDemo
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Title, Cost, Units);
        }
    }
}