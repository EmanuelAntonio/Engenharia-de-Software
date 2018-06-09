using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfil : MonoBehaviour
{
    public string nomeEmpresa;
    public string nomeJogador;
    public int dia;
    public int mes;
    public int ano;
    public int etapa;
    public int maximoFuncionario;
    public int pontosPesquisa;
    public float verba;

    void Awake()
    {
        GerenciadorSalve.instancia.CarregarPerfil(this);
    }
}
