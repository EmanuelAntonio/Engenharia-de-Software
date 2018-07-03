using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Nova categoria de pesquisas", menuName="Pesquisa/Categoria")]
public class CategoriaPesquisa : ScriptableObject
{
    public string nome;
    public List<Pesquisa> pesquisas;

    public void DefineSerializavel(CategoriaPesquisaSerializavel serializavel)
    {
        Assert.AreEqual(serializavel.pesquisas.Count, pesquisas.Count, "Arquivo de salve incorreto");

        for (int i = 0; i < serializavel.pesquisas.Count; ++i)
        {
            pesquisas[i].DefineSerializavel(serializavel.pesquisas[i]);
        }
    }

    public CategoriaPesquisaSerializavel Serializavel()
    {
        CategoriaPesquisaSerializavel resultado = new CategoriaPesquisaSerializavel();

        resultado.pesquisas = new List<PesquisaSerializavel>();
        foreach (Pesquisa pesquisa in pesquisas)
        {
            resultado.pesquisas.Add(pesquisa.Serializavel());
        }

        return resultado;
    }
}

[System.Serializable]
public class CategoriaPesquisaSerializavel
{
    public List<PesquisaSerializavel> pesquisas;
}
