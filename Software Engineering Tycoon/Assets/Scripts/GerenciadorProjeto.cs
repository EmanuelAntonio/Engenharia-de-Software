using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// TODO(andre:2018-06-12): Fazer com que os objetos dependam menos de referencias
// as classes de gerenciador e mais de dependencias dos proprios prefabs
public class GerenciadorProjeto : MonoBehaviour
{
    public ProjetoAtual projetoAtual;

    // public Prioridades prioridadesEscolhidas;
    // public PrioridadesAtual prioridadesAtual;

    // TODO(andre:2018-06-13): Essas variaveis definitivamente estao no lugar errado.
    // Mover para alguma classe separada responsavel por atualizar o perfil ou para
    // alguma classe responsavel por atualizar o tempo.
    public float duracaoDia;
    public float dispesasMensais;
    private float tempoDesdeUltimoDia = 0;
    private bool relogioParado = false;


    // MUITA GAMBIARRA
    public GameObject aceitarProjetoInterface;

    public PerfilSelecionado perfilSelecionado;
    public UnityEvent eventoSalvarJogo;
    public UnityEvent eventoGerarListaProjetos;
    public UnityEvent eventoCriarEmpresa;
    public UnityEvent eventoAtualizarEtapaTutorial;

    void Start()
    {
        if (perfilSelecionado.perfil.novoPerfil)
        {
            // TODO(andre:2018-06-13): Considerar implementar valor booleano para
            // a criacao da empresa
            eventoCriarEmpresa.Invoke();
        }

        // TODO(andre:2018-06-13): Pre inicializar todas as variaveis do animator
        // com os valores carregados no perfil
        eventoAtualizarEtapaTutorial.Invoke();

        projetoAtual.temProjeto = false;
        eventoGerarListaProjetos.Invoke();
    }

    void Update()
    {
        // Se o tempo nao tiver parado (em algum menu), incrementa o tempo
        if (!relogioParado)
        {
            tempoDesdeUltimoDia += Time.deltaTime;
        }
        // TODO(andre:2018-06-13): Considerar tamanhos de meses diferentes alem de ano bisexto
        while (tempoDesdeUltimoDia > duracaoDia)
        {
            perfilSelecionado.perfil.dia += 1;

            if (perfilSelecionado.perfil.dia > 30)
            {
                perfilSelecionado.perfil.dia -= 30;
                perfilSelecionado.perfil.mes += 1;

                // TODO(andre:2018-06-13): O projeto exibido não é atualizado até o usuario
                // fechar a janela, mas o projeto que é escolhido é alterado. Isso faz com que o
                // usuario selecione um projeto errado
                if (!aceitarProjetoInterface.activeSelf)
                {
                    eventoGerarListaProjetos.Invoke();
                }

                if (perfilSelecionado.perfil.mes > 12)
                {
                    perfilSelecionado.perfil.mes -= 12;
                    perfilSelecionado.perfil.ano += 1;
                }

                perfilSelecionado.perfil.verba -= dispesasMensais;
                eventoSalvarJogo.Invoke();
            }

            tempoDesdeUltimoDia -= duracaoDia;
        }
    }

    public void AvancarEtapa()
    {
        perfilSelecionado.perfil.etapa = 1;
        eventoSalvarJogo.Invoke();

        SceneManager.LoadScene(perfilSelecionado.perfil.etapa + 1);
    }

    public void ConcluirProjeto()
    {
        projetoAtual.projeto.CalcularAvaliacao(projetoAtual.prioridadesEscolhidas);
        perfilSelecionado.perfil.verba += projetoAtual.projeto.valorPagamento * projetoAtual.projeto.avaliacao;
        projetoAtual.temProjeto = false;

        eventoSalvarJogo.Invoke();
    }

    public void PararRelogio()
    {
        relogioParado = true;
    }

    public void IniciarRelogio()
    {
        relogioParado = false;
    }
}
