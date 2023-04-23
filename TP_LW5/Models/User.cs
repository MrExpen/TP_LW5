using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP_LW5.Models;

public class User
{
    [DisplayName("Id")]
    [Key]
    public int Id { get; set; }

    [DisplayName("Имя")]
    public string FirstName { get; set; }

    [DisplayName("Фамилия")]
    public string LastName { get; set; }

    [DisplayName("Отчетсво")]
    public string? Patronymic { get; set; }

    [DisplayName("День рождения")]
    public DateTime Birthday { get; set; }

    [DisplayName("Email")]
    [EmailAddress] 
    public string Email { get; set; }
    
    [DisplayName("Номер телефона")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [DisplayName("Сумма в банке")]
    public decimal DepositAmount { get; set; }

    [DisplayName("Название банка")]
    public string BankName { get; set; }
}