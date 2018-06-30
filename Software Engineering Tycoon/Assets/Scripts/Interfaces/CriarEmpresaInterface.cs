using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CriarEmpresaInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;

    private TMP_InputField nomeEmpresa;
    private TMP_InputField nomeJogador;

    private bool _started = false;
    void Start()
    {
        nomeEmpresa = transform.Find("Detalhes/NomeEmpresa/Input").GetComponent<TMP_InputField>();
        nomeJogador = transform.Find("Detalhes/NomeJogador/Input").GetComponent<TMP_InputField>();

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
    }

    public void AtualizarPerfil()
    {
        perfilSelecionado.perfil.nomeEmpresa = nomeEmpresa.text;
        perfilSelecionado.perfil.nomeJogador = nomeJogador.text;
        perfilSelecionado.perfil.novoPerfil = false;
    }
}
