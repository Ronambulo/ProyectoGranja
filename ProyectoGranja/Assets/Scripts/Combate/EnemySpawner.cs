using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float tiempoSpawn = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool puedeSpawnear = true;

    int enemigosGenerados = 0;

    private void Start() {
        //Start coroutine es para iniciar la ejecución de una rutina: son funciones especiales que se utilizan para tareas como animaciones graduales,
        // dividirr el trabajo en fotogramas...
        StartCoroutine(Spawner());

        puedeSpawnear = true;
    }

    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(tiempoSpawn);

        while (true)
        {
            yield return wait;

            if (puedeSpawnear) {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyQueSpawnea = enemyPrefabs[rand];

                //rotanión neutra o sin rotación
                Instantiate(enemyQueSpawnea, transform.position, Quaternion.identity);

                enemigosGenerados++;
                if (enemigosGenerados >= 3) { 
                    puedeSpawnear=false;
                    enemigosGenerados=0;
                    //yield return waitForSeconds();
                    //puedeSpawnear = true;
                }
            }

        }
    }

}
