using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAndPointsController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText, pointsText;
    private int timer, points;
    private GameObject spider;
    private SpiderPoints spiderPoints;
    private Timer timerObj;

    void Awake()
    {
        spider = GameObject.FindGameObjectWithTag("Player");
        if(spider.GetComponent<SpiderPoints>())
        {
            spiderPoints = spider.GetComponent<SpiderPoints>();
        }
        if(this.gameObject.GetComponent<Timer>())
        {
            timerObj = this.gameObject.GetComponent<Timer>();
        }
    }

    void Update()
    {
        points = spiderPoints.getPoints();
        timer = timerObj.getTime();
        timeText.text = "Time: " + timer;
        pointsText.text = "Points: " + points;
    }
}
