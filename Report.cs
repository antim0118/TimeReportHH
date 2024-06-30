namespace TimeReportHH
{
    public class Report
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        /// <summary>Примечание</summary>
        public string? Note { get; set; }

        /// <summary>Кол-во часов</summary>
        public int Hours { get; set; }

        /// <summary>Дата</summary>
        public DateOnly Date { get; set; }
    }
}
