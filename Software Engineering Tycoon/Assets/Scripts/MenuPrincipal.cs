using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject perfilPainel;

    void Start()
    {
        for (int i = 0; i < perfilPainel.transform.childCount; ++i)
        {
            PreencherDadosPerfil(perfilPainel.transform.GetChild(i), i);
        }
    }

    public void PreencherDadosPerfil(Transform perfil, int id)
    {
        DadosPerfil dadosPerfil = GerenciadorSalve.instancia.dados.perfil[id];

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
    }

    public void CarregarPerfil(int indice)
    {
        Debug.Log("Abrindo perfil " + indice);
        GerenciadorSalve.instancia.SelecionarPerfil(indice);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SairJogo()
    {
        Debug.Log("Sair");
        Application.Quit();
    }
}
