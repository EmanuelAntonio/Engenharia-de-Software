using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ProgressoProjetoInterface : MonoBehaviour
{
    public ProjetoAtual projetoAtual;

    private TextMeshProUGUI nomeEmpresa;
    private TextMeshProUGUI tipoEmpresa;
    private Slider barraProgresso;

    public UnityEvent atualizarProgresso;

    private bool _started = false;
    void Start()
    {
        nomeEmpresa = transform.Find("Progresso/Nome").GetComponent<TextMeshProUGUI>();
        tipoEmpresa = transform.Find("Progresso/Tipo").GetComponent<TextMeshProUGUI>();
        barraProgresso = transform.Find("Progresso/BarraProgresso").GetComponent<Slider>();

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

    public void AtualizarProgresso()
    {
        StartCoroutine(EncheProgressoCoroutine());
    }

    IEnumerator EncheProgressoCoroutine()
    {
        float valorInicial = projetoAtual.progresso;
        float deltaValor = projetoAtual.valor - valorInicial;
        float tempo = projetoAtual.tempo;
        float tempoPassado = 0;
        while (tempoPassado < tempo)
        {
            tempoPassado += Time.deltaTime;

            projetoAtual.progresso = valorInicial + deltaValor * (tempoPassado / tempo);
            barraProgresso.value = projetoAtual.progresso;
            atualizarProgresso.Invoke();

            yield return null;
        }
    }
}
