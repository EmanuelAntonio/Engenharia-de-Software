using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Prioridades
{
    public float coletaDados;
    public float estudoDominio;
    public float documentacao;

    public float legibilidade;
    public float qualidadeSolucao;
    public float desenvolvimentoInterface;

    public float testes;
    public float avaliacaoCliente;
    public float implantacao;
}

[System.Serializable]
public class Projeto
{
    public string tipoEmpresa;
    public string nomeEmpresa;
    public string descricao;

    public float valorPagamento;
    public float multaAtraso;
    public int tamanhoEmpresa;
    public float experienciaUsuario;

    public Prioridades prioridades;

    private int pontosErro;
    private int pontosTecnologia;
    private int pontosDesign;

    public Projeto(string tipoEmpresa, string nomeEmpresa, string descricao, float valorPagamento, float multaAtraso, int tamanhoEmpresa, float experienciaUsuario, Prioridades prioridades)
    {
        this.tipoEmpresa = tipoEmpresa;
        this.nomeEmpresa = nomeEmpresa;
        this.descricao = descricao;

        this.valorPagamento = valorPagamento;
        this.multaAtraso = multaAtraso;
        this.tamanhoEmpresa = tamanhoEmpresa;
        this.experienciaUsuario = experienciaUsuario;

        this.prioridades = prioridades;
    }

    public int GetPontosErro()
    {
        return this.pontosErro;
    }

    public void SetPontosErro( int pontosErro)
    {
        this.pontosErro = pontosErro;
    }

    public int GetPontosTecnologia()
    {
        return this.pontosTecnologia;
    }

    public void SetPontosTecnologia(int pontosTecnologia)
    {
        this.pontosTecnologia = pontosTecnologia;
    }

    public int GetPontosDesign()
    {
        return this.pontosDesign;
    }

    public void SetPontosDesign(int pontosDesign)
    {
        this.pontosDesign = pontosDesign;
    }
}
