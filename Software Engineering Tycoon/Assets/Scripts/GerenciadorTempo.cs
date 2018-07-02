using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GerenciadorTempo : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;

    public float duracaoDia;
    public float dispesasMensais;
    private float tempoDesdeUltimoDia = 0;
    private bool relogioParado = false;

    public UnityEvent eventoSalvarJogo;
    public UnityEvent eventoGerarListaProjetos;

    void Update()
    {
        // Se o tempo nao tiver parado (em algum menu), incrementa o tempo
        if (!relogioParado)
        {
            tempoDesdeUltimoDia += Time.deltaTime;
        }
        // TODO(andre:2018-06-13): Considerar tamanhos de meses diferentes alem de ano bisexto
        while (tempoDesdeUltimoDia > duracaoDia)
        {
            perfilSelecionado.perfil.dia += 1;

            if (perfilSelecionado.perfil.dia > 30)
            {
                perfilSelecionado.perfil.dia -= 30;
                perfilSelecionado.perfil.mes += 1;

                eventoGerarListaProjetos.Invoke();

                if (perfilSelecionado.perfil.mes > 12)
                {
                    perfilSelecionado.perfil.mes -= 12;
                    perfilSelecionado.perfil.ano += 1;
                }

                perfilSelecionado.perfil.verba -= dispesasMensais;
                eventoSalvarJogo.Invoke();
            }

            tempoDesdeUltimoDia -= duracaoDia;
        }
    }

    public void PararRelogio()
    {
        relogioParado = true;
        Time.timeScale = 0;
    }

    public void IniciarRelogio()
    {
        relogioParado = false;
        Time.timeScale = 1;
    }
}
