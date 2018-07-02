using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PesquisasInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ListaPesquisas listaPesquisas;

    public GameObject categoriaPrefab;
    public GameObject pesquisaPrefab;

    private Transform painelPesquisas;

    private bool _started = false;
    void Start()
    {
        painelPesquisas = transform.Find("ListaPesquisas/Viewport/Content");

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
        AtualizarListaPesquisas();
    }

    public void AtualizarListaPesquisas()
    {
        foreach (Transform filho in painelPesquisas)
            GameObject.Destroy(filho.gameObject);

        foreach (CategoriaPesquisa categoria in listaPesquisas.categorias)
        {
            GameObject categoriaObjeto = Instantiate(categoriaPrefab, painelPesquisas);

            GameObject categoriaNome = categoriaObjeto.transform.Find("Nome").gameObject;
            categoriaNome.GetComponent<TextMeshProUGUI>().text = categoria.nome;

            bool temPesquisa = false;
            foreach (Pesquisa pesquisa in categoria.pesquisas)
            {
                if (!pesquisa.EstaHabilitada(perfilSelecionado.perfil))
                    continue;

                temPesquisa = true;

                GameObject pesquisaObjeto = Instantiate(pesquisaPrefab, painelPesquisas);

                GameObject pesquisaNome = pesquisaObjeto.transform.Find("Nome").gameObject;
                pesquisaNome.GetComponent<TextMeshProUGUI>().text = pesquisa.nome;

                GameObject pesquisaCustoDinheiro = pesquisaObjeto.transform.Find("CustoDinheiro").gameObject;
                pesquisaCustoDinheiro.GetComponent<TextMeshProUGUI>().text = "R$ " + pesquisa.custoDinheiro.ToString("F2");

                GameObject pesquisaCustoPontos = pesquisaObjeto.transform.Find("CustoPontos").gameObject;
                pesquisaCustoPontos.GetComponent<TextMeshProUGUI>().text = pesquisa.custoPontosPesquisa.ToString();

                pesquisaObjeto.GetComponent<RealizarPesquisa>().pesquisa = pesquisa;
            }

            if (!temPesquisa)
                GameObject.Destroy(categoriaObjeto);
        }
    }
}
