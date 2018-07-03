using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo perfil", menuName="Perfil/Dados")]
[System.Serializable]
public class DadosPerfil : ScriptableObject
{
    public string nomeEmpresa;
    public string nomeJogador;
    public int dia;
    public int mes;
    public int ano;
    public int etapa;
    public int maximoFuncionarios;
    public int pontosPesquisa;
    public float verba;
    public bool novoPerfil;
    public int etapaTutorial;

    // TODO(2018-06-24): Encontrar um modo melhor de passar os valores de uma
    // instância para outra
    public void DefineValores(DadosPerfil perfil)
    {
        nomeEmpresa        = perfil.nomeEmpresa;
        nomeJogador        = perfil.nomeJogador;
        dia                = perfil.dia;
        mes                = perfil.mes;
        ano                = perfil.ano;
        etapa              = perfil.etapa;
        maximoFuncionarios = perfil.maximoFuncionarios;
        pontosPesquisa     = perfil.pontosPesquisa;
        verba              = perfil.verba;
        novoPerfil         = perfil.novoPerfil;
        etapaTutorial      = perfil.etapaTutorial;
    }

    public void DefineSerializavel(DadosPerfilSerializavel perfil)
    {
        nomeEmpresa        = perfil.nomeEmpresa;
        nomeJogador        = perfil.nomeJogador;
        dia                = perfil.dia;
        mes                = perfil.mes;
        ano                = perfil.ano;
        etapa              = perfil.etapa;
        maximoFuncionarios = perfil.maximoFuncionarios;
        pontosPesquisa     = perfil.pontosPesquisa;
        verba              = perfil.verba;
        novoPerfil         = perfil.novoPerfil;
        etapaTutorial      = perfil.etapaTutorial;
    }

    public DadosPerfilSerializavel Serializavel()
    {
        DadosPerfilSerializavel resultado = new DadosPerfilSerializavel();

        resultado.nomeEmpresa        = nomeEmpresa;
        resultado.nomeJogador        = nomeJogador;
        resultado.dia                = dia;
        resultado.mes                = mes;
        resultado.ano                = ano;
        resultado.etapa              = etapa;
        resultado.maximoFuncionarios = maximoFuncionarios;
        resultado.pontosPesquisa     = pontosPesquisa;
        resultado.verba              = verba;
        resultado.novoPerfil         = novoPerfil;
        resultado.etapaTutorial      = etapaTutorial;

        return resultado;
    }
}

[System.Serializable]
public class DadosPerfilSerializavel
{
    public string nomeEmpresa;
    public string nomeJogador;
    public int dia;
    public int mes;
    public int ano;
    public int etapa;
    public int maximoFuncionarios;
    public int pontosPesquisa;
    public float verba;
    public bool novoPerfil;
    public int etapaTutorial;
}
