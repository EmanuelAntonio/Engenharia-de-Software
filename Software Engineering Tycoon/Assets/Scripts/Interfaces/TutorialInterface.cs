using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInterface : MonoBehaviour
{
    private GameObject controladorJogo;

    private GerenciadorJogoUI gerenciadorJogoUI;
    private Perfil perfilCarregado;

    private bool _started = false;
    void Start()
    {
        controladorJogo = GameObject.FindWithTag("GameController");
        if (controladorJogo == null)
        {
            Debug.LogError("É necessario existir um objeto ativo com a tag GameController na cena.");
        }

        gerenciadorJogoUI = controladorJogo.GetComponent<GerenciadorJogoUI>();
        perfilCarregado = controladorJogo.GetComponent<Perfil>();

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

    public void Confirmar()
    {
        gerenciadorJogoUI.Confirmar();
    }

    public void AvancarEtapaTutorial(int etapa)
    {
        if (perfilCarregado.etapaTutorial < etapa)
        {
            perfilCarregado.etapaTutorial = etapa;
        }
        gerenciadorJogoUI.AvancarEtapaTutorial(perfilCarregado.etapaTutorial);

        perfilCarregado.Salvar();
    }
}
