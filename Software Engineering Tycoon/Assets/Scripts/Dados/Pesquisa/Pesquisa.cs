using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova pesquisa", menuName="Pesquisa/Pesquisa")]
public class Pesquisa : ScriptableObject
{
    public string nome;
    [TextArea]
    public string descricao;

    [Space(16)]

    public int custoPontosPesquisa;
    public float custoDinheiro;
    public int tempoPesquisa;

    [Space(16)]

    public int diaDesbloqueio;
    public int mesDesbloqueio;
    public int anoDesbloqueio;

    [Space(16)]

    // TODO(andre2018:07-02): Estabelecer uma forma melhor de desbloquear novas pesquisas
    public List<Pesquisa> pesquisasDesbloqueadas;

    [Space(16)]

    public bool desbloqueada;
    public bool pesquisada;

    public bool EstaHabilitada(DadosPerfil perfil)
    {
        if (!desbloqueada || pesquisada)
            return false;

        if ((perfil.ano < anoDesbloqueio) ||
            (perfil.ano == anoDesbloqueio && perfil.mes < mesDesbloqueio) ||
            (perfil.ano == anoDesbloqueio && perfil.mes == mesDesbloqueio && perfil.dia < diaDesbloqueio))
        {
            return false;
        }

        return true;
    }

    public bool PodePesquisar(DadosPerfil perfil)
    {
        if (!EstaHabilitada(perfil))
            return false;

        if (perfil.verba < custoDinheiro || perfil.pontosPesquisa < custoPontosPesquisa)
            return false;

        return true;
    }

    public void Pesquisar()
    {
        pesquisada = true;

        foreach (Pesquisa pesquisa in pesquisasDesbloqueadas)
        {
            pesquisa.desbloqueada = true;
        }
    }
}
