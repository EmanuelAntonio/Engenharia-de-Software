using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Funcionario
{
    public float pontosDesignAcumulados;
    public float pontosTecnologiaAcumulados;
    public float pontosErroAcumulados;
    public float pontosPesquisaAcumulados;
    public float progresso;
    public float ultimaAtualizacao;


    [SerializeField]
    private int habilidadeTecnologia;
    [SerializeField]
    private int habilidadeDesign;
    [SerializeField]
    private int habilidadePesquisa;

    [SerializeField]
    private string nome;

    [SerializeField]
    private float salario;

    public Funcionario(int habilidadeTecnologia, int habilidadeDesign, int habilidadePesquisa, float salario)
    {
        this.habilidadeTecnologia = habilidadeTecnologia;
        this.habilidadeDesign = habilidadeDesign;
        this.habilidadePesquisa = habilidadePesquisa;
        this.salario = salario;
    }

    public void ComecarProjeto()
    {
        pontosDesignAcumulados = 0;
        pontosTecnologiaAcumulados = 0;
        pontosErroAcumulados = 0;
        pontosPesquisaAcumulados = 0;
        progresso = 0;
        ultimaAtualizacao = 0;
    }

    public void DesenvolverProjeto(ProjetoAtual projetoAtual, DadosPerfil perfil, EtapaMetodologia etapaMetodologia)
    {
        Projeto projeto = projetoAtual.projeto;
        Prioridades prioridadesEscolhidasNormalizadas = projetoAtual.prioridadesEscolhidas.Normalizada();

        // TODO(andre:2018-06-30): Usar data interna do jogo pra calcular o progresso
        float tempoPassado = Time.deltaTime;
        progresso += tempoPassado;

        float pontosDesign = etapaMetodologia.ObterMultiplicadorDesign(projeto, prioridadesEscolhidasNormalizadas);
        float pontosTecnologia = etapaMetodologia.ObterMultiplicadorTecnologia(projeto, prioridadesEscolhidasNormalizadas);
        // TODO(andre:2018-07-01): Definir como são gerados os pontos de erro
        float pontosErro = 0;
        // TODO(andre:2018-07-01): Definir como são gerados os pontos de pesquisa
        float pontosPesquisa = 0.15f;

        pontosDesign *= tempoPassado * habilidadeDesign;
        pontosTecnologia *= tempoPassado * habilidadeTecnologia;
        pontosErro *= tempoPassado * 10;
        pontosPesquisa *= tempoPassado * habilidadePesquisa;

        // TODO(andre:2018-06-30): Utilizar aleatoriedade
        pontosDesignAcumulados += pontosDesign;
        pontosTecnologiaAcumulados += pontosTecnologia;
        pontosErroAcumulados += pontosErro;
        pontosPesquisaAcumulados += pontosPesquisa;

        if (ultimaAtualizacao + etapaMetodologia.frequenciaAtualizacao < progresso)
        {
            ultimaAtualizacao = progresso;

            float pontosDesignGerados = Random.Range(pontosDesignAcumulados * 0.5f, pontosDesignAcumulados);
            float pontosTecnologiaGerados = Random.Range(pontosTecnologiaAcumulados * 0.5f, pontosTecnologiaAcumulados);
            float pontosErroGerados = Random.Range(pontosErroAcumulados * 0.5f, pontosErroAcumulados);
            float pontosPesquisaGerados = Random.Range(pontosPesquisaAcumulados * 0.1f, pontosPesquisaAcumulados);

            Debug.Log("Pontos gerados: " + pontosDesignGerados + " | " + pontosTecnologiaGerados + " | " + pontosErroGerados + " | " + pontosPesquisaGerados);

            projeto.pontosDesign += (int)pontosDesignGerados;
            projeto.pontosTecnologia += (int)pontosTecnologiaGerados;
            projeto.pontosErro += (int)pontosErroGerados;
            perfil.pontosPesquisa += (int)pontosPesquisaGerados;

            pontosDesignAcumulados = 0;
            pontosTecnologiaAcumulados = 0;
            pontosErroAcumulados = 0;
            pontosPesquisaAcumulados = 0;
        }
    }

    public int GetHabilidadeTecnologia()
    {
        return this.habilidadeTecnologia;
    }

    public void SetHabilidadeTecnologia( int habilidadeTecnologia)
    {
        this.habilidadeTecnologia = habilidadeTecnologia;
    }

    public int GetHabilidadeDesign()
    {
        return this.habilidadeDesign;
    }

    public void SetHabilidadeDesign( int habilidadeDesign)
    {
        this.habilidadeDesign = habilidadeDesign;
    }

    public int GetHabilidadePesquisa()
    {
        return this.habilidadePesquisa;
    }

    public void SetHabilidadePesquisa( int habilidadePesquisa)
    {
        this.habilidadePesquisa = habilidadePesquisa;
    }

    public float GetSalario()
    {
        return this.salario;
    }

    public void SetSalario(float salario)
    {
        this.salario = salario;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        return this.nome;
    }
}
