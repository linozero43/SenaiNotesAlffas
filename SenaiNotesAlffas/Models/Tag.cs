using System;
using System.Collections.Generic;

namespace SenaiNotesAlffas.Models;

public partial class Tag
{
    public int Idtag { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Anotacao> Anotacoes { get; set; } = new List<Anotacao>();

    public virtual Anotacao IdanotacoesNavigation { get; set; } = null!;
}
