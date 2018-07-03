using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Nova lista de pesquisas", menuName="Pesquisa/Lista")]
public class ListaPesquisas : ScriptableObject
{
    public List<CategoriaPesquisa> categorias;

    public void DefineSerializavel(ListaPesquisasSerializavel serializavel)
    {
        Assert.AreEqual(serializavel.categorias.Count, categorias.Count, "Arquivo de salve incorreto");

        for (int i = 0; i < serializavel.categorias.Count; ++i)
        {
            categorias[i].DefineSerializavel(serializavel.categorias[i]);
        }
    }

    public ListaPesquisasSerializavel Serializavel()
    {
        ListaPesquisasSerializavel resultado = new ListaPesquisasSerializavel();

        resultado.categorias = new List<CategoriaPesquisaSerializavel>();
        foreach (CategoriaPesquisa categoria in categorias)
        {
            resultado.categorias.Add(categoria.Serializavel());
        }

        return resultado;
    }
}

[System.Serializable]
public class ListaPesquisasSerializavel
{
    public List<CategoriaPesquisaSerializavel> categorias;
}
