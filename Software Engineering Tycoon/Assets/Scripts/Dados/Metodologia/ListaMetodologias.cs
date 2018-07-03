using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de metodologias", menuName="Metodologia/Lista")]
[System.Serializable]
public class ListaMetodologias : ScriptableObject
{
    public List<Metodologia> metodologias;

    public void DefineSerializavel(ListaMetodologiasSerializavel serializavel)
    {
        metodologias.Clear();
        for (int i = 0; i < serializavel.metodologias.Count; ++i)
        {
            metodologias.Add(serializavel.metodologias[i]);
        }
    }

    public ListaMetodologiasSerializavel Serializavel()
    {
        ListaMetodologiasSerializavel resultado = new ListaMetodologiasSerializavel();

        resultado.metodologias = new List<Metodologia>();
        foreach (Metodologia metodologia in metodologias)
        {
            resultado.metodologias.Add(metodologia);
        }

        return resultado;
    }
}

[System.Serializable]
public class ListaMetodologiasSerializavel
{
    public List<Metodologia> metodologias;
}
