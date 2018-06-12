using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pesquisa {
    private string nome;
    private int    custoPontosPesquisa;
    private float  custoDinheiro;
    private int    tempoPesquisa;

    public Pesquisa(string nome, int custoPontosPesquisa, float custoDinheiro, int tempoPesquisa)
    {
        this.nome = nome;
        this.custoPontosPesquisa = custoPontosPesquisa;
        this.custoDinheiro = custoDinheiro;
        this.tempoPesquisa = tempoPesquisa;
    }

    public string Nome()
    {
        return this.nome;
    }

    public int CustoPontosPesquisa()
    {
        return this.custoPontosPesquisa;
    }

    public float CustoDinheiro()
    {
        return this.custoDinheiro;
    }

    public int TempoPesquisa()
    {
        return this.tempoPesquisa;
    }
}
