using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CriarEmpresaInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ListaFuncionarios listaFuncionarios;
    public ListaMetodologias listaMetodologias;
    public MetodologiaAtual metodologiaAtual;

    private TMP_InputField nomeEmpresa;
    private TMP_InputField nomeJogador;

    private bool _started = false;
    void Start()
    {
        nomeEmpresa = transform.Find("Detalhes/NomeEmpresa/Input").GetComponent<TMP_InputField>();
        nomeJogador = transform.Find("Detalhes/NomeJogador/Input").GetComponent<TMP_InputField>();

        _started = true;
        this.OnStartOrEnable();
    }

    void OnEnable()
    {
        if (_started) this.OnStartOrEnable();
    }

    // O primeiro OnEnable() pode ser chamado antes do Start()
    // https://forum.unity.com/threads/awake-start-and-onenable-walked-into-a-bar.276712/
    void OnStartOrEnable()
    {
    }

    public void AtualizarPerfil()
    {
        perfilSelecionado.perfil.nomeEmpresa = nomeEmpresa.text;
        perfilSelecionado.perfil.nomeJogador = nomeJogador.text;
        perfilSelecionado.perfil.novoPerfil = false;

        // TODO(andre:2018-06-30): Criar interface grafica para criar a metodologia.
        EtapaMetodologia etapaPlanejamento = new EtapaMetodologia(TipoEtapaMetodologia.Planejamento, 1.0f, 3.0f);
        EtapaMetodologia etapaDesenvolvimento = new EtapaMetodologia(TipoEtapaMetodologia.Desenvolvimento, 1.0f, 3.0f);
        EtapaMetodologia etapaValidacao = new EtapaMetodologia(TipoEtapaMetodologia.Validacao, 1.0f, 3.0f);
        EtapaMetodologia etapaConcluir = new EtapaMetodologia(TipoEtapaMetodologia.Concluir, 2.0f);

        Metodologia metodologia = new Metodologia();
        metodologia.etapas.Add(etapaPlanejamento);
        metodologia.etapas.Add(etapaDesenvolvimento);
        metodologia.etapas.Add(etapaValidacao);
        metodologia.etapas.Add(etapaConcluir);

        listaMetodologias.metodologias = new List<Metodologia>();
        listaMetodologias.metodologias.Add(metodologia);
        metodologiaAtual.indiceMetodologia = 0;
        metodologiaAtual.metodologia = listaMetodologias.metodologias[metodologiaAtual.indiceMetodologia];

        Funcionario funcionario = new Funcionario(10, 10, 10, 10);
        listaFuncionarios.funcionarios = new List<Funcionario>();
        listaFuncionarios.funcionarios.Add(funcionario);
    }
}
