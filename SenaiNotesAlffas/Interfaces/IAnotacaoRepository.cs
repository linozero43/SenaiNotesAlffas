﻿using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.ViewModels;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IAnotacaoRepository
    {
        List<ListarAnotacaoViewModel> ListarTodos();
        ListarAnotacaoViewModel ListarPorId(int id);
        List<Anotacao> BuscarData(DateTime data);
        CadastrarAnotacaoDto? CadastrarAnotacao(CadastrarAnotacaoDto anotacao);
        Anotacao? Atualuzar(int id, CadastrarAnotacaoDto anotacao);
        public object? Deletar(int id);
        List<Anotacao> BuscarAnotacaoPorNome(string nome);
        Anotacao? ArquivarAnotacao(int id);



    }
}
