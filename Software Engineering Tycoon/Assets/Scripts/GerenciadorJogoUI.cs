using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorJogoUI : MonoBehaviour
{
    public Animator animator;
    public Slider sliderProgresso;

    private int acaoConfirmar;
    private int acaoFechar;
    private int alternarMenuContexto;
    private int exibirRelatorio;
    private int exibirPesquisa;
    private int exibirNovoProjeto;
    private int exibirCriarEmpresa;
    private int progressoProjeto;
    private int estagioProjeto;
    private int temProjeto;

    void Start()
    {
        acaoConfirmar = Animator.StringToHash("AcaoConfirmar");
        acaoFechar = Animator.StringToHash("AcaoFechar");
        alternarMenuContexto = Animator.StringToHash("AlternarMenuContexto");
        exibirRelatorio = Animator.StringToHash("ExibirRelatorio");
        exibirPesquisa = Animator.StringToHash("ExibirPesquisa");
        exibirNovoProjeto = Animator.StringToHash("ExibirNovoProjeto");
        exibirCriarEmpresa = Animator.StringToHash("ExibirCriarEmpresa");
        progressoProjeto = Animator.StringToHash("ProgressoProjeto");
        estagioProjeto = Animator.StringToHash("EstagioProjeto");
        temProjeto = Animator.StringToHash("TemProjeto");
    }

    void Update()
    {

    }

    public void Confimar()
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

    public void ExibirNovoProjeto()
    {
        animator.SetTrigger(exibirNovoProjeto);
    }

    public void ExibirCriarEmpresa()
    {
        animator.SetTrigger(exibirCriarEmpresa);
    }

    public void DefinirProgresso(float progresso)
    {
        sliderProgresso.value = progresso;
        animator.SetFloat(progressoProjeto, progresso);
    }

    public void ComecarProjeto()
    {
        DefinirProgresso(0);
        animator.SetInteger(estagioProjeto, 0);
        animator.SetBool(temProjeto, true);
    }

    public void AvançarEstagio()
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
}
