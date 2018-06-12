using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AceitarProjetoInterface : MonoBehaviour
{
    public GerenciadorProjeto gerenciadorProjeto;
    public GerenciadorJogoUI gerenciadorJogoUI;

    public GameObject abaProjetoPrefab;
    public GameObject detalhesProjetoPrefab;

    public bool atualizarListaProjetos;

    private Abas abasProjetos;
    private Button aceitarProjetoBotao;

    private bool _started = false;
    void Start()
    {
        abasProjetos = transform.Find("AreaProjetos/ListaProjetos").GetComponent<Abas>();
        aceitarProjetoBotao = transform.Find("AceitarBotao").GetComponent<Button>();

        _started = true;
        this.OnStartOrEnable();
    }

    void OnEnable()
    {
        if (_started) this.OnStartOrEnable();
    }

    // O primeiro OnEnable() pode ser chamado antes do Start()
    // https://forum.unity.com/threads/awake-start-and-onenable-walked-into-a-bar.276712/
    void OnStartOrEnable()
    {
        if (atualizarListaProjetos)
        {
            AtualizarListaProjetos();
            atualizarListaProjetos = false;
        }

        AtualizarBotaoAceitarProjeto();
    }

    public void AtualizarListaProjetos()
    {
        abasProjetos.LimparAbas();

        foreach (Projeto projeto in gerenciadorProjeto.projetosDisponiveis)
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

        AtualizarBotaoAceitarProjeto();
    }

    public void AceitarProjetoSelecionado()
    {
        int projetoSelecionado = abasProjetos.ObterAbaSelecionada();

        if (projetoSelecionado >= 0)
        {
            gerenciadorProjeto.temProjeto = true;
            gerenciadorProjeto.projetoAtual = gerenciadorProjeto.projetosDisponiveis[projetoSelecionado];

            abasProjetos.RemoverAba(projetoSelecionado);
            gerenciadorProjeto.projetosDisponiveis.RemoveAt(projetoSelecionado);

            gerenciadorJogoUI.ComecarProjeto(gerenciadorProjeto.projetoAtual);
            gerenciadorJogoUI.Confirmar();

            AtualizarBotaoAceitarProjeto();
        }
    }

    public void AtualizarBotaoAceitarProjeto()
    {
        aceitarProjetoBotao.interactable = (abasProjetos.abaAtiva != null);
    }
}
