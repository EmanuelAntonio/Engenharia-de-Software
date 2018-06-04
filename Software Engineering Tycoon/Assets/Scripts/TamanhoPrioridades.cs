using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoPrioridades : MonoBehaviour
{
    public LayoutElement Prioridade1;
    public LayoutElement Prioridade2;
    public LayoutElement Prioridade3;

    public Slider SliderPrioridade1;
    public Slider SliderPrioridade2;
    public Slider SliderPrioridade3;

    public float Peso;

    // Atualiza o tamanho das barras de prioridade
    public void AtualizaTamanho()
    {
        Prioridade1.flexibleWidth = 1 + SliderPrioridade1.value * Peso;
        Prioridade2.flexibleWidth = 1 + SliderPrioridade2.value * Peso;
        Prioridade3.flexibleWidth = 1 + SliderPrioridade3.value * Peso;
    }
}
