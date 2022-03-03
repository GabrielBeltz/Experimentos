using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    public List<Stat> Stats;

    private void Start() {
        Stats.Add(new Stat("Strength", 1f));
        Stats.Add(new Stat("Agility", 0f));
        Stats.Add(new Stat("Inteligence", 3f));
        Stats.Add(new Stat("Wisdom", 4f));
        Stats.Add(new Stat("Personality", 4f));
        Stats.Add(new Stat("Luck", 6f));

        DebugAllStats();
    }

    [ContextMenu("Debug All Stats")]
    public void DebugAllStats()
    {
        string debug = $"Stats: {System.Environment.NewLine}";
        
        foreach (var stat in Stats)
        {
            debug += $"{stat.name}: {GetStatValue(stat.name)} {System.Environment.NewLine}";
        }
        
        Debug.Log(debug);
    }

    public Stat GetStat(string statName) => Stats.Find(stat => stat.name == statName);

    public float GetStatValue(string statName) => Stats.Find(stat => stat.name == statName).totalValue;

    public void SetStat(string statName, float newValue) => Stats.Find(stat => stat.name == statName).modValue = newValue;

    public void AddStat(string statName, float value) => Stats.Find(stat => stat.name == statName).modValue += value;
}
