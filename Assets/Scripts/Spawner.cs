using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //y = 5
    // x = +-9
    public GameObject eggPrefab;
    public GameObject bombPrefab;
    public float spawnTime;

    private void Start() {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem(){
        while(true){
            yield return new WaitForSeconds(spawnTime);
            int random = Random.Range(0, 2);
            float randomX = Random.Range(-5f, 5f);
            if(random == 0){
                Instantiate(eggPrefab, new Vector2(randomX, 6), Quaternion.identity);
            }else{
                Instantiate(bombPrefab, new Vector2(randomX, 6), Quaternion.identity);
            }
        }
    }
}
