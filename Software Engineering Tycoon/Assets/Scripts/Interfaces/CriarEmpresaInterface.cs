using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CriarEmpresaInterface : MonoBehaviour
{
    // TODO(andre:2018:06-12): Encontrar uma forma mais organizada de atualizar a
    // referencia do perfil atual. Talvez usar Singleton para os gerenciadores.
    public Perfil perfilCarregado;

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
        perfilCarregado.nomeEmpresa = nomeEmpresa.text;
        perfilCarregado.nomeJogador = nomeJogador.text;
        perfilCarregado.novoPerfil = false;

        perfilCarregado.Salvar();
    }
}
