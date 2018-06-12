using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Funcionario {

    private int habilidadeTecnologia;
    private int habilidadeDesign;
    private int habilidadePesquisa;

    private float salario;

    public Funcionario(int tecnologia, int design, int pesquisa, float salario)
    {
        this.habilidadeTecnologia = tecnologia;
        this.habilidadeDesign = design;
        this.habilidadePesquisa = pesquisa;
        this.salario = salario;
    }

    public int GetHabilidadeTecnologia()
    {
        return this.habilidadeTecnologia;
    }

    public void SetHabilidadeTecnologia( int habilidadeTecnologia)
    {
        this.habilidadeTecnologia = habilidadeTecnologia;
    }

    public int GetHabilidadeDesign()
    {
        return this.habilidadeDesign;
    }

    public void SetHabilidadeDesign( int habilidadeDesign)
    {
        this.habilidadeDesign = habilidadeDesign;
    }

    public int GetHabilidadePesquisa()
    {
        return this.habilidadePesquisa;
    }

    public void SetHabilidadePesquisa( int habilidadePesquisa)
    {
        this.habilidadePesquisa = habilidadePesquisa;
    }

    public float GetSalario()
    {
        return this.salario;
    }

    public void SetSalario(float salario)
    {
        this.salario = salario;
    }

}
