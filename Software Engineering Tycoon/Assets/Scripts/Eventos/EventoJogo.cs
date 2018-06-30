using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://youtu.be/raQ3iHhE_Kk?t=27m33s
// https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Events/GameEventListener.cs
[CreateAssetMenu(fileName = "Novo evento", menuName="Evento")]
public class EventoJogo : ScriptableObject
{
    private readonly List<OuvinteEventoJogo> ouvinteEventos = new List<OuvinteEventoJogo>();

    public void Disparar()
    {
        for (int i = ouvinteEventos.Count - 1; i >= 0; --i)
        {
            ouvinteEventos[i].EmEventoDisparado();
        }
    }

    public void RegistrarOuvinte(OuvinteEventoJogo ouvinte)
    {
        if (!ouvinteEventos.Contains(ouvinte))
            ouvinteEventos.Add(ouvinte);
    }

    public void RemoverOuvinte(OuvinteEventoJogo ouvinte)
    {
        if (ouvinteEventos.Contains(ouvinte))
            ouvinteEventos.Remove(ouvinte);
    }
}
