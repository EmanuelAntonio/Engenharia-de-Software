using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova metodologia atual", menuName="Metodologia/Atual")]
[System.Serializable]
public class MetodologiaAtual : ScriptableObject
{
    public Metodologia metodologia;
    public int indiceMetodologia;

    // TODO(andre:2018-06-24): Considerar criar properties para acessar os valores
    // definidos em Metodologia
}
