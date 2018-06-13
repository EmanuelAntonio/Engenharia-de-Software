using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrioridadesInterface : MonoBehaviour
{
    public BarraProgresso sliderProgresso;

    private GameObject controladorJogo;

    private GerenciadorProjeto gerenciadorProjeto;
    private GerenciadorJogoUI gerenciadorJogoUI;

    private TextMeshProUGUI nomeEmpresa;
    private TextMeshProUGUI tipoEmpresa;

    private Slider slider1;
    private Slider slider2;
    private Slider slider3;

    // GAMIBIARRA
    public int idConjuntoSliders;

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

        nomeEmpresa = transform.Find("Nome").GetComponent<TextMeshProUGUI>();
        tipoEmpresa = transform.Find("Tipo").GetComponent<TextMeshProUGUI>();

        // TODO(andre:2018-06-13): Mesclar script de atualizacao da barras nesse script
        slider1 = transform.Find("Prioridades/Sliders/Slider1").GetComponent<Slider>();
        slider2 = transform.Find("Prioridades/Sliders/Slider2").GetComponent<Slider>();
        slider3 = transform.Find("Prioridades/Sliders/Slider3").GetComponent<Slider>();

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
        if (gerenciadorProjeto.temProjeto)
        {
            nomeEmpresa.text = gerenciadorProjeto.projetoAtual.nomeEmpresa;
            tipoEmpresa.text = gerenciadorProjeto.projetoAtual.tipoEmpresa;
        }
        else
        {
            nomeEmpresa.text = "<nome_empresa>";
            tipoEmpresa.text = "<tipo_empresa>";
        }
    }

    public void Confirmar()
    {
        gerenciadorJogoUI.Confirmar();

        // GAMBIARRA
        float peso = 4;
        switch (idConjuntoSliders)
        {
            case 0:
                gerenciadorProjeto.prioridadesEscolhidas.coletaDados = 1 + slider1.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.estudoDominio = 1 + slider2.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.documentacao = 1 + slider3.value * peso;
                break;

            case 1:
                gerenciadorProjeto.prioridadesEscolhidas.legibilidade = 1 + slider1.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.qualidadeSolucao = 1 + slider2.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.desenvolvimentoInterface = 1 + slider3.value * peso;
                break;

            case 2:
                gerenciadorProjeto.prioridadesEscolhidas.testes = 1 + slider1.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.avaliacaoCliente = 1 + slider2.value * peso;
                gerenciadorProjeto.prioridadesEscolhidas.implantacao = 1 + slider3.value * peso;
                break;
        }
    }

    public void AvancarEstagio()
    {
        gerenciadorJogoUI.AvancarEstagio();
    }

    // Gambiarra
    public void DefineValor(float valor)
    {
        sliderProgresso.DefineValor(valor);
    }

    // Gambiarra
    public void DefineTempo(float tempo)
    {
        sliderProgresso.DefineTempo(tempo);
    }

    // Gambiarra
    public void EncheProgresso()
    {
        sliderProgresso.EncheProgresso();
    }
}
