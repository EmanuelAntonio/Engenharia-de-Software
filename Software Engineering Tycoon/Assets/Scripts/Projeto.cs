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
    public float qualidadeInterface;

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
}
