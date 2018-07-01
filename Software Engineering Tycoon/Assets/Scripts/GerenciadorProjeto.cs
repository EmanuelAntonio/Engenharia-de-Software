using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GerenciadorProjeto : MonoBehaviour
{
    public ProjetoAtual projetoAtual;
    public MetodologiaAtual metodologiaAtual;
    public ListaFuncionarios listaFuncionarios;

    // TODO(andre:2018-06-13): Essas variaveis definitivamente estao no lugar errado.
    // Mover para alguma classe separada responsavel por atualizar o perfil ou para
    // alguma classe responsavel por atualizar o tempo.
    public float duracaoDia;
    public float dispesasMensais;
    private float tempoDesdeUltimoDia = 0;
    private bool relogioParado = false;

    public bool avancarEtapaMetodologiaSemDuracao = false;

    // MUITA GAMBIARRA
    public GameObject aceitarProjetoInterface;

    public PerfilSelecionado perfilSelecionado;
    public UnityEvent eventoSalvarJogo;
    public UnityEvent eventoGerarListaProjetos;
    public UnityEvent eventoCriarEmpresa;
    public UnityEvent eventoAtualizarEtapaTutorial;
    public UnityEvent eventoAvancarEtapaMetodologia;
    public UnityEvent eventoAtualizarProgresso;
    public UnityEvent eventoConcluirProjeto;

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

    public void ComecarProjeto()
    {
        projetoAtual.progresso = 0;

        metodologiaAtual.metodologia.indiceEtapaAtual = 0;
        foreach (Funcionario funcionario in listaFuncionarios.funcionarios)
        {
            funcionario.ComecarProjeto();
        }

        eventoAtualizarProgresso.Invoke();
        eventoAvancarEtapaMetodologia.Invoke();
    }

    public void ComecarEtapaMetodologia()
    {
        StartCoroutine(AtualizarMetodologia());
    }

    public void AvancarEtapaMetodologia()
    {
        avancarEtapaMetodologiaSemDuracao = true;
    }

    IEnumerator AtualizarMetodologia()
    {
        float progressoEtapa = 0;
        Metodologia metodologia = metodologiaAtual.metodologia;
        EtapaMetodologia etapaAtual = metodologia.ObterEtapaAtual();

        if (etapaAtual.temDuracao)
        {
            while (progressoEtapa < etapaAtual.duracao)
            {
                progressoEtapa += Time.deltaTime;
                foreach (Funcionario funcionario in listaFuncionarios.funcionarios)
                {
                    funcionario.DesenvolverProjeto(projetoAtual, etapaAtual);
                }

                // GAMBIARRA: A ideia é que como a ultima etapa não tem tempo para concluir essa conta deveria funcionar de modo diferente
                // projetoAtual.progresso = (metodologia.indiceEtapaAtual + (progressoEtapa / etapaAtual.duracao)) / (float)metodologia.etapas.Count;
                projetoAtual.progresso = (metodologia.indiceEtapaAtual + (progressoEtapa / etapaAtual.duracao)) / ((float)metodologia.etapas.Count - 1);
                eventoAtualizarProgresso.Invoke();

                yield return null;
            }
        }
        else
        {
            avancarEtapaMetodologiaSemDuracao = false;
            while (!avancarEtapaMetodologiaSemDuracao)
            {
                foreach (Funcionario funcionario in listaFuncionarios.funcionarios)
                {
                    funcionario.DesenvolverProjeto(projetoAtual, etapaAtual);
                }

                // GAMBIARRA: A ideia é que por não ter tempo para concluir essa etapa deveria funcionar de modo diferente
                // projetoAtual.progresso = (float)(metodologia.indiceEtapaAtual + 1) / (float)metodologia.etapas.Count;
                projetoAtual.progresso = 1;
                eventoAtualizarProgresso.Invoke();

                yield return null;
            }
        }

        metodologia.indiceEtapaAtual += 1;

        if (metodologia.indiceEtapaAtual >= metodologia.etapas.Count)
        {
            metodologia.indiceEtapaAtual = 0;
            ConcluirProjeto();
        }
        else
        {
            eventoAvancarEtapaMetodologia.Invoke();

            // MUITA GAMBIARRA
            // A etapa de conclusão não tem uma interface para comecar ela
            if (metodologia.ObterTipoEtapa() == TipoEtapaMetodologia.Concluir)
            {
                ComecarEtapaMetodologia();
            }
        }
    }

    public void ConcluirProjeto()
    {
        // projetoAtual.projeto.CalcularAvaliacao(projetoAtual.prioridadesEscolhidas);
        projetoAtual.projeto.CalcularAvaliacao();
        perfilSelecionado.perfil.verba += projetoAtual.projeto.valorPagamento * projetoAtual.projeto.avaliacao;
        projetoAtual.temProjeto = false;

        eventoConcluirProjeto.Invoke();
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
