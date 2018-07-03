using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo perfil selecionado", menuName="Perfil/Selecionado")]
[System.Serializable]
public class PerfilSelecionado : ScriptableObject
{
    public bool temPerfil;
    public DadosPerfil perfil;
    public int indicePerfil;

    // TODO(andre:2018-06-24): Considerar criar properties para acessar os valores
    // definidos em perfil
}
