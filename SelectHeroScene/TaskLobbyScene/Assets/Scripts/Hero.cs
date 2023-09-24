using UnityEngine;

public class Hero
{
    private GameObject _prefabOfHero;
    private float _experience { get; }

    public string Name { get; }
    public string Weapon { get; }
    public float Health { get; }
    public float Attack { get; }
    public float Defence { get; }
    public float Speed { get; }
    public float Price { get; }
    public float MaxValueOfExperience { get; }
    public float CurrentValueOfExperience { get; }
    public int Level { get; }
    

    public Hero(string name, float experience, string weapon, float health, float attack, float defence, float speed, GameObject prefabOfHero, float price, float currentValueOfExperience, int level)
    {

        Name = name;
        _experience = experience;
        Weapon = weapon;
        Health = health;
        Attack = attack;
        Defence = defence;
        Speed = speed;
        _prefabOfHero = prefabOfHero;
        Price = 3000;
        MaxValueOfExperience = 100;
        CurrentValueOfExperience = currentValueOfExperience;
        Level = level;
    }

}
