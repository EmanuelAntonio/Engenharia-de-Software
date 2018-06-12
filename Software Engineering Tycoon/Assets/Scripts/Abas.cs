using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abas : MonoBehaviour
{
    public Transform listaAbas;
    public Transform listaDetalhes;

    public GameObject abaAtiva;

    void Start()
    {
        foreach (Transform filho in listaDetalhes)
            filho.gameObject.SetActive(false);

        DefineAbaAtiva(0);
    }

    public void DefineAbaAtiva(GameObject novaAba)
    {
        if (abaAtiva != null)
            abaAtiva.SetActive(false);

        novaAba.SetActive(true);
        abaAtiva = novaAba;
    }

    public void DefineAbaAtiva(int id)
    {
        if (id < listaDetalhes.childCount)
            DefineAbaAtiva(listaDetalhes.GetChild(id).gameObject);
    }

    public void LimparAbas()
    {
        abaAtiva = null;

        foreach (Transform filho in listaAbas)
            GameObject.Destroy(filho.gameObject);

        foreach (Transform filho in listaDetalhes)
            GameObject.Destroy(filho.gameObject);
    }

    public void CriarAba(GameObject aba, GameObject detalhes, bool definirFoco = false)
    {
        aba.transform.SetParent(listaAbas, false);
        detalhes.transform.SetParent(listaDetalhes, false);

        detalhes.SetActive(false);

        if (definirFoco || abaAtiva == null)
            DefineAbaAtiva(detalhes);

        aba.GetComponent<Button>().onClick.AddListener(delegate { DefineAbaAtiva(detalhes); });
    }

    public void RemoverAba(int id)
    {
        GameObject abaRemover = listaAbas.GetChild(id).gameObject;
        GameObject detalhesRemover = listaDetalhes.GetChild(id).gameObject;

        abaRemover.transform.SetParent(null);
        detalhesRemover.transform.SetParent(null);

        if (GameObject.ReferenceEquals(detalhesRemover, abaAtiva))
        {
            abaAtiva = null;
            DefineAbaAtiva(0);
        }

        GameObject.Destroy(abaRemover);
        GameObject.Destroy(detalhesRemover);
    }

    public int ObterAbaSelecionada()
    {
        if (abaAtiva != null)
            return abaAtiva.transform.GetSiblingIndex();

        return -1;
    }
}
