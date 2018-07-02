using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrioridadesInterface : MonoBehaviour
{
    public ProjetoAtual projetoAtual;

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
        if (projetoAtual.temProjeto)
        {
            nomeEmpresa.text = projetoAtual.projeto.nomeEmpresa;
            tipoEmpresa.text = projetoAtual.projeto.tipoEmpresa;
        }
        else
        {
            nomeEmpresa.text = "<nome_empresa>";
            tipoEmpresa.text = "<tipo_empresa>";
        }
    }

    public void AtualizarPrioridades()
    {
        // GAMBIARRA
        float peso = 4;
        switch (idConjuntoSliders)
        {
            case 0:
                projetoAtual.prioridadesEscolhidas.coletaDados = 1 + slider1.value * peso;
                projetoAtual.prioridadesEscolhidas.estudoDominio = 1 + slider2.value * peso;
                projetoAtual.prioridadesEscolhidas.documentacao = 1 + slider3.value * peso;
                break;

            case 1:
                projetoAtual.prioridadesEscolhidas.legibilidade = 1 + slider1.value * peso;
                projetoAtual.prioridadesEscolhidas.qualidadeSolucao = 1 + slider2.value * peso;
                projetoAtual.prioridadesEscolhidas.desenvolvimentoInterface = 1 + slider3.value * peso;
                break;

            case 2:
                projetoAtual.prioridadesEscolhidas.testes = 1 + slider1.value * peso;
                projetoAtual.prioridadesEscolhidas.avaliacaoCliente = 1 + slider2.value * peso;
                projetoAtual.prioridadesEscolhidas.implantacao = 1 + slider3.value * peso;
                break;
        }
    }
}
