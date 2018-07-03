using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class SelecaoPerfil : MonoBehaviour
{
    public GameObject perfilPainel;

    public ListaPerfis listaPerfis;
    public PerfilSelecionado perfilSelecionado;
    // TODO(andre:2018-06-24): Tentar remover a logica de apagar o perfil dessa clase
    // e mover ela para o gerenciador de salve. O problema é passar o id do perfil
    // que tem que ser apagado usando eventos.
    public DadosPerfil perfilBase;

    void Start()
    {
        for (int i = 0; i < perfilPainel.transform.childCount; ++i)
        {
            PreencherDadosPerfil(perfilPainel.transform.GetChild(i), i);
        }
    }

    public void PreencherDadosPerfil(Transform perfil, int id)
    {
        DadosPerfil dadosPerfil = listaPerfis.perfis[id];

        Transform dados = perfil.Find("Dados");
        Transform criarPerfil = perfil.Find("CriarPerfil");

        if (!dadosPerfil.novoPerfil)
        {
            GameObject nomeJogador = dados.Find("Jogador").gameObject;
            nomeJogador.GetComponent<TextMeshProUGUI>().text = dadosPerfil.nomeJogador;

            GameObject nomeEmpresa = dados.Find("Empresa").gameObject;
            nomeEmpresa.GetComponent<TextMeshProUGUI>().text = dadosPerfil.nomeEmpresa;

            GameObject data = dados.Find("Data").gameObject;
            data.GetComponent<TextMeshProUGUI>().text = dadosPerfil.dia.ToString("D2") + "/" + dadosPerfil.mes.ToString("D2") + "/" + dadosPerfil.ano.ToString("D4");

            GameObject etapa = dados.Find("Etapa").gameObject;
            switch (dadosPerfil.etapa)
            {
                case 0:
                    etapa.GetComponent<TextMeshProUGUI>().text = "Garagem";
                    break;

                case 1:
                    etapa.GetComponent<TextMeshProUGUI>().text = "Escritório";
                    break;

                case 2:
                    etapa.GetComponent<TextMeshProUGUI>().text = "Prédio";
                    break;
            }

            GameObject verba = dados.Find("Verba").gameObject;
            verba.GetComponent<TextMeshProUGUI>().text = "R$ " + dadosPerfil.verba.ToString("F2");

            dados.gameObject.SetActive(true);
            criarPerfil.gameObject.SetActive(false);
        }
        else
        {
            dados.gameObject.SetActive(false);
            criarPerfil.gameObject.SetActive(true);
        }
    }

    public void CarregarPerfil(int id)
    {
        Debug.Log("Abrindo perfil " + id);

        perfilSelecionado.temPerfil = true;
        perfilSelecionado.perfil = listaPerfis.perfis[id];
        perfilSelecionado.indicePerfil = id;
        SceneManager.LoadScene(perfilSelecionado.perfil.etapa + 1);
    }

    public void ApagarPerfil(int id)
    {
        listaPerfis.perfis[id].DefineValores(perfilBase);

        PreencherDadosPerfil(perfilPainel.transform.GetChild(id), id);
    }
}
