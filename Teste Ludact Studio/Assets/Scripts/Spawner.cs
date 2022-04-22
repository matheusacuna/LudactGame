using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public List<GameObject> PoolOfGameObjects;
    public GameObject[] objectToInsertIntoPool;
    public Transform[] spawners;

    public int amountOfObjects;
    private int timeCountFib = 1;
    private int countNaves;
    private int resultFib = 0;
    private int timeCountInt;

    private float timeCount;

    private bool isSpawned = false;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textCountFibonacci;


    private void Start()
    {
        CreatePool();
    }

    //Função responsável pelo spawn das naves na sequencia de Fibonacci
    private void Update()
    {
        timeCount += Time.deltaTime;
        timeCountInt = (int)timeCount;
        textCountFibonacci.text = timeCountInt.ToString();
        
        if (timeCount >= resultFib + 1)
        {
            SpawnNaves();
            
            if (isSpawned)
            {
                timeCountFib++;
                resultFib = fibCalc(timeCountFib);
            }
            timeCount = 0;
        }
    }

    //Função responsável por criar a pool de objetos na hierarquia e adicioná-los em uma lista
    private void CreatePool()
    {
        PoolOfGameObjects = new List<GameObject>();

        GameObject temporaryObject;

        for (int index = 0; index < this.amountOfObjects; index++)
        {
            temporaryObject = Instantiate(objectToInsertIntoPool[index]);
            temporaryObject.SetActive(false);
            PoolOfGameObjects.Add(temporaryObject);
        }
    }

    //Função responsável por verificar se as naves estão ativas em cenas.
    private GameObject GetObjectFromPool()
    {
        for (int index = 0; index < amountOfObjects; index++)
        {
            if (!PoolOfGameObjects[index].activeInHierarchy)
            {
                return PoolOfGameObjects[index];
            }
        }
        return null;
    }

    //Função responsável por instanciar as naves em cena caso estejam ativas
    private void SpawnNaves()
    {
        GameObject obj = GetObjectFromPool();        
        
        obj.transform.position = spawners[Random.Range(0, 3)].position;
        obj.SetActive(true);

        isSpawned = true;
        countNaves++;

        text.text = countNaves.ToString();

    }

    //Função responsável pelo cálculo da sequência Fibonacci
    private int fibCalc(int delay)
    {
        if (delay == 1)
        {
            return 0;
        }
        else
        {
            if (delay == 2)
            {
                return 1;
            }
            else
            {
                return fibCalc(delay - 1) + fibCalc(delay - 2);
            }
        }   
    }
}
