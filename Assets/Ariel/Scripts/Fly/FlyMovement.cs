using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float randRadius;
    public float radius;

    public float randSpeed;
    public float speed;

    public float idleTime;
    public float lifeTime;

    private float randAddProg;
    private float addProg;
    private float targetDelay;

    private Vector3 midPoint;
    private Vector3 randStartPos;
    private Vector3 randTarg;
    private Vector3 startPos;
    private Vector3 target;

    private float randProg = 0;
    private float progress = 0;
    private bool isIdle;
    private bool willLeave;

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
                targetDelay = idleTime;
            }

        }

        if (isIdle)
        {
            targetDelay -= Time.deltaTime;

            if (targetDelay < 0)
            {
                isIdle = false;
            }

        }

        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }

        else if (lifeTime <= 0 && !willLeave)
        {
            switch (Random.Range(0,8))
            {
                case 0:
                    target = new Vector3(this.transform.position.x, 1000, this.transform.position.z);
                    break;
                case 1:
                    target = new Vector3(this.transform.position.x, -1000, this.transform.position.z);
                    break;
                case 2:
                    target = new Vector3(1000, this.transform.position.y, this.transform.position.z);
                    break;
                case 3:
                    target = new Vector3(-1000, this.transform.position.y, this.transform.position.z);
                    break;
                case 4:
                    target = new Vector3(1000, 1000, this.transform.position.z);
                    break;
                case 5:
                    target = new Vector3(1000, -1000, this.transform.position.z);
                    break;
                case 6:
                    target = new Vector3(-1000, -1000, this.transform.position.z);
                    break;
                case 7:
                    target = new Vector3(-1000, 1000, this.transform.position.z);
                    break;
                default:
                    target = new Vector3(this.transform.position.x, 1000, this.transform.position.z);
                    break;
            }
            progress = 0.01f;
            willLeave = true;
            isIdle = false;
        }
    }

    private void OnDisable()
    {
        isIdle = true;
    }
}
