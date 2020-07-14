namespace CourseRating.Domain.Entities
{
    public class EmailAvaliacao
    {
        public string Id { get; set; }

        public string Texto { get; set; }

        public string LinkAvaliacao { get; set; }

        public Avaliacao Avaliacao { get; set; }
    }
}
