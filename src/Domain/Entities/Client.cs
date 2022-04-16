using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Client
{
    public int Id { get; set; }
    [MaxLength(200)]
    public string LastName { get; set; }
    [MaxLength(200)]
    public string Firstname { get; set; }
    [MaxLength(350)]
    public string Email { get; set; }
    [MaxLength(200)]
    public string Password { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
