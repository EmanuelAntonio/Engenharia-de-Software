using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// https://youtu.be/raQ3iHhE_Kk?t=27m33s
// https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Events/GameEvent.cs
public class OuvinteEventoJogo : MonoBehaviour
{
    public EventoJogo evento;
    public UnityEvent resposta;

    void OnEnable()
    {
        evento.RegistrarOuvinte(this);
    }

    void OnDisable()
    {
        evento.RemoverOuvinte(this);
    }

    public void EmEventoDisparado()
    {
        resposta.Invoke();
    }
}
