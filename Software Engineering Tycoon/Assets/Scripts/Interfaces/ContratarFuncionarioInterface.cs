using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ContratarFuncionarioInterface : MonoBehaviour
{
    public GameObject abaFuncionarioPrefab;
    public GameObject detalhesFuncionarioPrefab;

    private Abas abasFuncionarios;
    private Button aceitarFuncionarioBotao;

    public ListaFuncionarios funcionariosDisponiveis;
    public ListaFuncionarios funcionariosContratados;

    private bool _started = false;
    void Start()
    {
        abasFuncionarios = transform.Find("AreaFuncionarios/ListaFuncionarios").GetComponent<Abas>();
        aceitarFuncionarioBotao = transform.Find("AceitarBotao").GetComponent<Button>();

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
        // TODO(andre>2018-06-25): Quando for criada a mensagem dizendo que a lista
        // foi atualizada, atualizar a lista de projeto apenas quando receber a mensagem.
        AtualizarListaFuncionarios();

        AtualizarBotaoContratarFuncionario();
    }

    public void AtualizarListaFuncionarios()
    {
        abasFuncionarios.LimparAbas();

        foreach (Funcionario funcionario in funcionariosDisponiveis.funcionarios)
        {
            GameObject abaFuncionario = Instantiate(abaFuncionarioPrefab);
            GameObject detalhesFuncionario = Instantiate(detalhesFuncionarioPrefab);

            GameObject abaNome = abaFuncionario.transform.Find("Nome").gameObject;
            abaNome.GetComponent<TextMeshProUGUI>().text = funcionario.GetNome();

            Transform detalhesTransform = detalhesFuncionario.transform;

            GameObject detalhesNomeEmpresa = detalhesTransform.Find("Nome").gameObject;
            detalhesNomeEmpresa.GetComponent<TextMeshProUGUI>().text = funcionario.GetNome();

            GameObject requisitosDesign = detalhesTransform.Find("Requisitos/Design/Texto").gameObject;
            requisitosDesign.GetComponent<TextMeshProUGUI>().text = funcionario.GetHabilidadeDesign().ToString();

            GameObject requisitosTecnologia = detalhesTransform.Find("Requisitos/Tecnologia/Texto").gameObject;
            requisitosTecnologia.GetComponent<TextMeshProUGUI>().text = funcionario.GetHabilidadeTecnologia().ToString();

            GameObject requisitosPesquisa = detalhesTransform.Find("Requisitos/Pesquisa/Texto").gameObject;
            requisitosPesquisa.GetComponent<TextMeshProUGUI>().text = funcionario.GetHabilidadePesquisa().ToString();

            GameObject detalhesPagamento = detalhesTransform.Find("MultaPagamento/Pagamento").gameObject;
            detalhesPagamento.GetComponent<TextMeshProUGUI>().text = "Salário: R$ " + funcionario.GetSalario().ToString();

            abasFuncionarios.CriarAba(abaFuncionario, detalhesFuncionario);
        }

        AtualizarBotaoContratarFuncionario();
    }

    public void AceitarFuncionarioSelecionado()
    {
        int funcionarioSelecionado = abasFuncionarios.ObterAbaSelecionada();

        if (funcionarioSelecionado >= 0)
        {
            funcionariosContratados.funcionarios.Add(funcionariosDisponiveis.funcionarios[funcionarioSelecionado]);

            abasFuncionarios.RemoverAba(funcionarioSelecionado);
            funcionariosDisponiveis.funcionarios.RemoveAt(funcionarioSelecionado);

            AtualizarBotaoContratarFuncionario();
        }
    }

    public void AtualizarBotaoContratarFuncionario()
    {
        aceitarFuncionarioBotao.interactable = (abasFuncionarios.abaAtiva != null);
    }
}
