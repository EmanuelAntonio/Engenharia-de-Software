using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de funcionarios", menuName="Funcionario/Lista")]
[System.Serializable]
public class ListaFuncionarios : ScriptableObject
{
    public List<Funcionario> funcionarios;
}
