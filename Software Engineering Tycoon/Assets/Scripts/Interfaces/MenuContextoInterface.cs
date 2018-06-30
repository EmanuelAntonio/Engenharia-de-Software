using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuContextoInterface : MonoBehaviour
{
    // private GerenciadorProjeto gerenciadorProjeto;
    public PerfilSelecionado perfilSelecionado;

    public ProjetoAtual projetoAtual;

    public UnityEvent eventoSalvarJogo;

    private GameObject menu;
    private Button novoProjeto;
    private Button pesquisas;
    private Button relatorios;
    private Button avancarEtapa;

    private bool _started = false;
    void Start()
    {
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
        novoProjeto.gameObject.SetActive(!projetoAtual.temProjeto);
        pesquisas.gameObject.SetActive(true);
        relatorios.gameObject.SetActive(true);
        avancarEtapa.gameObject.SetActive((!projetoAtual.temProjeto && perfilSelecionado.perfil.etapa == 0 && perfilSelecionado.perfil.ano >= 1971 && perfilSelecionado.perfil.verba > 30000));
    }

    public void AvancarEtapa()
    {
        perfilSelecionado.perfil.etapa = 1;
        eventoSalvarJogo.Invoke();

        SceneManager.LoadScene(perfilSelecionado.perfil.etapa + 1);
    }
}
