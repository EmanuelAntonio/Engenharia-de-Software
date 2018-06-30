using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial1Interface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;

    private TextMeshProUGUI tutorial;

    private bool _started = false;
    void Start()
    {
        tutorial = transform.Find("Detalhes/Descricao").GetComponent<TextMeshProUGUI>();

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
        // tutorial.text = "Olá " + perfilSelecionado.perfil.nomeJogador +
        //                 ", seja bem vindo à Software Engineering Tycoon. Seu objetivo é fazer com que " + perfilSelecionado.perfil.nomeEmpresa +
        //                 " seja uma empresa de sucesso na área de engenharia de software.";
        tutorial.text = string.Format(@"Olá {0}, seja bem vindo à Software Engineering Tycoon. Seu objetivo é fazer com que {1} seja uma empresa de sucesso na área de engenharia de software.",
                                      perfilSelecionado.perfil.nomeJogador, perfilSelecionado.perfil.nomeEmpresa);
    }

    public void AvancarEtapaTutorial(int etapa)
    {
        if (perfilSelecionado.perfil.etapaTutorial < etapa)
        {
            perfilSelecionado.perfil.etapaTutorial = etapa;
        }
    }
}
