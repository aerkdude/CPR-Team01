using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Paper;
    //public GameObject[] prefeb;
    GameObject Temp;
    private float spawnTime = 5f;
    public Transform[] spawnPoints;

    void Start()
    {
        //int prefeb_num = Random.Range(0, 3);
        InvokeRepeating("SpawnPaper", spawnTime, spawnTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Destroy(Temp);
        }
    }

    void SpawnPaper()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //Temp = Instantiate(prefeb[prefeb_num], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Temp = Instantiate(Paper, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}