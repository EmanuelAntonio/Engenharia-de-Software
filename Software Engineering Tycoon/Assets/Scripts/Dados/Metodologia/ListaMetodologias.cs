using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de metodologias", menuName="Metodologia/Lista")]
[System.Serializable]
public class ListaMetodologias : ScriptableObject
{
    public List<Metodologia> metodologias;
}
