using System;
using System.Collections.Generic;

namespace SenaiNotesAlffas.Models;

public partial class Anotacao
{

    public int Idanotacoes { get; set; }

    public int Idusuario { get; set; }

    public int? Idtag { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Texto { get; set; }

    public bool? IsArchived { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Idstatus { get; set; } = null!;

    public virtual Tag? IdtagNavigation { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
