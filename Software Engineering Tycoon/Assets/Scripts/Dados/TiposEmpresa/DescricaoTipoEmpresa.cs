using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo tipo de empresa", menuName="Tipo de empresa")]
public class DescricaoTipoEmpresa : ScriptableObject
{
    public string tipoEmpresa;
    public string nomeEmpresa;

    [Space(4)]
    [TextArea]
    public string descricaoProjeto;

    [Space(16)]

    // PropertyDrawer para barras com min e max
    // https://gist.github.com/frarees/9791517
    [Range(-0.1f, 1.1f)]
    public float dificuldadeMinima;
    [Range(-0.1f, 1.1f)]
    public float dificuldadeMaxima;

    [Space(16)]

    [Range(0.0f, 100000.0f)]
    public float pagamentoMinimo;
    [Range(0.0f, 100000.0f)]
    public float pagamentoMaximo;

    [Space(16)]

    [Range(0.0f, 1000.0f)]
    public float multaMinima;
    [Range(0.0f, 1000.0f)]
    public float multaMaxima;

    [Space(16)]

    [Range(0, 1000)]
    public int tamanhoMinimo;
    [Range(0, 1000)]
    public int tamanhoMaximo;

    [Space(16)]

    [Range(0.0f, 1.0f)]
    public float experienciaUsuarioMinima;
    [Range(0.0f, 1.0f)]
    public float experienciaUsuarioMaxima;

    [Space(16)]

    [Range(0, 1000)]
    public int pontosDesignEsperadoMinimo;
    [Range(0, 1000)]
    public int pontosDesignEsperadoMaximo;

    [Range(0, 1000)]
    public int pontosTecnologiaEsperadoMinimo;
    [Range(0, 1000)]
    public int pontosTecnologiaEsperadoMaximo;

    [Space(16)]

    public Prioridades prioridadesDesignBase;

    [Space(8)]

    public Prioridades prioridadesTecnologiaBase;

    [Space(16)]

    public List<string> listaDeDicas;
}
