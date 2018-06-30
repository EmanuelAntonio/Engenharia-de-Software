using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Nova lista de perfis", menuName="Perfil/Lista")]
[System.Serializable]
public class ListaPerfis : ScriptableObject
{
    public List<DadosPerfil> perfis;

    public void DefineSerializavel(ListaPerfisSerializavel perfisSerializavel)
    {
        Debug.Log(perfisSerializavel.perfis.Count);
        Assert.AreEqual(perfisSerializavel.perfis.Count, perfis.Count, "Arquivo de salve incorreto");

        for (int i = 0; i < perfisSerializavel.perfis.Count; ++i)
        {
            perfis[i].DefineSerializavel(perfisSerializavel.perfis[i]);
        }
    }

    public ListaPerfisSerializavel Serializavel()
    {
        ListaPerfisSerializavel resultado = new ListaPerfisSerializavel();

        resultado.perfis = new List<DadosPerfilSerializavel>();
        foreach (DadosPerfil perfil in perfis)
        {
            resultado.perfis.Add(perfil.Serializavel());
        }

        return resultado;
    }
}

[System.Serializable]
public class ListaPerfisSerializavel
{
    // public DadosPerfil[] perfis;
    public List<DadosPerfilSerializavel> perfis;
}
