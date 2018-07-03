using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorNomes {

    public List<string> firstnames;
    public List<string> surnames;

    public GeradorNomes()
    {
        firstnames = new List<string>();
        surnames = new List<string>();

        TextAsset nameText = Resources.Load<TextAsset>("Names");

        string[] lines = nameText.text.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string[] names = lines[i].Split(' ');

            if(names[0] != "")
            {
                firstnames.Add(names[0]);
            }

            for (int j = 1; j < names.Length; j++)
            {
                if (names[j] != "")
                {
                    surnames.Add(names[j]);
                }
            }
        }
    }

    public string GerarNome()
    {
        string name = firstnames[Random.Range(0, firstnames.Count)];
        string surname = surnames[Random.Range(0, surnames.Count)];

        return name + " " + surname;
    }
}
