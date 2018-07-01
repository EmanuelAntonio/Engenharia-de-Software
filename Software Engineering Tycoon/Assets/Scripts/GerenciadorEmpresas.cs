﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorEmpresas : MonoBehaviour
{
    public List<DescricaoTipoEmpresa> descricaoTiposEmpresas;

    public float quantidadeMaximaProjetos;
    public ListaProjetos projetosDisponiveis;

    // TODO:(andre:2018-06-25): Remover dificuldade dessa classe e mover para o perfil
    [Range(0, 1)]
    public float dificuldadeAtual;

    public void AtualizarListaProjetos()
    {
        projetosDisponiveis.projetos.Clear();
        for (int i = 0; i < quantidadeMaximaProjetos; ++i)
        {
            projetosDisponiveis.projetos.Add(GerarProjeto(dificuldadeAtual));
        }
        // TODO(andre:2018-06-25): Talvez devesse enviar uma mensagem avisando que
        // alterações foram feitas na lista de projetos para que o painel de aceitaçao
        // de projeto possa atualiszar sua lista.
    }

    public Projeto GerarProjeto(float dificuldade)
    {
        // TODO(andre:2018-06-10): Uma possibilidade seria implementar uma
        // reputação do jogador com os diferentes tipos de empresa e usar isso
        // para decidir quais projetos seriam sugeridos
        // https://stackoverflow.com/questions/9956486/distributed-probability-random-number-generator
        List<DescricaoTipoEmpresa> possiveisEmpresas = new List<DescricaoTipoEmpresa>();

        foreach (DescricaoTipoEmpresa descricaoTipoEmpresa in descricaoTiposEmpresas)
        {
            if (dificuldade > descricaoTipoEmpresa.dificuldadeMinima && dificuldade < descricaoTipoEmpresa.dificuldadeMaxima)
            {
                possiveisEmpresas.Add(descricaoTipoEmpresa);
            }
        }

        DescricaoTipoEmpresa tipoSelecionado = possiveisEmpresas[Random.Range(0, possiveisEmpresas.Count)];

        string tipoEmpresa = tipoSelecionado.tipoEmpresa;
        // TODO(andre:2018-06-10): Permitir gerar nomes e descricoes aleatorias
        string nomeEmpresa = tipoSelecionado.nomeEmpresa;
        string descricao = tipoSelecionado.descricaoProjeto;

        float pagamento = (float)System.Math.Round(Random.Range(tipoSelecionado.pagamentoMinimo, tipoSelecionado.pagamentoMaximo), 2);
        float multa = (float)System.Math.Round(Random.Range(tipoSelecionado.multaMinima, tipoSelecionado.multaMaxima), 2);
        int tamanho = Random.Range(tipoSelecionado.tamanhoMinimo, tipoSelecionado.tamanhoMaximo);
        float experienciaUsuario = Random.Range(tipoSelecionado.experienciaUsuarioMinima, tipoSelecionado.experienciaUsuarioMaxima);

        Prioridades prioridades = new Prioridades();
        // TODO(andre:2018-06-10): Gerar variacoes nos valores bases com base nos demais parametros
        prioridades.coletaDados              = tipoSelecionado.prioridadeColetaDadosBase;
        prioridades.estudoDominio            = tipoSelecionado.prioridadeEstudoDominioBase;
        prioridades.documentacao             = tipoSelecionado.prioridadeDocumentacaoBase;
        prioridades.legibilidade             = tipoSelecionado.prioridadeLegibilidadeBase;
        prioridades.qualidadeSolucao         = tipoSelecionado.prioridadeQualidadeSolucaoBase;
        prioridades.desenvolvimentoInterface = tipoSelecionado.prioridadeDesenvolvimentoInterfaceBase;
        prioridades.testes                   = tipoSelecionado.prioridadeTestesBase;
        prioridades.avaliacaoCliente         = tipoSelecionado.prioridadeAvaliacaoClienteBase;
        prioridades.implantacao              = tipoSelecionado.prioridadeImplantacaoBase;

        Projeto projeto = new Projeto(tipoEmpresa, nomeEmpresa, descricao, pagamento, multa, tamanho, experienciaUsuario, prioridades, tipoSelecionado);

        return projeto;
    }
}