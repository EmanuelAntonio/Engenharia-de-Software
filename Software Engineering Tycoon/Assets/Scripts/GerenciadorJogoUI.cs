using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorJogoUI : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ProjetoAtual projetoAtual;
    public MetodologiaAtual metodologiaAtual;

    public Animator animator;

    private int acaoConfirmar;
    private int acaoFechar;
    private int avancarEtapaMetodologia;
    private int concluirProjeto;
    private int alternarMenuContexto;
    private int exibirRelatorio;
    private int exibirPesquisa;
    private int exibirAceitarProjeto;
    // private int exibirCriarEmpresa;
    private int exibirContratarFuncionario;
    private int progressoProjeto;
    private int estagioProjeto;
    private int temProjeto;
    // private int etapaTutorial;

    void Start()
    {
        acaoConfirmar = Animator.StringToHash("AcaoConfirmar");
        acaoFechar = Animator.StringToHash("AcaoFechar");
        avancarEtapaMetodologia = Animator.StringToHash("AvancarEtapaMetodologia");
        concluirProjeto = Animator.StringToHash("ConcluirProjeto");
        alternarMenuContexto = Animator.StringToHash("AlternarMenuContexto");
        exibirRelatorio = Animator.StringToHash("ExibirRelatorio");
        exibirPesquisa = Animator.StringToHash("ExibirPesquisa");
        exibirAceitarProjeto = Animator.StringToHash("ExibirAceitarProjeto");
        // exibirCriarEmpresa = Animator.StringToHash("ExibirCriarEmpresa");
        exibirContratarFuncionario = Animator.StringToHash("ExibirContratarFuncionario");
        progressoProjeto = Animator.StringToHash("ProgressoProjeto");
        estagioProjeto = Animator.StringToHash("EstagioProjeto");
        temProjeto = Animator.StringToHash("TemProjeto");
        // etapaTutorial = Animator.StringToHash("EtapaTutorial");
    }

    public void Confirmar()
    {
        animator.SetTrigger(acaoConfirmar);
    }

    public void Fechar()
    {
        animator.SetTrigger(acaoFechar);
    }

    public void AlternarMenuContexto()
    {
        animator.SetTrigger(alternarMenuContexto);
    }

    public void ExibirRelatorio()
    {
        animator.SetTrigger(exibirRelatorio);
    }

    public void ExibirPesquisa()
    {
        animator.SetTrigger(exibirPesquisa);
    }

    public void ExibirAceitarProjeto()
    {
        animator.SetTrigger(exibirAceitarProjeto);
    }

    public void ExibirCriarEmpresa()
    {
        // animator.SetTrigger(exibirCriarEmpresa);
        animator.SetTrigger("ExibirCriarEmpresa");
    }

    public void ExibirContratarFuncionario()
    {
        animator.SetTrigger(exibirContratarFuncionario);
    }

    public void AtualizarProgresso()
    {
        animator.SetFloat(progressoProjeto, projetoAtual.progresso);
    }

    public void ComecarProjeto()
    {
        AtualizarProgresso();
        animator.SetBool(temProjeto, true);
    }

    public void AvancarEtapaMetodologia()
    {
        // NOTE(andre:2018-06-30): O Mecanim não consegue tratar Enums
        TipoEtapaMetodologia tipoEtapaMetodologia = metodologiaAtual.metodologia.ObterTipoEtapa();
        switch (tipoEtapaMetodologia)
        {
            case TipoEtapaMetodologia.Concluir:
                animator.SetInteger(estagioProjeto, 0);
                break;
            case TipoEtapaMetodologia.Planejamento:
                animator.SetInteger(estagioProjeto, 1);
                break;
            case TipoEtapaMetodologia.Desenvolvimento:
                animator.SetInteger(estagioProjeto, 2);
                break;
            case TipoEtapaMetodologia.Validacao:
                animator.SetInteger(estagioProjeto, 3);
                break;
        }

        animator.SetTrigger(avancarEtapaMetodologia);
    }

    public void ConcluirProjeto()
    {
        animator.SetInteger(estagioProjeto, 0);
        animator.SetBool(temProjeto, false);
        animator.SetTrigger(concluirProjeto);
    }

    public void AtualizarEtapaTutorial()
    {
        // animator.SetInteger(etapaTutorial, perfilSelecionado.perfil.etapaTutorial);
        animator.SetInteger("EtapaTutorial", perfilSelecionado.perfil.etapaTutorial);
    }
}
