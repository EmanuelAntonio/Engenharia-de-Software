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
	public GameObject proximaTela;

	void Start()
	{
		slider = GetComponent<Slider>();
		valor = slider.value;
		tempo = 1.0f;
		proximaTela = null;
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

	// Gambiarra
	public void DefineProximaTela(GameObject proximaTela)
	{
		this.proximaTela = proximaTela;
	}

	public void EncheProgresso()
	{
		StartCoroutine(EncheProgressoCoroutine(valor, tempo, proximaTela));
	}

	IEnumerator EncheProgressoCoroutine(float valor, float tempo, GameObject proximaTela)
	{
		float valorInicial = slider.value;
		float deltaValor = valor - valorInicial;
		float tempoPassado = 0;
		while (tempoPassado < tempo)
		{
			tempoPassado += Time.deltaTime;
			slider.value = valorInicial + deltaValor * (tempoPassado / tempo);
			yield return null;
		}

		if (proximaTela)
		{
			proximaTela.SetActive(true);
		}
	}
}
