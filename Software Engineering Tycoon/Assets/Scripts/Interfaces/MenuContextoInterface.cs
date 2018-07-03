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
    private Button contratarFuncionario;
    private Button avancarEscritorio;
    private Button avancarPredio;
    private Button salvarSair;

    private bool _started = false;
    void Start()
    {
        novoProjeto = transform.Find("NovoProjeto").GetComponent<Button>();
        pesquisas = transform.Find("Pesquisas").GetComponent<Button>();
        relatorios = transform.Find("Relatorios").GetComponent<Button>();
        contratarFuncionario = transform.Find("Funcionario").GetComponent<Button>();
        avancarEscritorio = transform.Find("AvancarEscritorio").GetComponent<Button>();
        avancarPredio = transform.Find("AvancarPredio").GetComponent<Button>();
        salvarSair = transform.Find("SalvarSair").GetComponent<Button>();

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
        // TODO(allan:2018-07-02): Considerar numero de funcionarios ja contratados para mostrar a opção de contratação.
        novoProjeto.gameObject.SetActive(!projetoAtual.temProjeto);
        pesquisas.gameObject.SetActive(true);
        relatorios.gameObject.SetActive(true);
        contratarFuncionario.gameObject.SetActive(true);
        avancarEscritorio.gameObject.SetActive((!projetoAtual.temProjeto && perfilSelecionado.perfil.etapa == 0 && perfilSelecionado.perfil.ano >= 1971 && perfilSelecionado.perfil.verba > 30000));
        avancarPredio.gameObject.SetActive((!projetoAtual.temProjeto && perfilSelecionado.perfil.etapa == 1 && perfilSelecionado.perfil.ano >= 1972 && perfilSelecionado.perfil.verba > 100000));
        salvarSair.gameObject.SetActive(true);
    }

    public void AvancarEtapa(int etapa)
    {
        perfilSelecionado.perfil.etapa = etapa;
        eventoSalvarJogo.Invoke();

        SceneManager.LoadScene(perfilSelecionado.perfil.etapa + 1);
    }

    public void SalvarSair()
    {
        eventoSalvarJogo.Invoke();

        SceneManager.LoadScene(0);
    }
}
