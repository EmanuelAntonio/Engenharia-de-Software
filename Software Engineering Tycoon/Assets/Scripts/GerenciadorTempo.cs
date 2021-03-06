﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GerenciadorTempo : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ListaFuncionarios funcionariosContratados;

    public float duracaoDia;
    public float dispesasMensais;
    private float tempoDesdeUltimoDia = 0;
    private bool relogioParado = false;

    public UnityEvent eventoSalvarJogo;
    public UnityEvent eventoGerarListaProjetos;
    public UnityEvent eventoGerarListaFuncionarios;

    void Start()
    {
        eventoGerarListaFuncionarios.Invoke();
    }

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
                eventoGerarListaFuncionarios.Invoke();

                if (perfilSelecionado.perfil.mes > 12)
                {
                    perfilSelecionado.perfil.mes -= 12;
                    perfilSelecionado.perfil.ano += 1;
                }

                perfilSelecionado.perfil.verba -= dispesasMensais;
                perfilSelecionado.perfil.verba -= MontanteSalarios();
                eventoSalvarJogo.Invoke();
            }

            tempoDesdeUltimoDia -= duracaoDia;
        }
    }

    float MontanteSalarios()
    {
        float total = 0.0f;
        foreach(Funcionario funcionario in funcionariosContratados.funcionarios)
        {
            total += funcionario.GetSalario();
        }
        return total;
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
