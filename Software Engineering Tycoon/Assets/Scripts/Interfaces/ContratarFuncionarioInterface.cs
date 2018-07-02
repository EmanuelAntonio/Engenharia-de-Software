using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ContratarFuncionarioInterface : MonoBehaviour
{
    public GameObject abaFuncionarioPrefab;
    public GameObject detalhesFuncionarioPrefab;

    private Abas abasProjetos;
    private Button aceitarFuncionarioBotao;

    public ProjetoAtual projetoAtual;
    public ListaProjetos projetosDisponiveis;

    private bool _started = false;
    void Start()
    {
        abasProjetos = transform.Find("AreaFuncionarios/ListaFuncionarios").GetComponent<Abas>();
        aceitarFuncionarioBotao = transform.Find("AceitarBotao").GetComponent<Button>();

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
        // TODO(andre>2018-06-25): Quando for criada a mensagem dizendo que a lista
        // foi atualizada, atualizar a lista de projeto apenas quando receber a mensagem.
        AtualizarListaProjetos();

        AtualizarBotaoAceitarProjeto();
    }

    public void AtualizarListaProjetos()
    {
        abasProjetos.LimparAbas();

        foreach (Projeto projeto in projetosDisponiveis.projetos)
        {
            GameObject abaProjeto = Instantiate(abaFuncionarioPrefab);
            GameObject detalhesProjeto = Instantiate(detalhesFuncionarioPrefab);

            GameObject abaNome = abaProjeto.transform.Find("Nome").gameObject;
            abaNome.GetComponent<TextMeshProUGUI>().text = projeto.tipoEmpresa;

            Transform detalhesTransform = detalhesProjeto.transform;

            GameObject detalhesNomeEmpresa = detalhesTransform.Find("Nome").gameObject;
            detalhesNomeEmpresa.GetComponent<TextMeshProUGUI>().text = projeto.nomeEmpresa;

            GameObject requisitosDesign = detalhesTransform.Find("Requisitos/Design/Texto").gameObject;
            requisitosDesign.GetComponent<TextMeshProUGUI>().text = projeto.pontosDesignEsperado.ToString();

            GameObject requisitosTecnologia = detalhesTransform.Find("Requisitos/Tecnologia/Texto").gameObject;
            requisitosTecnologia.GetComponent<TextMeshProUGUI>().text = projeto.pontosTecnologiaEsperado.ToString();

            GameObject detalhesPagamento = detalhesTransform.Find("MultaPagamento/Pagamento").gameObject;
            detalhesPagamento.GetComponent<TextMeshProUGUI>().text = "Salário: R$ " + projeto.valorPagamento;

            abasProjetos.CriarAba(abaProjeto, detalhesProjeto);
        }

        AtualizarBotaoAceitarProjeto();
    }

    public void AceitarProjetoSelecionado()
    {
        int projetoSelecionado = abasProjetos.ObterAbaSelecionada();

        if (projetoSelecionado >= 0)
        {
            projetoAtual.temProjeto = true;
            projetoAtual.projeto = projetosDisponiveis.projetos[projetoSelecionado];

            abasProjetos.RemoverAba(projetoSelecionado);
            projetosDisponiveis.projetos.RemoveAt(projetoSelecionado);

            AtualizarBotaoAceitarProjeto();
        }
    }

    public void AtualizarBotaoAceitarProjeto()
    {
        aceitarFuncionarioBotao.interactable = (abasProjetos.abaAtiva != null);
    }
}
