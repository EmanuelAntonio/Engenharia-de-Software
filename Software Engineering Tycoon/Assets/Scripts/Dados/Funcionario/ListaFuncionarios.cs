using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de funcionarios", menuName="Funcionario/Lista")]
[System.Serializable]
public class ListaFuncionarios : ScriptableObject
{
    public List<Funcionario> funcionarios;

    public void DefineSerializavel(ListaFuncionariosSerializavel serializavel)
    {
        funcionarios.Clear();
        for (int i = 0; i < serializavel.funcionarios.Count; ++i)
        {
            funcionarios.Add(serializavel.funcionarios[i]);
        }
    }

    public ListaFuncionariosSerializavel Serializavel()
    {
        ListaFuncionariosSerializavel resultado = new ListaFuncionariosSerializavel();

        resultado.funcionarios = new List<Funcionario>();
        foreach (Funcionario funcionario in funcionarios)
        {
            resultado.funcionarios.Add(funcionario);
        }

        return resultado;
    }
}

[System.Serializable]
public class ListaFuncionariosSerializavel
{
    public List<Funcionario> funcionarios;
}
