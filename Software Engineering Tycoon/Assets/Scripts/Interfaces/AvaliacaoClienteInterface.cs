using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvaliacaoClienteInterface : MonoBehaviour
{
    public ProjetoAtual projetoAtual;

    private Image imagem;
    private TextMeshProUGUI numero;

    public Sprite imagemAvaliacao0;
    public Sprite imagemAvaliacao1;
    public Sprite imagemAvaliacao2;
    public Sprite imagemAvaliacao3;
    public Sprite imagemAvaliacao4;

    private bool _started = false;
    void Start()
    {

        imagem = transform.Find("Avaliacao/Imagem").GetComponent<Image>();
        numero = transform.Find("Avaliacao/Numero").GetComponent<TextMeshProUGUI>();

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
        float avaliacao = projetoAtual.projeto.avaliacao;
        numero.text = (avaliacao * 10).ToString("F1") + " / 10.0";

        Debug.Log(avaliacao);

        if (avaliacao < 0.2)
            imagem.sprite = imagemAvaliacao0;
        else if (avaliacao < 0.4)
            imagem.sprite = imagemAvaliacao1;
        else if (avaliacao < 0.6)
            imagem.sprite = imagemAvaliacao2;
        else if (avaliacao < 0.8)
            imagem.sprite = imagemAvaliacao3;
        else
            imagem.sprite = imagemAvaliacao4;
    }
}
