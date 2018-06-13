using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuContextoInterface : MonoBehaviour
{
    private GameObject controladorJogo;

    private GerenciadorProjeto gerenciadorProjeto;
    private GerenciadorJogoUI gerenciadorJogoUI;
    private Perfil perfilCarregado;

    private GameObject menu;
    private Button novoProjeto;
    private Button pesquisas;
    private Button relatorios;
    private Button avancarEtapa;

    private bool _started = false;
    void Start()
    {
        controladorJogo = GameObject.FindWithTag("GameController");
        if (controladorJogo == null)
        {
            Debug.LogError("É necessario existir um objeto ativo com a tag GameController na cena.");
        }

        gerenciadorProjeto = controladorJogo.GetComponent<GerenciadorProjeto>();
        gerenciadorJogoUI = controladorJogo.GetComponent<GerenciadorJogoUI>();
        perfilCarregado = controladorJogo.GetComponent<Perfil>();

        novoProjeto = transform.Find("NovoProjeto").GetComponent<Button>();
        pesquisas = transform.Find("Pesquisas").GetComponent<Button>();
        relatorios = transform.Find("Relatorios").GetComponent<Button>();
        avancarEtapa = transform.Find("AvancarEtapa").GetComponent<Button>();

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
        // TODO(andre:2018-06-13): Mover essa logica para algum lugar que faça mais sentido
        novoProjeto.gameObject.SetActive(!gerenciadorProjeto.temProjeto);
        pesquisas.gameObject.SetActive(true);
        relatorios.gameObject.SetActive(true);
        avancarEtapa.gameObject.SetActive((!gerenciadorProjeto.temProjeto && perfilCarregado.etapa == 0 && perfilCarregado.ano >= 1971 && perfilCarregado.verba > 30000));
    }

    public void ExibirAceitarProjeto()
    {
        gerenciadorJogoUI.ExibirAceitarProjeto();
    }

    public void AvancarEtapa()
    {
        gerenciadorProjeto.AvancarEtapa();
    }
}
