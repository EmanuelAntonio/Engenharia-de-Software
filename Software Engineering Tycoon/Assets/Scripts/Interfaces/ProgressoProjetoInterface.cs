using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressoProjetoInterface : MonoBehaviour
{
    public GerenciadorProjeto gerenciadorProjeto;

    private TextMeshProUGUI nomeEmpresa;
    private TextMeshProUGUI tipoEmpresa;

    private bool _started = false;
    void Start()
    {
        nomeEmpresa = transform.Find("Progresso/Nome").GetComponent<TextMeshProUGUI>();
        tipoEmpresa = transform.Find("Progresso/Tipo").GetComponent<TextMeshProUGUI>();

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
}
