using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    SabreHandler vehicleHandler;
    MissionFileProcessor missionFileProcessor;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Starting MissionHandler!!!!!! How about that...");
        
        vehicleHandler = GetComponent<SabreHandler>();
        missionFileProcessor = GetComponent<MissionFileProcessor>();

        ExecuteMissionActions();
    }

    public void ExecuteMissionActions()
    {
        print(vehicleHandler);
        print(missionFileProcessor);
        List<string[]> missionActions = missionFileProcessor.ImportMissionPlan();

        foreach (string[] action in missionActions) {
            new WaitForSecondsRealtime(3);
            string actionType = action[0];
            string sensorOrPosition = action[1];
            string activeOrSpeed = action[2];            
            print("Found action: " + actionType + " " + sensorOrPosition + " " + activeOrSpeed);

            if (actionType.Equals("move")) {
                var xy = sensorOrPosition.Replace('(', ' ').Replace(')', ' ').Split('|');
                Vector3 position = new Vector3(Convert.ToInt32(xy[1])/7, 125, Convert.ToInt32(xy[0])/7);
                //Vector3 position = new Vector3(1000, 125, 1000);
                int speed = Convert.ToInt32(activeOrSpeed);
                vehicleHandler.MoveToPosition(position, speed);
            }
            else if (actionType.Equals("sensor")) {

            }
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
