using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova lista de pesquisas", menuName="Pesquisa/Lista")]
public class ListaPesquisas : ScriptableObject
{
    public List<CategoriaPesquisa> categorias;
}
