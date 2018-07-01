using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo projeto atual", menuName="Projeto/Atual")]
[System.Serializable]
public class ProjetoAtual : ScriptableObject
{
    public bool temProjeto;
    public Projeto projeto;
    public Prioridades prioridadesEscolhidas;
    public float progresso;

    // TODO(andre:2018-06-24): Considerar criar properties para acessar os valores
    // definidos em projeto
}
