using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GerenciadorProjeto : MonoBehaviour
{
    public ProjetoAtual projetoAtual;
    public MetodologiaAtual metodologiaAtual;
    public ListaFuncionarios listaFuncionariosContratados;
    public PerfilSelecionado perfilSelecionado;

    private bool avancarEtapaMetodologiaSemDuracao = false;

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

    public void ComecarProjeto()
    {
        projetoAtual.progresso = 0;

        metodologiaAtual.metodologia.indiceEtapaAtual = 0;
        foreach (Funcionario funcionario in listaFuncionariosContratados.funcionarios)
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
                foreach (Funcionario funcionario in listaFuncionariosContratados.funcionarios)
                {
                    funcionario.DesenvolverProjeto(projetoAtual, perfilSelecionado.perfil, etapaAtual);
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
                foreach (Funcionario funcionario in listaFuncionariosContratados.funcionarios)
                {
                    funcionario.DesenvolverProjeto(projetoAtual, perfilSelecionado.perfil, etapaAtual);
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
}
