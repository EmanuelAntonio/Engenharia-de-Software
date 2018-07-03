using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Nova lista de perfis", menuName="Perfil/Lista")]
[System.Serializable]
public class ListaPerfis : ScriptableObject
{
    public List<DadosPerfil> perfis;
}
