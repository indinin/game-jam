using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawning : MonoBehaviour
{
    public GameObject flyObject;
    
    public int maxFlies = 10;
    private int currentFlies;

    public float maxSpawnInterval = 5f;
    public float minSpawnInterval = 1f;
    public float intervalLoss = 0.25f;

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
            currentFlies = GameObject.FindGameObjectsWithTag("Fly").Length;

            if (Random.Range(0,2) == 1 && currentFlies < maxFlies)
            {
                GameObject fly = Instantiate(flyObject,
                                             new Vector3(Random.Range(leftBorder, rightBorder),
                                                         Random.Range(bottomBorder, topBorder),
                                                         this.transform.position.z),
                                             new Quaternion(0, 0, 0, 0));

                fly.GetComponent<FlyMovement>().camera = FindObjectOfType<Camera>();
                currentFlies++;
                Debug.Log("Fly: Hallelujah!");
            }

            if (currentFlies == 1 && currentInterval > minSpawnInterval)
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
