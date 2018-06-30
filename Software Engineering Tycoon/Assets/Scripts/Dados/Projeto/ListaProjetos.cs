using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de projetos", menuName="Projeto/Lista")]
[System.Serializable]
public class ListaProjetos : ScriptableObject
{
    public List<Projeto> projetos;
}
