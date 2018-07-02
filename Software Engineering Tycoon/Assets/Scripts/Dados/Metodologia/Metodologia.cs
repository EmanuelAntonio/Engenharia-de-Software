using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Metodologia
{
    public ProjetoAtual projetoAtual;

    public List<EtapaMetodologia> etapas;
    public int indiceEtapaAtual;

    public Metodologia(ProjetoAtual projetoAtual)
    {
        this.projetoAtual = projetoAtual;
        etapas = new List<EtapaMetodologia>();
    }

    public TipoEtapaMetodologia ObterTipoEtapa()
    {
        return etapas[indiceEtapaAtual].tipo;
    }

    public EtapaMetodologia ObterEtapaAtual()
    {
        return etapas[indiceEtapaAtual];
    }
}

public enum TipoEtapaMetodologia
{
    Concluir,
    Planejamento,
    Desenvolvimento,
    Validacao,
}

[System.Serializable]
public class EtapaMetodologia
{
    public TipoEtapaMetodologia tipo;
    public float frequenciaAtualizacao;
    public bool temDuracao;
    public float duracao;

    public EtapaMetodologia(TipoEtapaMetodologia tipo, float frequenciaAtualizacao, float duracao)
    {
        this.tipo = tipo;
        this.frequenciaAtualizacao = frequenciaAtualizacao;
        this.temDuracao = true;
        this.duracao = duracao;
    }

    public EtapaMetodologia(TipoEtapaMetodologia tipo, float frequenciaAtualizacao)
    {
        this.tipo = tipo;
        this.frequenciaAtualizacao = frequenciaAtualizacao;
        this.temDuracao = false;
        this.duracao = 0.0f;
    }

    public float ObterMultiplicadorDesign(Projeto projeto, Prioridades escolhido)
    {
        Prioridades prioridades = projeto.prioridadesDesign;

        float pontos = 0;
        switch (tipo)
        {
            case TipoEtapaMetodologia.Planejamento:
                pontos = prioridades.coletaDados              * escolhido.coletaDados +
                         prioridades.estudoDominio            * escolhido.estudoDominio +
                         prioridades.documentacao             * escolhido.documentacao;
                break;
            case TipoEtapaMetodologia.Desenvolvimento:
                pontos = prioridades.legibilidade             * escolhido.legibilidade +
                         prioridades.qualidadeSolucao         * escolhido.qualidadeSolucao +
                         prioridades.desenvolvimentoInterface * escolhido.desenvolvimentoInterface;
                break;
            case TipoEtapaMetodologia.Validacao:
                pontos = prioridades.testes                   * escolhido.testes +
                         prioridades.avaliacaoCliente         * escolhido.avaliacaoCliente +
                         prioridades.implantacao              * escolhido.implantacao;
                break;
            case TipoEtapaMetodologia.Concluir:
                pontos = 0.05f;
                break;
        }

        return pontos;
    }

    public float ObterMultiplicadorTecnologia(Projeto projeto, Prioridades escolhido)
    {
        Prioridades prioridades = projeto.prioridadesTecnologia;

        float pontos = 0;
        switch (tipo)
        {
            case TipoEtapaMetodologia.Planejamento:
                pontos = prioridades.coletaDados              * escolhido.coletaDados +
                         prioridades.estudoDominio            * escolhido.estudoDominio +
                         prioridades.documentacao             * escolhido.documentacao;
                break;
            case TipoEtapaMetodologia.Desenvolvimento:
                pontos = prioridades.legibilidade             * escolhido.legibilidade +
                         prioridades.qualidadeSolucao         * escolhido.qualidadeSolucao +
                         prioridades.desenvolvimentoInterface * escolhido.desenvolvimentoInterface;
                break;
            case TipoEtapaMetodologia.Validacao:
                pontos = prioridades.testes                   * escolhido.testes +
                         prioridades.avaliacaoCliente         * escolhido.avaliacaoCliente +
                         prioridades.implantacao              * escolhido.implantacao;
                break;
            case TipoEtapaMetodologia.Concluir:
                pontos = 0.05f;
                break;
        }

        return pontos;
    }
}
