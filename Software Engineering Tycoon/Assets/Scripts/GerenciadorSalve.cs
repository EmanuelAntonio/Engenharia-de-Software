using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GerenciadorSalve : MonoBehaviour
{
    public ListaPerfis listaPerfis;
    // public PerfilSelecionado perfilSelecionado;
    public DadosPerfil perfilBase;
    public ProjetoAtual projetoAtual;
    public ListaFuncionarios listaFuncionarios;
    public ListaMetodologias listaMetodologias;
    public MetodologiaAtual metodologiaAtual;

    private string caminhoArquivo;

    void Awake()
    {
        // TODO(andre:2018-06-09): Salvando na pasta de assets por conveniencia.
        // Alterar para persistentDataPath quando o sistema de salve estiver
        // funcionando corretamente
        // caminhoArquivo = Application.persistentDataPath + "/save_game.dat";
        caminhoArquivo = Application.dataPath + "/save_game.dat";

        Carregar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Salvar();
            Debug.Log("Jogo salvo!");
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Carregar();
            Debug.Log("Jogo carregado!");
        }
    }

    // public void SelecionarPerfil(int id)
    // {
    //     perfilSelecionado.perfil = listaPerfis.perfis[id];
    // }

    public void ApagarPerfil(int id)
    {
        listaPerfis.perfis[id].DefineValores(perfilBase);

        Salvar();
    }

    public void Salvar()
    {
        string jsonString = JsonUtility.ToJson(listaPerfis.Serializavel());
        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (File.Exists(caminhoArquivo))
        {
            string jsonString = File.ReadAllText(caminhoArquivo);
            listaPerfis.DefineSerializavel(JsonUtility.FromJson<ListaPerfisSerializavel>(jsonString));
        }
        else
        {
            foreach (DadosPerfil perfil in listaPerfis.perfis)
            {
                perfil.DefineValores(perfilBase);
            }
        }

        // TODO(andre:2018-06-30): Criar interface grafica para criar a metodologia.
        // TODO(andre:2018-06-30): Salvar esses dados no arquivo de salve.
        EtapaMetodologia etapaPlanejamento = new EtapaMetodologia(TipoEtapaMetodologia.Planejamento, 1.0f, 3.0f);
        EtapaMetodologia etapaDesenvolvimento = new EtapaMetodologia(TipoEtapaMetodologia.Desenvolvimento, 1.0f, 3.0f);
        EtapaMetodologia etapaValidacao = new EtapaMetodologia(TipoEtapaMetodologia.Validacao, 1.0f, 3.0f);
        EtapaMetodologia etapaConcluir = new EtapaMetodologia(TipoEtapaMetodologia.Concluir, 2.0f);

        Metodologia metodologia = new Metodologia(projetoAtual);
        metodologia.etapas.Add(etapaPlanejamento);
        metodologia.etapas.Add(etapaDesenvolvimento);
        metodologia.etapas.Add(etapaValidacao);
        metodologia.etapas.Add(etapaConcluir);

        listaMetodologias.metodologias = new List<Metodologia>();
        listaMetodologias.metodologias.Add(metodologia);
        metodologiaAtual.metodologia = listaMetodologias.metodologias[0];

        Funcionario funcionario = new Funcionario(10, 10, 10, 10);
        listaFuncionarios.funcionarios = new List<Funcionario>();
        listaFuncionarios.funcionarios.Add(funcionario);
    }
}
