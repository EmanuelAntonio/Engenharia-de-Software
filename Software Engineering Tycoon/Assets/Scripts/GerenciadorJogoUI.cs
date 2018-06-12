using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorJogoUI : MonoBehaviour
{
    public Animator animator;
    public Slider sliderProgresso;
    public Abas abasProjetos;
    public GameObject abaProjetoPrefab;
    public GameObject detalhesProjetoPrefab;
    public Button aceitarProjetoBotao;

    private int acaoConfirmar;
    private int acaoFechar;
    private int alternarMenuContexto;
    private int exibirRelatorio;
    private int exibirPesquisa;
    private int exibirAceitarProjeto;
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
        exibirAceitarProjeto = Animator.StringToHash("ExibirAceitarProjeto");
        exibirCriarEmpresa = Animator.StringToHash("ExibirCriarEmpresa");
        progressoProjeto = Animator.StringToHash("ProgressoProjeto");
        estagioProjeto = Animator.StringToHash("EstagioProjeto");
        temProjeto = Animator.StringToHash("TemProjeto");
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
        animator.SetTrigger(exibirCriarEmpresa);
    }

    public void DefinirProgresso(float progresso)
    {
        sliderProgresso.value = progresso;
        animator.SetFloat(progressoProjeto, progresso);
    }

    public void ComecarProjeto(Projeto projeto)
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

    public void AtualizarListaProjetos(List<Projeto> projetos)
    {
        abasProjetos.LimparAbas();

        foreach (Projeto projeto in projetos)
        {
            GameObject abaProjeto = Instantiate(abaProjetoPrefab);
            GameObject detalhesProjeto = Instantiate(detalhesProjetoPrefab);

            GameObject abaNome = abaProjeto.transform.Find("Nome").gameObject;
            abaNome.GetComponent<TextMeshProUGUI>().text = projeto.tipoEmpresa;

            Transform detalhesTransform = detalhesProjeto.transform;

            GameObject detalhesNomeEmpresa = detalhesTransform.Find("Nome").gameObject;
            detalhesNomeEmpresa.GetComponent<TextMeshProUGUI>().text = projeto.nomeEmpresa;

            GameObject detalhesTipoEmpresa = detalhesTransform.Find("Tipo").gameObject;
            detalhesTipoEmpresa.GetComponent<TextMeshProUGUI>().text = projeto.tipoEmpresa;

            GameObject detalhesDescricao = detalhesTransform.Find("Descricao").gameObject;
            detalhesDescricao.GetComponent<TextMeshProUGUI>().text = projeto.descricao;

            GameObject detalhesPagamento = detalhesTransform.Find("MultaPagamento/Pagamento").gameObject;
            detalhesPagamento.GetComponent<TextMeshProUGUI>().text = "Pagamento: R$ " + projeto.valorPagamento;

            GameObject detalhesMulta = detalhesTransform.Find("MultaPagamento/Multa").gameObject;
            detalhesMulta.GetComponent<TextMeshProUGUI>().text = "Multa: R$ " + projeto.multaAtraso + " / mês";

            abasProjetos.CriarAba(abaProjeto, detalhesProjeto);
        }

        aceitarProjetoBotao.interactable = (abasProjetos.abaAtiva != null);
    }

    public void RemoverProjeto(int id)
    {
        abasProjetos.RemoverAba(id);

        aceitarProjetoBotao.interactable = (abasProjetos.abaAtiva != null);
    }

    public int ObterProjetoSelecionado()
    {
        return abasProjetos.ObterAbaSelecionada();
    }
}
