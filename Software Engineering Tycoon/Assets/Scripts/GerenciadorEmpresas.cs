using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorEmpresas : MonoBehaviour
{
    private GeradorNomes geradorNomes = null;
    public List<DescricaoTipoEmpresa> descricaoTiposEmpresas;

    public float quantidadeMaximaProjetos;
    public ListaProjetos projetosDisponiveis;

    // TODO:(andre:2018-06-25): Remover dificuldade dessa classe e mover para o perfil
    [Range(0, 1)]
    public float dificuldadeAtual;


    public int quantidadeMaximaFuncionarios;
    public ListaFuncionarios funcionariosDisponiveis;
    public float salarioBase;
    public int pontosHabilidadesBase;

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
            if (dificuldade >= descricaoTipoEmpresa.dificuldadeMinima && dificuldade <= descricaoTipoEmpresa.dificuldadeMaxima)
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

        int pontosDesignEsperado = Random.Range(tipoSelecionado.pontosDesignEsperadoMinimo, tipoSelecionado.pontosDesignEsperadoMaximo);
        int pontosTecnologiaEsperado = Random.Range(tipoSelecionado.pontosTecnologiaEsperadoMinimo, tipoSelecionado.pontosTecnologiaEsperadoMaximo);

        // Prioridades prioridadesDesign = new Prioridades();
        // TODO(andre:2018-06-10): Gerar variacoes nos valores bases com base nos demais parametros
        // prioridadesDesign.coletaDados              = tipoSelecionado.prioridadeColetaDadosBase;
        // prioridadesDesign.estudoDominio            = tipoSelecionado.prioridadeEstudoDominioBase;
        // prioridadesDesign.documentacao             = tipoSelecionado.prioridadeDocumentacaoBase;
        // prioridadesDesign.legibilidade             = tipoSelecionado.prioridadeLegibilidadeBase;
        // prioridadesDesign.qualidadeSolucao         = tipoSelecionado.prioridadeQualidadeSolucaoBase;
        // prioridadesDesign.desenvolvimentoInterface = tipoSelecionado.prioridadeDesenvolvimentoInterfaceBase;
        // prioridadesDesign.testes                   = tipoSelecionado.prioridadeTestesBase;
        // prioridadesDesign.avaliacaoCliente         = tipoSelecionado.prioridadeAvaliacaoClienteBase;
        // prioridadesDesign.implantacao              = tipoSelecionado.prioridadeImplantacaoBase;

        Prioridades prioridadesDesign = new Prioridades(tipoSelecionado.prioridadesDesignBase);
        Prioridades prioridadesTecnologia = new Prioridades(tipoSelecionado.prioridadesTecnologiaBase);

        Projeto projeto = new Projeto(tipoEmpresa, nomeEmpresa, descricao, pagamento, multa, tamanho, experienciaUsuario,
                                      pontosDesignEsperado, pontosTecnologiaEsperado, prioridadesDesign, prioridadesTecnologia,
                                      tipoSelecionado);

        return projeto;
    }

    public void AtualizarListaFuncionarios()
    {
        if (geradorNomes == null)
            geradorNomes = new GeradorNomes();

        funcionariosDisponiveis.funcionarios.Clear();
        for (int i = 0; i < quantidadeMaximaFuncionarios; ++i)
        {
            funcionariosDisponiveis.funcionarios.Add(GerarFuncionario(pontosHabilidadesBase + Random.Range(0, (int)(0.3f* pontosHabilidadesBase))));
        }
    }

    public Funcionario GerarFuncionario(int totalPontos)
    {
        float minimoArea = 0.2f;
        float porcentagemDesign = Random.Range(minimoArea, 1.0f - 2.0f*minimoArea);
        float porcentagemTecnologia = Random.Range(minimoArea, 1.0f - porcentagemDesign - minimoArea);

        int pontoTecnologia = (int)(porcentagemTecnologia * totalPontos);
        int pontoDesign     = (int)(porcentagemDesign     * totalPontos);
        int pontoPesquisa   = totalPontos - pontoDesign - pontoTecnologia;
        float salario = salarioBase * totalPontos;

        Funcionario funcionario = new Funcionario(pontoTecnologia, pontoDesign, pontoPesquisa, salario);

        string nomeAleatorio = geradorNomes.GerarNome();
        funcionario.SetNome(nomeAleatorio);

        return funcionario;
    }
}
