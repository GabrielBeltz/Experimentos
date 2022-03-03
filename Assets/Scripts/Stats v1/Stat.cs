using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public string name;
    public float modValue;
    public float totalValue
    {
        get
        {
            float totalmultipliers = 1;

            foreach (var mult in Multipliers)
            {
                totalmultipliers *= mult.value;
            }

            totalmultipliers = Mathf.Clamp(totalmultipliers, 0f, 2f);

            return (1 + modValue ) * totalmultipliers;
        }
    }

    public float MultiplierCap = 2;

    // Em uma versão futura dá pra criar uma classe de "bônus" ao invés de multiplicador, e essa classe ter um enum q decide
    // se esse bônus é multiplicativo ou aditivo, com o valor do modificador e um nome pra identificar.
    // Com uma classe única pros bônus fica mais fácil a implementação de um menu de efeitos como skyrim.
    // Classe "Bonus" teria: Type(enum), name(string), description(string), totalValue(readonly float)
    [SerializeField] List<StatMultiplier> Multipliers;

    public Stat (string _name, float _modValue)
    {
        name = _name;
        modValue = _modValue;
        Multipliers = new List<StatMultiplier>();
    }

    public void AddMultiplier(string _name, float _value) => Multipliers.Add(new StatMultiplier(_name, _value));

    public void RemoveMultiplier(string name) => Multipliers.Remove(Multipliers.Find(mult => mult.name == name));

    [System.Serializable]
    public class StatMultiplier
    {
        public string name;
        public float value;

        public StatMultiplier(string _name, float _value)
        {
            name = _name;
            value = _value;
        }
    }
}

