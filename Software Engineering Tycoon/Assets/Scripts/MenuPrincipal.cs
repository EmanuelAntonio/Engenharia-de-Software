using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
	public void CarregarPerfil(int indice)
	{
		Debug.Log("Abrindo perfil " + indice);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void SairJogo()
	{
		Debug.Log("Sair");
		Application.Quit();
	}
}
