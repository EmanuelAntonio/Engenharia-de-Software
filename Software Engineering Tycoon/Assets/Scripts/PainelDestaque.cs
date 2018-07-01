using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PainelDestaque : MonoBehaviour {

    public UnityEvent eventoPararRelogio;
    public UnityEvent eventoIniciarRelogio;

    // Quando o painel de destaque é exibido, o tempo do jogo deve parar
    void OnEnable()
    {
        eventoPararRelogio.Invoke();
    }

    void OnDisable()
    {
        eventoIniciarRelogio.Invoke();
    }
}
