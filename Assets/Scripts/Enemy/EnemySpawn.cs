using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enenmyPrefab;
    [SerializeField] private int maxEnemy;
    [SerializeField] private Transform[] spawnPos;



    private List<GameObject> _enemysAlive = new List<GameObject>();
    
    private float _nextSpawnTime;
    private float _groundSpawnCooldown = 7f;
    void Start()
    {
        
        _nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        _enemysAlive.RemoveAll(item => item == null);
        if (_enemysAlive.Count < maxEnemy && Time.time > _nextSpawnTime)
        {
           SpawnNewEnemy();
            _nextSpawnTime = Time.time + _groundSpawnCooldown;
        }
    

    }
    public void SpawnNewEnemy()
    {
        int randomEnemy = Random.Range(0, enenmyPrefab.Length);
        int randomPos = Random.Range(0, spawnPos.Length);
        GameObject newEnemy = Instantiate(enenmyPrefab[randomEnemy], spawnPos[randomPos].transform.position, Quaternion.identity);
        _enemysAlive.Add(newEnemy);
    }
}
