using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// TODO(andre:2018-06-12): Criar classe para a interface de carregamento de perfil
public class MenuPrincipalInterface : MonoBehaviour
{
    public void SairJogo()
    {
        Debug.Log("Sair");
        Application.Quit();
    }
}
