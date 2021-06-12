using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawning : MonoBehaviour
{
    public GameObject warningLabel;

    public float minInterval = 10f;
    public float maxInterval = 180f;

    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;

    [SerializeField]
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = maxInterval;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            countdown = Random.Range(minInterval, maxInterval);

            GameObject warning = Instantiate(warningLabel,
                                             new Vector3(Random.Range(leftBorder, rightBorder),
                                                         Random.Range(bottomBorder, topBorder),
                                                         this.transform.position.z),
                                             new Quaternion(0, 0, 0, 0));
        }
    }
}
