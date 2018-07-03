using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.IO;

public class GerenciadorSalve : MonoBehaviour
{
    public ListaPerfis listaPerfis;
    public PerfilSelecionado perfilSelecionado;
    public DadosPerfil perfilBase;
    public ProjetoAtual projetoAtual;
    public ListaFuncionarios listaFuncionarios;
    public ListaMetodologias listaMetodologias;
    public MetodologiaAtual metodologiaAtual;
    public ListaPesquisas listaPesquisas;
    public ListaProjetos listaProjetosConcluidos;

    private string caminhoArquivo;

    private DadosSalveLista listaDados;

    void Awake()
    {
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
            Salvar();
            Debug.Log("Jogo salvo!");
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Carregar();
            Debug.Log("Jogo carregado!");
        }
    }

    // public void SelecionarPerfil(int indice)
    // {
    //     perfilSelecionado.temPerfil = true;
    //     perfilSelecionado.perfil = listaPerfis.perfis[indice];
    //     perfilSelecionado.indicePerfil = indice;
    // }

    public void ApagarPerfil(int indice)
    {
        listaPerfis.perfis[indice].DefineValores(perfilBase);
        AtualizarDadosSalve();

        Salvar();
    }

    public void Salvar()
    {
        AtualizarDadosSalve();

        string jsonString = JsonUtility.ToJson(listaDados, true);
        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void AtualizarDadosSalve()
    {
        for (int i = 0; i < listaDados.dados.Count; ++i)
        {
            listaDados.dados[i].perfil = listaPerfis.perfis[i].Serializavel();
        }

        if (perfilSelecionado.temPerfil)
        {
            int indice = perfilSelecionado.indicePerfil;

            listaDados.dados[indice].funcionarios = listaFuncionarios.Serializavel();

            listaDados.dados[indice].metodologias = listaMetodologias.Serializavel();
            listaDados.dados[indice].indiceMetodologiaAtual = metodologiaAtual.indiceMetodologia;

            listaDados.dados[indice].pesquisas = listaPesquisas.Serializavel();
        }
    }

    public void Carregar()
    {
        listaProjetosConcluidos.projetos.Clear();

        if (File.Exists(caminhoArquivo))
        {
            string jsonString = File.ReadAllText(caminhoArquivo);
            // TODO(andre:2018-07-02): Tentar utilizar FromJsonOverwrite
            listaDados = JsonUtility.FromJson<DadosSalveLista>(jsonString);

            Assert.AreEqual(listaDados.dados.Count, listaPerfis.perfis.Count, "Arquivo de salve incorreto");
            for (int i = 0; i < listaDados.dados.Count; ++i)
            {
                listaPerfis.perfis[i].DefineSerializavel(listaDados.dados[i].perfil);
            }

            if (perfilSelecionado.temPerfil && !perfilSelecionado.perfil.novoPerfil)
            {
                listaFuncionarios.DefineSerializavel(listaDados.dados[perfilSelecionado.indicePerfil].funcionarios);

                listaMetodologias.DefineSerializavel(listaDados.dados[perfilSelecionado.indicePerfil].metodologias);
                if(listaMetodologias.metodologias.Count > 0)
                {
                    metodologiaAtual.indiceMetodologia = listaDados.dados[perfilSelecionado.indicePerfil].indiceMetodologiaAtual;
                    metodologiaAtual.metodologia = listaMetodologias.metodologias[metodologiaAtual.indiceMetodologia];
                }

                listaPesquisas.DefineSerializavel(listaDados.dados[perfilSelecionado.indicePerfil].pesquisas);
            }
        }
        else
        {
            listaDados = new DadosSalveLista();

            foreach (DadosPerfil perfil in listaPerfis.perfis)
            {
                perfil.DefineValores(perfilBase);

                listaDados.dados.Add(new DadosSalve());
            }

            AtualizarDadosSalve();
        }
    }
}

[System.Serializable]
public class DadosSalveLista
{
    public List<DadosSalve> dados;

    public DadosSalveLista()
    {
        dados = new List<DadosSalve>();
    }
}

[System.Serializable]
public class DadosSalve
{
    public DadosPerfilSerializavel perfil;

    public ListaFuncionariosSerializavel funcionarios;

    public ListaMetodologiasSerializavel metodologias;
    public int indiceMetodologiaAtual;

    public ListaPesquisasSerializavel pesquisas;
}
