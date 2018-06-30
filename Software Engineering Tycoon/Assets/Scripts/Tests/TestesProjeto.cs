using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

namespace TestesUnitarios
{
    public class TestesProjeto
    {
/*
        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator TesteNormalizacaoPrioridades()
        {
            Prioridades prioridades = new Prioridades();
            prioridades.Contruct(1, 1, 1, 1, 1, 1, 1, 1, 1);

            Prioridades prioridadesNormalizada = prioridades.Normalizada();

            float somaPrioridades = prioridadesNormalizada.SomaPrioridades();
            Assert.AreEqual(somaPrioridades, 3.0f);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TesteAvaliacaoCliente()
        {
            Prioridades prioridadesProjeto = new Prioridades();
            prioridadesProjeto.Contruct(1, 1, 1, 1, 1, 1, 1, 1, 1);
            Projeto projeto = new Projeto("", "", "", 0.0f, 0.0f, 0, 1, prioridadesProjeto.Normalizada());

            Prioridades prioridadeJogador = new Prioridades();
            prioridadeJogador.Contruct(1, 1, 1, 1, 1, 1, 1, 1, 1);
            projeto.CalcularAvaliacao(prioridadeJogador);

            Assert.AreEqual(projeto.avaliacao, 1.0f);

            yield return null;
        }
*/
        /*[UnityTest]
        public IEnumerator TesteDeficuldadeProjeto()
        {
            var controladorJogo = Resources.Load("Prefabs/ControladorJogo");
            GameObject controladorGO = PrefabUtility.InstantiatePrefab(controladorJogo) as GameObject;
            Debug.Log(controladorJogo);
            GerenciadorProjeto gerProjeto = controladorGO.GetComponent<GerenciadorProjeto>();

            yield return null;

            Projeto projeto = gerProjeto.GerarProjeto(0.5f);

            Assert.AreEqual(projeto.descricaoTipoEmpresa.dificuldadeMinima <= 0.5f, true);
            Assert.AreEqual(projeto.descricaoTipoEmpresa.dificuldadeMaxima >= 0.5f, true);
        }*/
    }
}
