using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GerenciadorSalve : MonoBehaviour
{
    public static GerenciadorSalve instancia = null;

    public DadosSalvar dados;
    public int perfilSelecionado;

    public int quantPerfil;

    private string caminhoArquivo;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // TODO(andre:2018-06-09): Salvando na pasta de assets por conveniencia.
        // Alterar para persistentDataPath quando o sistema de salve estiver
        // funcionando corretamente
        // caminhoArquivo = Application.persistentDataPath + "/save_game.dat";
        caminhoArquivo = Application.dataPath + "/save_game.dat";

        Carregar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log("Jogo salvo!");
            Salvar();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Debug.Log("Jogo carregado!");
            Carregar();
        }
    }

    public void SelecionarPerfil(int id)
    {
        perfilSelecionado = id;
    }

    public void SalvarPerfil(Perfil perfil)
    {
        DadosPerfil dadosPerfil = dados.perfil[perfilSelecionado];

        dadosPerfil.nomeEmpresa = perfil.nomeEmpresa;
        dadosPerfil.nomeJogador = perfil.nomeJogador;
        dadosPerfil.dia = perfil.dia;
        dadosPerfil.mes = perfil.mes;
        dadosPerfil.ano = perfil.ano;
        dadosPerfil.etapa = perfil.etapa;
        dadosPerfil.maximoFuncionario = perfil.maximoFuncionario;
        dadosPerfil.pontosPesquisa = perfil.pontosPesquisa;
        dadosPerfil.verba = perfil.verba;

        Salvar();
    }

    public void CarregarPerfil(Perfil perfil)
    {
        DadosPerfil dadosPerfil = dados.perfil[perfilSelecionado];

        perfil.nomeEmpresa = dadosPerfil.nomeEmpresa;
        perfil.nomeJogador = dadosPerfil.nomeJogador;
        perfil.dia = dadosPerfil.dia;
        perfil.mes = dadosPerfil.mes;
        perfil.ano = dadosPerfil.ano;
        perfil.etapa = dadosPerfil.etapa;
        perfil.maximoFuncionario = dadosPerfil.maximoFuncionario;
        perfil.pontosPesquisa = dadosPerfil.pontosPesquisa;
        perfil.verba = dadosPerfil.verba;
    }

    public void Salvar()
    {
        string jsonString = JsonUtility.ToJson(dados);
        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (File.Exists(caminhoArquivo))
        {
            string jsonString = File.ReadAllText(caminhoArquivo);
            JsonUtility.FromJsonOverwrite(jsonString, dados);
        }
        else
        {
            dados.perfil = new DadosPerfil[quantPerfil];
            for (int i = 0; i < quantPerfil; ++i)
            {
                dados.perfil[i] = new DadosPerfil();
            }
        }
    }
}

[System.Serializable]
public class DadosSalvar
{
    public DadosPerfil[] perfil;
}

[System.Serializable]
public class DadosPerfil
{
    public string nomeEmpresa = "";
    public string nomeJogador = "";
    public int dia = 0;
    public int mes = 0;
    public int ano = 0;
    public int etapa = 0;
    public int maximoFuncionario = 0;
    public int pontosPesquisa = 0;
    public float verba = 0;
    public bool novoPerfil = true;
}
