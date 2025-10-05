namespace HistoryOfScienceAPI.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        //начало жизни если человек жил до н.э значение будет отрицательным
        public int StartTime { get; set; }

        public byte NumberYears { get; set; }

        public string? Description { get; set; }

        public List<string>? Tags { get; set; }
    } 
}
