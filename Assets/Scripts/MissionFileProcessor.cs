using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class MissionFileProcessor : MonoBehaviour
{

    public List<string[]> ImportMissionPlan()
    {
        List<string[]> lines = ReadMissionPlanCSV();
        ConvertMissionCSVLinesToActions(lines);

        return lines;
    }

    public List<string[]> ConvertMissionCSVLinesToActions(List<string[]> lines)
    {
        return lines;
    }

    public List<string[]> ReadMissionPlanCSV()
    {
        var lines = new List<string[]>();

        var path = @"grid_mission_plan.csv";
        StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line.Split(','));
            }
        }

        reader.Close();

        return lines;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
