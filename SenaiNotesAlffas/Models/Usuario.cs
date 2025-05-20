using System;
using System.Collections.Generic;

namespace SenaiNotesAlffas.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string Senha { get; set; } = null!;

    public DateTime? CriadorAt { get; set; }

    public virtual ICollection<Anotaco> Anotacos { get; set; } = new List<Anotaco>();
}
