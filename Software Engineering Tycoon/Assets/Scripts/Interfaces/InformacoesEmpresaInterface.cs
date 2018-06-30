using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformacoesEmpresaInterface : MonoBehaviour
{
    public PerfilSelecionado perfilSelecionado;

    private TextMeshProUGUI data;
    private TextMeshProUGUI verba;

    void Start()
    {
        data = transform.Find("Data").GetComponent<TextMeshProUGUI>();
        verba = transform.Find("Verba").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        data.text = string.Format("{0:D2}/{1:D2}/{2:D4}", perfilSelecionado.perfil.dia, perfilSelecionado.perfil.mes, perfilSelecionado.perfil.ano);
        verba.text = string.Format("R$ {0:F2}", perfilSelecionado.perfil.verba);
    }
}
