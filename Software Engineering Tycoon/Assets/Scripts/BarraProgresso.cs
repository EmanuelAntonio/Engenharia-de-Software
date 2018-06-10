using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Gambiarra
public class BarraProgresso : MonoBehaviour
{
	private Slider slider;
	public float valor;
	public float tempo;
	public GerenciadorJogoUI gerenciadorJogoUI;

	void Start()
	{
		slider = GetComponent<Slider>();
		valor = slider.value;
		tempo = 1.0f;
	}

	// Gambiarra
	public void DefineValor(float valor)
	{
		this.valor = valor;
	}

	// Gambiarra
	public void DefineTempo(float tempo)
	{
		this.tempo = tempo;
	}

	public void EncheProgresso()
	{
		StartCoroutine(EncheProgressoCoroutine(valor, tempo));
	}

	IEnumerator EncheProgressoCoroutine(float valor, float tempo)
	{
		float valorInicial = slider.value;
		float deltaValor = valor - valorInicial;
		float tempoPassado = 0;
		while (tempoPassado < tempo)
		{
			tempoPassado += Time.deltaTime;
			gerenciadorJogoUI.DefinirProgresso(valorInicial + deltaValor * (tempoPassado / tempo));
			yield return null;
		}
	}
}
