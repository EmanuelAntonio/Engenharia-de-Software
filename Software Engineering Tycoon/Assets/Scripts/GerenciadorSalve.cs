using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GerenciadorSalve : MonoBehaviour
{
    public ListaPerfis listaPerfis;
    // public PerfilSelecionado perfilSelecionado;
    public DadosPerfil perfilBase;

    private string caminhoArquivo;

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

    // public void SelecionarPerfil(int id)
    // {
    //     perfilSelecionado.perfil = listaPerfis.perfis[id];
    // }

    public void ApagarPerfil(int id)
    {
        listaPerfis.perfis[id].DefineValores(perfilBase);

        Salvar();
    }

    public void Salvar()
    {
        string jsonString = JsonUtility.ToJson(listaPerfis.Serializavel());
        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (File.Exists(caminhoArquivo))
        {
            string jsonString = File.ReadAllText(caminhoArquivo);
            listaPerfis.DefineSerializavel(JsonUtility.FromJson<ListaPerfisSerializavel>(jsonString));
        }
        else
        {
            foreach (DadosPerfil perfil in listaPerfis.perfis)
            {
                perfil.DefineValores(perfilBase);
            }
        }
    }
}
