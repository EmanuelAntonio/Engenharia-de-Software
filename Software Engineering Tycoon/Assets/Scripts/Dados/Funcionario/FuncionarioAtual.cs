using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Funcionario atual", menuName = "Funcionario/Atual")]
[System.Serializable]
public class FuncionarioAtual : ScriptableObject
{
    public bool temFuncionario;
    public Funcionario funcionario;
}
