using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetSpawner : MonoBehaviour
{
    public GameObject hornetObject;

    public int maxHornets = 10;
    private int currentHornets;

    public float maxSpawnInterval = 60f;
    public float minSpawnInterval = 30f;
    public float intervalLoss = 1f;

    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;

    private float currentInterval;
    [SerializeField]
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentInterval = maxSpawnInterval;
        countdown = currentInterval;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            currentHornets = GameObject.FindGameObjectsWithTag("Hornet").Length;

            if (currentHornets < maxHornets)
            {
                GameObject hornet = Instantiate(hornetObject,
                                    new Vector3(Random.Range(leftBorder, rightBorder),
                                                Random.Range(bottomBorder, topBorder),
                                                this.transform.position.z),
                                   new Quaternion(0, 0, 0, 0));

                currentHornets++;
                Debug.Log("Hornet: Hallelujah!");
            }

            if (currentHornets == 1 && currentInterval > minSpawnInterval)
            {
                currentInterval -= intervalLoss;

                if (currentInterval < intervalLoss)
                {
                    currentInterval = intervalLoss;
                }
            }

            countdown = currentInterval;
        }

    }
}
