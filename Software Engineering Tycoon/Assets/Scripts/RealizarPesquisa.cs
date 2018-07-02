using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RealizarPesquisa : MonoBehaviour
{
    public Pesquisa pesquisa;
    public PerfilSelecionado perfilSelecionado;

    public UnityEvent eventoPesquisar;

    public void Pequisar()
    {
        if (pesquisa.PodePesquisar(perfilSelecionado.perfil))
        {
            perfilSelecionado.perfil.verba -= pesquisa.custoDinheiro;
            perfilSelecionado.perfil.pontosPesquisa -= pesquisa.custoPontosPesquisa;

            // TODO(andre:2018-07-02): Fazer com que a pesquisa consuma tempo de algum funcionário
            // Primeiro é necessario fazer com que seja possivel selecionar um funcionário
            pesquisa.Pesquisar();
            eventoPesquisar.Invoke();
        }
    }
}
