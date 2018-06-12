﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorProjeto : MonoBehaviour
{
    public List<DescricaoTipoEmpresa> descricaoTiposEmpresas;

    public bool temProjeto;
    public Projeto projetoAtual;

    public int pontosErro;
    public int pontosTecnologia;
    public int pontosDesign;

    public Prioridades escolhaPrioridades;

    [Range(0, 1)]
    public float dificuldadeAtual;
    public float quantidadeMaximaProjetos;
    public List<Projeto> projetosDisponiveis;

    private GerenciadorJogoUI gerenciadorJogoUI;

    void Start()
    {
        gerenciadorJogoUI = GetComponent<GerenciadorJogoUI>();

        temProjeto = false;

        // TODO(andre:2018-06-11): Quando o sistema de tempo estivar funcionando
        // executar essa logica a cada dois meses no jogo
        projetosDisponiveis.Clear();
        for (int i = 0; i < quantidadeMaximaProjetos; ++i)
        {
            projetosDisponiveis.Add(GerarProjeto(dificuldadeAtual));
        }
        gerenciadorJogoUI.AtualizarListaProjetos(projetosDisponiveis);
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
        prioridades.coletaDados        = tipoSelecionado.prioridadeColetaDadosBase;
        prioridades.estudoDominio      = tipoSelecionado.prioridadeEstudoDominioBase;
        prioridades.documentacao       = tipoSelecionado.prioridadeDocumentacaoBase;
        prioridades.legibilidade       = tipoSelecionado.prioridadeLegibilidadeBase;
        prioridades.qualidadeSolucao   = tipoSelecionado.prioridadeQualidadeSolucaoBase;
        prioridades.qualidadeInterface = tipoSelecionado.prioridadeQualidadeInterfaceBase;
        prioridades.testes             = tipoSelecionado.prioridadeTestesBase;
        prioridades.avaliacaoCliente   = tipoSelecionado.prioridadeAvaliacaoClienteBase;
        prioridades.implantacao        = tipoSelecionado.prioridadeImplantacaoBase;

        Projeto projeto = new Projeto(tipoEmpresa, nomeEmpresa, descricao, pagamento, multa, tamanho, experienciaUsuario, prioridades);

        return projeto;
    }

    public void AceitarProjetoSelecionado()
    {
        int projetoSelecionado = gerenciadorJogoUI.ObterProjetoSelecionado();

        if (projetoSelecionado >= 0)
        {
            temProjeto = true;
            projetoAtual = projetosDisponiveis[projetoSelecionado];

            gerenciadorJogoUI.RemoverProjeto(projetoSelecionado);
            projetosDisponiveis.RemoveAt(projetoSelecionado);

            gerenciadorJogoUI.ComecarProjeto(projetoAtual);
            gerenciadorJogoUI.Confirmar();
        }
    }
}