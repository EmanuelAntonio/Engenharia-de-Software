using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressoProjetoInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;
    public ProjetoAtual projetoAtual;

    private TextMeshProUGUI pontosDesign;
    private TextMeshProUGUI pontosTecnologia;
    private TextMeshProUGUI pontosErro;
    private TextMeshProUGUI pontosPesquisa;

    private TextMeshProUGUI nomeEmpresa;
    private TextMeshProUGUI tipoEmpresa;
    private Slider barraProgresso;

    private bool _started = false;
    void Start()
    {
        pontosDesign = transform.Find("Design/DesignPontos/Texto").GetComponent<TextMeshProUGUI>();
        pontosTecnologia = transform.Find("Tecnologia/TecnologiaPontos/Texto").GetComponent<TextMeshProUGUI>();
        pontosErro = transform.Find("Erro/ErroPontos/Texto").GetComponent<TextMeshProUGUI>();
        pontosPesquisa = transform.Find("Pesquisa/PesquisaPontos/Texto").GetComponent<TextMeshProUGUI>();

        nomeEmpresa = transform.Find("Progresso/Nome").GetComponent<TextMeshProUGUI>();
        tipoEmpresa = transform.Find("Progresso/Tipo").GetComponent<TextMeshProUGUI>();
        barraProgresso = transform.Find("Progresso/BarraProgresso").GetComponent<Slider>();

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
        if (projetoAtual.temProjeto)
        {
            nomeEmpresa.text = projetoAtual.projeto.nomeEmpresa;
            tipoEmpresa.text = projetoAtual.projeto.tipoEmpresa;
        }
        else
        {
            nomeEmpresa.text = "<nome_empresa>";
            tipoEmpresa.text = "<tipo_empresa>";
        }

        AtualizarProgresso();
    }

    public void AtualizarProgresso()
    {
        pontosDesign.text     = projetoAtual.projeto.pontosDesign.ToString();
        pontosTecnologia.text = projetoAtual.projeto.pontosTecnologia.ToString();
        pontosErro.text       = projetoAtual.projeto.pontosErro.ToString();
        pontosPesquisa.text   = perfilSelecionado.perfil.pontosPesquisa.ToString();

        barraProgresso.value = projetoAtual.progresso;
    }
}
