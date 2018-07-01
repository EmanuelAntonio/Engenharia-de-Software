using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Prioridades prioridadesDesign;
    public Prioridades prioridadesTecnologia;

    public DescricaoTipoEmpresa descricaoTipoEmpresa;

    public int pontosErro;
    public int pontosTecnologia;
    public int pontosDesign;

    // TODO(andre:2018-07-01): Esses valores deveriam ser exibidos na hora de aceitar o projeto
    public int pontosTecnologiaEsperado;
    public int pontosDesignEsperado;

    // TODO(andre:2018-07-01): Adicionar esses parametros na geracao de projetos?
    public float penalidadeErro = 0.01f;
    public float penalidadeTecnologia = 0.01f;
    public float penalidadeDesign = 0.01f;

    public float avaliacao;

    public Projeto(string tipoEmpresa, string nomeEmpresa, string descricao, float valorPagamento, float multaAtraso, int tamanhoEmpresa, float experienciaUsuario,
                   int pontosDesignEsperado, int pontosTecnologiaEsperado, Prioridades prioridadesDesign, Prioridades prioridadesTecnologia,
                   DescricaoTipoEmpresa descricaoTipoEmpresa = null)
    {
        this.tipoEmpresa = tipoEmpresa;
        this.nomeEmpresa = nomeEmpresa;
        this.descricao = descricao;

        this.valorPagamento = valorPagamento;
        this.multaAtraso = multaAtraso;
        this.tamanhoEmpresa = tamanhoEmpresa;
        this.experienciaUsuario = experienciaUsuario;

        this.pontosTecnologiaEsperado = pontosTecnologiaEsperado;
        this.pontosDesignEsperado = pontosDesignEsperado;

        this.prioridadesDesign = prioridadesDesign;
        this.prioridadesTecnologia = prioridadesTecnologia;

        this.descricaoTipoEmpresa = descricaoTipoEmpresa;
    }

    public void CalcularAvaliacao()
    {
        // TODO(andre:2018-07-01): Talvez dar algum bonus caso os pontos superem os valores esperados
        // TODO(andre:2018-07-01): Talvez utilizar alguma formula diferente para calcular as penalidades.
        // Alguma coisa que limite a quantidade de pontos perdidos para um único criterio como um logaritmo por exemplo
        float resultado = 1;

        if (pontosDesign < pontosDesignEsperado)
            resultado -= (pontosDesignEsperado - pontosDesign) * penalidadeDesign;

        if (pontosTecnologia < pontosTecnologiaEsperado)
            resultado -= (pontosTecnologiaEsperado - pontosTecnologia) * penalidadeTecnologia;

        resultado -= pontosErro * penalidadeErro;

        this.avaliacao = Mathf.Max(0, resultado);
    }
}

[System.Serializable]
public class Prioridades
{
    [Range(0.0f, 1.0f)]
    public float coletaDados;
    [Range(0.0f, 1.0f)]
    public float estudoDominio;
    [Range(0.0f, 1.0f)]
    public float documentacao;

    [Space(8)]

    [Range(0.0f, 1.0f)]
    public float legibilidade;
    [Range(0.0f, 1.0f)]
    public float qualidadeSolucao;
    [Range(0.0f, 1.0f)]
    public float desenvolvimentoInterface;

    [Space(8)]

    [Range(0.0f, 1.0f)]
    public float testes;
    [Range(0.0f, 1.0f)]
    public float avaliacaoCliente;
    [Range(0.0f, 1.0f)]
    public float implantacao;

    public Prioridades() {}

    public Prioridades(float coletaDados, float estudoDominio, float documentacao,
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

    public Prioridades(Prioridades prioridades)
    {
        this.coletaDados              = prioridades.coletaDados;
        this.estudoDominio            = prioridades.estudoDominio;
        this.documentacao             = prioridades.documentacao;

        this.legibilidade             = prioridades.legibilidade;
        this.qualidadeSolucao         = prioridades.qualidadeSolucao;
        this.desenvolvimentoInterface = prioridades.desenvolvimentoInterface;

        this.testes                   = prioridades.testes;
        this.avaliacaoCliente         = prioridades.avaliacaoCliente;
        this.implantacao              = prioridades.implantacao;
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
