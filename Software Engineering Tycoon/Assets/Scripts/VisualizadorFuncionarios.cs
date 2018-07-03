using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizadorFuncionarios : MonoBehaviour {

    public ListaFuncionarios funcionariosContratados;

    private void Start()
    {
        AtualizarFuncionarios();
    }

    public void AtualizarFuncionarios()
    {
        int numChilds = 1;
        foreach(Transform modeloFuncionario in transform)
        {
            numChilds++;
            bool activate = (numChilds <= funcionariosContratados.funcionarios.Count);
            modeloFuncionario.gameObject.SetActive(activate);
        }
    }
}
