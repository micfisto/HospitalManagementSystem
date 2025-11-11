namespace Hospital.BusinessLogic.Models;

public class Epicrisis
{
    //идентификатор эпикриза
    public Guid Id { get; set; }
    //дата заполнения
    public DateTime Date { get; set; }
    //краткое описание лечение
    public string Summary { get; set; }
    //дальнейшие рекомендации
    public string Recommendations { get; set; }
    //лечащий врач
    public string AttendingDoctor { get; set; }
}