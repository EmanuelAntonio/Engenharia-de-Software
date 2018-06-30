﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorJogoUI : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ProjetoAtual projetoAtual;

    public Animator animator;

    private int acaoConfirmar;
    private int acaoFechar;
    private int alternarMenuContexto;
    private int exibirRelatorio;
    private int exibirPesquisa;
    private int exibirAceitarProjeto;
    // private int exibirCriarEmpresa;
    private int progressoProjeto;
    private int estagioProjeto;
    private int temProjeto;
    // private int etapaTutorial;

    void Start()
    {
        acaoConfirmar = Animator.StringToHash("AcaoConfirmar");
        acaoFechar = Animator.StringToHash("AcaoFechar");
        alternarMenuContexto = Animator.StringToHash("AlternarMenuContexto");
        exibirRelatorio = Animator.StringToHash("ExibirRelatorio");
        exibirPesquisa = Animator.StringToHash("ExibirPesquisa");
        exibirAceitarProjeto = Animator.StringToHash("ExibirAceitarProjeto");
        // exibirCriarEmpresa = Animator.StringToHash("ExibirCriarEmpresa");
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

    public void AtualizarProgresso()
    {
        animator.SetFloat(progressoProjeto, projetoAtual.progresso);
    }

    public void ComecarProjeto()
    {
        AtualizarProgresso();
        animator.SetInteger(estagioProjeto, 0);
        animator.SetBool(temProjeto, true);
    }

    public void AvancarEstagio()
    {
        int estagioAtual = animator.GetInteger(estagioProjeto);

        if (estagioAtual >= 3)
        {
            animator.SetBool(temProjeto, false);
        }
        else
        {
            animator.SetInteger(estagioProjeto, estagioAtual + 1);
        }
    }

    public void AtualizarEtapaTutorial()
    {
        // animator.SetInteger(etapaTutorial, perfilSelecionado.perfil.etapaTutorial);
        animator.SetInteger("EtapaTutorial", perfilSelecionado.perfil.etapaTutorial);
    }
}
