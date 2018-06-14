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

    // Usado nos testes unitarios
    public void Contruct(float coletaDados, float estudoDominio, float documentacao,
                         float legibilidade, float qualidadeSolucao, float desenvolvimentoInterface,
                         float testes, float avaliacaoCliente, float implantacao)
    {
        this.coletaDados = coletaDados;
        this.estudoDominio = estudoDominio;
        this.documentacao = documentacao;

        this.legibilidade = legibilidade;
        this.qualidadeSolucao = qualidadeSolucao;
        this.desenvolvimentoInterface = desenvolvimentoInterface;

        this.testes = testes;
        this.avaliacaoCliente = avaliacaoCliente;
        this.implantacao = implantacao;
    }

    public float SomaPrioridades()
    {
        return coletaDados + estudoDominio + documentacao + 
               legibilidade + qualidadeSolucao + desenvolvimentoInterface + 
               testes + avaliacaoCliente + implantacao;
    }

    public Prioridades Normalizada()
    {
        float somaEtapaPlanejamento = this.coletaDados + this.estudoDominio + this.documentacao;
        float somaEtapaDesenvolvimento = this.legibilidade + this.qualidadeSolucao + this.desenvolvimentoInterface;
        float somaEtapaAvaliacao = this.testes + this.avaliacaoCliente + this.implantacao;

        Prioridades prioridadesNormalizadas = new Prioridades();
        prioridadesNormalizadas.coletaDados   = this.coletaDados / somaEtapaPlanejamento;
        prioridadesNormalizadas.estudoDominio = this.estudoDominio / somaEtapaPlanejamento;
        prioridadesNormalizadas.documentacao  = this.documentacao / somaEtapaPlanejamento;

        prioridadesNormalizadas.legibilidade             = this.legibilidade / somaEtapaDesenvolvimento;
        prioridadesNormalizadas.qualidadeSolucao         = this.qualidadeSolucao / somaEtapaDesenvolvimento;
        prioridadesNormalizadas.desenvolvimentoInterface = this.desenvolvimentoInterface / somaEtapaDesenvolvimento;

        prioridadesNormalizadas.testes           = this.testes /  somaEtapaAvaliacao;
        prioridadesNormalizadas.avaliacaoCliente = this.avaliacaoCliente /  somaEtapaAvaliacao;
        prioridadesNormalizadas.implantacao      = this.implantacao /  somaEtapaAvaliacao;

        return prioridadesNormalizadas;
    }
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

    private int pontosErro = 0;
    private int pontosTecnologia = 0;
    private int pontosDesign = 0;

    public float avaliacao = 0;

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

    public float GetAvaliacao()
    {
        return this.avaliacao;
    }

    public void CalcularAvaliacao(Prioridades prioridadesEscolhidas)
    {
        // TODO(andre:2018-06-13): Precomputar as prioridades normalizadas do projeto
        Prioridades prioridadesNormalizadas = prioridades.Normalizada();
        Prioridades prioridadesEscolhidasNormalizadas = prioridadesEscolhidas.Normalizada();

        float coletaDados              = Mathf.Abs(prioridadesNormalizadas.coletaDados              - prioridadesEscolhidasNormalizadas.coletaDados);
        float estudoDominio            = Mathf.Abs(prioridadesNormalizadas.estudoDominio            - prioridadesEscolhidasNormalizadas.estudoDominio);
        float documentacao             = Mathf.Abs(prioridadesNormalizadas.documentacao             - prioridadesEscolhidasNormalizadas.documentacao);
        float legibilidade             = Mathf.Abs(prioridadesNormalizadas.legibilidade             - prioridadesEscolhidasNormalizadas.legibilidade);
        float qualidadeSolucao         = Mathf.Abs(prioridadesNormalizadas.qualidadeSolucao         - prioridadesEscolhidasNormalizadas.qualidadeSolucao);
        float desenvolvimentoInterface = Mathf.Abs(prioridadesNormalizadas.desenvolvimentoInterface - prioridadesEscolhidasNormalizadas.desenvolvimentoInterface);
        float testes                   = Mathf.Abs(prioridadesNormalizadas.testes                   - prioridadesEscolhidasNormalizadas.testes);
        float avaliacaoCliente         = Mathf.Abs(prioridadesNormalizadas.avaliacaoCliente         - prioridadesEscolhidasNormalizadas.avaliacaoCliente);
        float implantacao              = Mathf.Abs(prioridadesNormalizadas.implantacao              - prioridadesEscolhidasNormalizadas.implantacao);

        float diferencaMedia = (coletaDados + estudoDominio + documentacao +
                                legibilidade + qualidadeSolucao + desenvolvimentoInterface +
                                testes + avaliacaoCliente + implantacao) / 9;

        this.avaliacao = Mathf.Max(1 - diferencaMedia * 3, 0);
    }
}
