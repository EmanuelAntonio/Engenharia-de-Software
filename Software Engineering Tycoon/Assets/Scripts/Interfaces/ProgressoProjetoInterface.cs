using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressoProjetoInterface : MonoBehaviour
{
    private GameObject controladorJogo;

    private GerenciadorProjeto gerenciadorProjeto;
    private GerenciadorJogoUI gerenciadorJogoUI;

    private TextMeshProUGUI nomeEmpresa;
    private TextMeshProUGUI tipoEmpresa;

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

    public void Confirmar()
    {
        gerenciadorJogoUI.Confirmar();
    }

    public void AvancarEstagio()
    {
        gerenciadorJogoUI.AvancarEstagio();
    }

    public void ConcluirProjeto()
    {
        gerenciadorProjeto.ConcluirProjeto();
    }
}
