using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetMovement : MonoBehaviour
{
    public Camera camera;
    public float randRadius;
    public float radius;

    public float randSpeed;
    public float speed;

    public float idleTime;

    private float randAddProg;
    private float addProg;
    private float countDown;

    private Vector3 midPoint;
    private Vector3 randStartPos;
    private Vector3 randTarg;
    private Vector3 startPos;
    private Vector3 target;

    private float randProg = 0;
    private float progress = 0;
    private bool isIdle;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        midPoint = this.transform.position;

        randProg = 0;
        //randTarg = new Vector3(midPoint.x + Random.value * randRadius, midPoint.y + Random.value * randRadius, midPoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (randProg < 1)
        {
            if (randProg == 0)
            {
                randStartPos = this.transform.position;

                randTarg = new Vector3(midPoint.x + Random.Range(-1.0f, 1.0f) * randRadius,
                                       midPoint.y + Random.Range(-1.0f, 1.0f) * randRadius,
                                       midPoint.z);

                randAddProg = randSpeed / Vector3.Distance(randStartPos, randTarg) * Time.deltaTime;

            }

            randProg += randAddProg;
            this.transform.position = Vector3.Lerp(randStartPos, randTarg, randProg);
        }

        else if (randProg > 1)
        {
            randProg = 0;
        }

        //_____________________________________________________________________________________________________________________________
        if (!isIdle)
        {
            if (progress < 1)
            {
                if (progress == 0)
                {
                    startPos = midPoint;

                    target = new Vector3(midPoint.x + Random.Range(-1.0f, 1.0f) * radius,
                                         midPoint.y + Random.Range(-1.0f, 1.0f) * radius,
                                         midPoint.z);

                    addProg = speed / Vector3.Distance(startPos, target) * Time.deltaTime;
                }

                progress += addProg;
                midPoint = Vector3.Lerp(startPos, target, progress);
            }

            else if (progress > 1)
            {
                progress = 0;

                isIdle = true;
                countDown = idleTime;
            }
        }

        if (isIdle)
        {
            countDown -= Time.deltaTime;

            if (countDown < 0)
            {
                isIdle = false;
            }
        }
    }

    private void OnDisable()
    {
        isIdle = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Hornet: Oof!");
        Destroy(this.gameObject);
    }
}
