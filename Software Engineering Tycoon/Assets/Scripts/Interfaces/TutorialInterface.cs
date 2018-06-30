using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;

    private bool _started = false;
    void Start()
    {
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

    public void AvancarEtapaTutorial(int etapa)
    {
        if (perfilSelecionado.perfil.etapaTutorial < etapa)
        {
            perfilSelecionado.perfil.etapaTutorial = etapa;
        }
    }
}
