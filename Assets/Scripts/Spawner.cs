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
            GameObject item;
            float randomAngle = Random.Range(0f, 360f);
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle); 
            if(random == 0){
                item = Instantiate(eggPrefab, new Vector2(randomX, 6), rotation);
            }else{
                item = Instantiate(bombPrefab, new Vector2(randomX, 6), rotation);
            }
            int multiplier;
            if(Random.Range(0, 2) == 0){
                multiplier = -1;
            }else{
                multiplier = 1;
            }
            item.GetComponent<Rigidbody2D>().angularVelocity = multiplier * Random.Range(100f, 200f);
        }
    }
}
