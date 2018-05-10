using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoPrioridades : MonoBehaviour
{
    public RectTransform TransformProprio;

    public RectTransform BarraPrioridade1;
    public RectTransform BarraPrioridade2;
    public RectTransform BarraPrioridade3;

    public Slider SliderPrioridade1;
    public Slider SliderPrioridade2;
    public Slider SliderPrioridade3;

    public float Scale = 1.0f;
    public float Offset = 0.1f;

    // Atualiza o tamanho das barras de prioridade
    public void AtualizaTamanho()
    {
        float pesoTotal = 0.0f;
        float larguraMaxima = TransformProprio.sizeDelta.x;

        pesoTotal += Offset + (SliderPrioridade1.value) * Scale;
        pesoTotal += Offset + (SliderPrioridade2.value) * Scale;
        pesoTotal += Offset + (SliderPrioridade3.value) * Scale;

        float larguraPorPeso = larguraMaxima / pesoTotal;

        BarraPrioridade1.sizeDelta = new Vector2((Offset + (SliderPrioridade1.value) * Scale) * larguraPorPeso, BarraPrioridade1.sizeDelta.y);
        BarraPrioridade2.sizeDelta = new Vector2((Offset + (SliderPrioridade2.value) * Scale) * larguraPorPeso, BarraPrioridade2.sizeDelta.y);
        BarraPrioridade3.sizeDelta = new Vector2((Offset + (SliderPrioridade3.value) * Scale) * larguraPorPeso, BarraPrioridade3.sizeDelta.y);
    }
}
