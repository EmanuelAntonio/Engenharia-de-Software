using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova categoria de pesquisas", menuName="Pesquisa/Categoria")]
public class CategoriaPesquisa : ScriptableObject
{
    public string nome;
    public List<Pesquisa> pesquisas;
}
