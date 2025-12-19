using System.ComponentModel.DataAnnotations;

namespace WebApp.Model;

public record StatisticsDto
{
    [Required] public DateTime FromDate { get; set; } = DateTime.Now;
    [Required] public DateTime ToDate { get; set; } = DateTime.Now;
}