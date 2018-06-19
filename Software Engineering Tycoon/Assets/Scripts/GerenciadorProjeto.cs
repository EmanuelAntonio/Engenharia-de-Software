using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO(andre:2018-06-12): Fazer com que os objetos dependam menos de referencias
// as classes de gerenciador e mais de dependencias dos proprios prefabs
public class GerenciadorProjeto : MonoBehaviour
{
    public List<DescricaoTipoEmpresa> descricaoTiposEmpresas;

    public bool temProjeto;
    public Projeto projetoAtual;

    public int pontosErro;
    public int pontosTecnologia;
    public int pontosDesign;

    public Prioridades prioridadesEscolhidas;

    [Range(0, 1)]
    public float dificuldadeAtual;
    public float quantidadeMaximaProjetos;
    public List<Projeto> projetosDisponiveis;

    private GerenciadorJogoUI gerenciadorJogoUI;
    private Perfil perfilCarregado;

    // TODO(andre:2018-06-13): Essas variaveis definitivamente estao no lugar errado.
    // Mover para alguma classe separada responsavel por atualizar o perfil ou para
    // alguma classe responsavel por atualizar o tempo.
    public float duracaoDia;
    public float dispesasMensais;
    private float tempoDesdeUltimoDia = 0;

    // MUITA GAMBIARRA
    public GameObject aceitarProjetoInterface;

    void Start()
    {
        gerenciadorJogoUI = GetComponent<GerenciadorJogoUI>();
        perfilCarregado = GetComponent<Perfil>();

        perfilCarregado.Carregar();
        if (perfilCarregado.novoPerfil)
        {
            // TODO(andre:2018-06-13): Considerar implementar valor booleano para
            // a criacao da empresa
            gerenciadorJogoUI.ExibirCriarEmpresa();
        }
        // TODO(andre:2018-06-13): Pre inicializar todas as variaveis do animator
        // com os valores carregados no perfil
        gerenciadorJogoUI.AvancarEtapaTutorial(perfilCarregado.etapaTutorial);

        temProjeto = false;

        // TODO(andre:2018-06-11): Quando o sistema de tempo estivar funcionando
        // executar essa logica a cada dois meses no jogo
        projetosDisponiveis.Clear();
        for (int i = 0; i < quantidadeMaximaProjetos; ++i)
        {
            projetosDisponiveis.Add(GerarProjeto(dificuldadeAtual));
        }
        // TODO(andre:2018-06-12): Talvez isso pudesse ser um mensagem para não
        // precisar de passar pelo gerenciadorJogoUI nem ter uma referencia direta
        // ao painel de aceitacao do projeto
        gerenciadorJogoUI.AtualizarListaProjetos();
    }

    void Update()
    {
        tempoDesdeUltimoDia += Time.deltaTime;
        // TODO(andre:2018-06-13): Considerar tamanhos de meses diferentes alem de ano bisexto
        while (tempoDesdeUltimoDia > duracaoDia)
        {
            perfilCarregado.dia += 1;

            if (perfilCarregado.dia > 30)
            {
                perfilCarregado.dia -= 30;
                perfilCarregado.mes += 1;

                // TODO(andre:2018-06-13): O projeto exibido não é atualizado até o usuario
                // fechar a janela, mas o projeto que é escolhido é alterado. Isso faz com que o
                // usuario selecione um projeto errado
                if (!aceitarProjetoInterface.activeSelf)
                {
                    projetosDisponiveis.Clear();
                    for (int i = 0; i < quantidadeMaximaProjetos; ++i)
                    {
                        projetosDisponiveis.Add(GerarProjeto(dificuldadeAtual));
                    }
                    gerenciadorJogoUI.AtualizarListaProjetos();
                }

                perfilCarregado.verba -= dispesasMensais;
                perfilCarregado.Salvar();

                if (perfilCarregado.mes > 12)
                {
                    perfilCarregado.mes -= 12;
                    perfilCarregado.ano += 1;
                }
            }

            tempoDesdeUltimoDia -= duracaoDia;
        }
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

    public void AvancarEtapa()
    {
        perfilCarregado.etapa = 1;
        GerenciadorSalve.instancia.SalvarPerfil(perfilCarregado);

        SceneManager.LoadScene(GerenciadorSalve.instancia.ObterEtapa() + 1);
    }

    public void ConcluirProjeto()
    {
        projetoAtual.CalcularAvaliacao(prioridadesEscolhidas);
        perfilCarregado.verba += projetoAtual.valorPagamento * projetoAtual.GetAvaliacao();
        temProjeto = false;

        perfilCarregado.Salvar();
    }
}
