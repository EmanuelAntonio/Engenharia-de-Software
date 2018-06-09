using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoPrioridades : MonoBehaviour
{
    public LayoutElement prioridade1;
    public LayoutElement prioridade2;
    public LayoutElement prioridade3;

    public Slider sliderPrioridade1;
    public Slider sliderPrioridade2;
    public Slider sliderPrioridade3;

    public float peso;

    // Atualiza o tamanho das barras de prioridade
    public void AtualizaTamanho()
    {
        prioridade1.flexibleWidth = 1 + sliderPrioridade1.value * peso;
        prioridade2.flexibleWidth = 1 + sliderPrioridade2.value * peso;
        prioridade3.flexibleWidth = 1 + sliderPrioridade3.value * peso;
    }
}
