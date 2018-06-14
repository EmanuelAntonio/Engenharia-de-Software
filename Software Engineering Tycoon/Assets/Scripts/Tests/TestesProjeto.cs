using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace TestesUnitarios
{
    public class TestesProjeto
    {

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
    }
}
