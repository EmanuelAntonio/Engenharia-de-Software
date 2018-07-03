using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class VisualizarRelatoriosInterface : MonoBehaviour
{
    public GameObject abaProjetoPrefab;
    public GameObject detalhesRelatorioPrefab;

    private Abas abasProjetos;
    private Button aceitarProjetoBotao;

    public ListaProjetos projetosConcluidos;

    public Sprite imagemAvaliacao0;
    public Sprite imagemAvaliacao1;
    public Sprite imagemAvaliacao2;
    public Sprite imagemAvaliacao3;
    public Sprite imagemAvaliacao4;

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
        // TODO(andre>2018-06-25): Quando for criada a mensagem dizendo que a lista
        // foi atualizada, atualizar a lista de projeto apenas quando receber a mensagem.
        AtualizarListaProjetos();

        AtualizarBotaoAceitarProjeto();
    }

    public void AtualizarListaProjetos()
    {
        abasProjetos.LimparAbas();

        foreach (Projeto projeto in projetosConcluidos.projetos)
        {
            GameObject abaProjeto = Instantiate(abaProjetoPrefab);
            GameObject detalhesProjeto = Instantiate(detalhesRelatorioPrefab);

            GameObject abaNome = abaProjeto.transform.Find("Nome").gameObject;
            abaNome.GetComponent<TextMeshProUGUI>().text = projeto.tipoEmpresa;

            Transform detalhesTransform = detalhesProjeto.transform;

            GameObject detalhesNomeEmpresa = detalhesTransform.Find("Nome").gameObject;
            detalhesNomeEmpresa.GetComponent<TextMeshProUGUI>().text = projeto.nomeEmpresa;

            GameObject detalhesTipoEmpresa = detalhesTransform.Find("Tipo").gameObject;
            detalhesTipoEmpresa.GetComponent<TextMeshProUGUI>().text = projeto.tipoEmpresa;

            GameObject detalhesImagemAvaliacao = detalhesTransform.Find("Imagem").gameObject;
            if (projeto.avaliacao < 0.2)
                detalhesImagemAvaliacao.GetComponent<Image>().sprite = imagemAvaliacao0;
            else if (projeto.avaliacao < 0.4)
                detalhesImagemAvaliacao.GetComponent<Image>().sprite = imagemAvaliacao1;
            else if (projeto.avaliacao < 0.6)
                detalhesImagemAvaliacao.GetComponent<Image>().sprite = imagemAvaliacao2;
            else if (projeto.avaliacao < 0.8)
                detalhesImagemAvaliacao.GetComponent<Image>().sprite = imagemAvaliacao3;
            else
                detalhesImagemAvaliacao.GetComponent<Image>().sprite = imagemAvaliacao4;

            GameObject detalhesNotaProjeto = detalhesTransform.Find("Numero").gameObject;
            detalhesNotaProjeto.GetComponent<TextMeshProUGUI>().text = (projeto.avaliacao * 10).ToString("F1") + " / 10.0";

            GameObject requisitosDesignDes = detalhesTransform.Find("Requisitos/Design/Texto1").gameObject;
            requisitosDesignDes.GetComponent<TextMeshProUGUI>().text = projeto.pontosDesign.ToString();

            GameObject requisitosDesignEsp = detalhesTransform.Find("Requisitos/Design/Texto2").gameObject;
            requisitosDesignEsp.GetComponent<TextMeshProUGUI>().text = projeto.pontosDesignEsperado.ToString();

            GameObject requisitosTecnologiaDes = detalhesTransform.Find("Requisitos/Tecnologia/Texto-Desenvolvido").gameObject;
            requisitosTecnologiaDes.GetComponent<TextMeshProUGUI>().text = projeto.pontosTecnologia.ToString();

            GameObject requisitosTecnologiaEsp = detalhesTransform.Find("Requisitos/Tecnologia/Texto-Esperado").gameObject;
            requisitosTecnologiaEsp.GetComponent<TextMeshProUGUI>().text = projeto.pontosTecnologiaEsperado.ToString();

            GameObject detalhesPagamento = detalhesTransform.Find("Dica").gameObject;
            detalhesPagamento.GetComponent<TextMeshProUGUI>().text = "Uma dica sobre o desenvolvimento vem aqui";

            abasProjetos.CriarAba(abaProjeto, detalhesProjeto);
        }

        AtualizarBotaoAceitarProjeto();
    }

    public void AtualizarBotaoAceitarProjeto()
    {
        aceitarProjetoBotao.interactable = (abasProjetos.abaAtiva != null);
    }
}