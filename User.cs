namespace TimeReportHH
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>Почта</summary>
        public string Email { get; set; }

        /// <summary>Имя</summary>
        public string Firstname { get; set; }

        /// <summary>Фамилия</summary>
        public string Secondname { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Отчёты</summary>
        public List<Report> Reports { get; set; } = new List<Report>();
    }
}
