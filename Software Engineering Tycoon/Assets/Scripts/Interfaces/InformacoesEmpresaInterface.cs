using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformacoesEmpresaInterface : MonoBehaviour
{
    private GameObject controladorJogo;

    private Perfil perfilCarregado;

    private TextMeshProUGUI data;
    private TextMeshProUGUI verba;


    void Start()
    {
        controladorJogo = GameObject.FindWithTag("GameController");
        if (controladorJogo == null)
        {
            Debug.LogError("É necessario existir um objeto ativo com a tag GameController na cena.");
        }

        perfilCarregado = controladorJogo.GetComponent<Perfil>();

        data = transform.Find("Data").GetComponent<TextMeshProUGUI>();
        verba = transform.Find("Verba").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        data.text = perfilCarregado.dia.ToString("D2") + "/" + perfilCarregado.mes.ToString("D2") + "/" + perfilCarregado.ano.ToString("D4");
        verba.text = "R$ " + perfilCarregado.verba.ToString("F2");
    }
}
