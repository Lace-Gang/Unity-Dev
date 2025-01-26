using System.Collections;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Transform barrel;
    [SerializeField, Range(0.5f, 5)]float spawnTime;
    [SerializeField, Range(0f, 5f)] float spawnTimeMin;
    [SerializeField, Range(0f, 5f)] float spawnTimeMax;


    float spawnTimer;
    Destructable destructable;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destructable = GetComponent<Destructable>();
        StartCoroutine(SpawnFire());
        spawnTimer = Time.time + spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //_____These have been replaced by the functionality of SpawnFire()
        //spawnTimer -= Time.deltaTime;
        //if (Time.time >= spawnTimer)
        //{
        //    spawnTimer = Time.time + spawnTime;
        //    Instantiate(rocketPrefab, barrel.position, barrel.rotation);
        //}

        if (destructable.Health <= 0)
        {
            //
        }
    }


    //good for setting things on timers :)
    IEnumerator SpawnFire()
    {
        while (true)
        {
            //set min and max to zero to have a static time
            if(spawnTimeMin > 0 &&  spawnTimeMax > 0) spawnTime = Random.Range(spawnTimeMin, spawnTimeMax); 
            yield return new WaitForSeconds(spawnTime);
            Instantiate(rocketPrefab, barrel.position, barrel.rotation);
        }
    }
}
