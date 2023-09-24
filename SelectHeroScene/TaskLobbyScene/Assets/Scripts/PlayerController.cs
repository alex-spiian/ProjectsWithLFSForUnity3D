using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _gold { get; private set; }
    public float _gems { get; private set; }
    
    private readonly List<string> _boughtHeroes = new List<string>();
    
    private static PlayerController _instance;
    
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
                
                if (_instance == null)
                {
                    var singleton = new GameObject("PlayerController");
                    _instance = singleton.AddComponent<PlayerController>();
                }

                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance);
                }
            }
            
            return _instance;
        }
    }

    private PlayerController()
    {
        _gold = 10000;
        _gems = 100;
    }

    private void Awake()
    {
        SetNewGoldValue();
        AddNewHero(HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Name);
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetNewGoldValue(float price = 0)
    {
        _gold -= price;
    }
    
    public void SetNewGemsValue(float price = 0)
    {
        _gems -= price;
    }

    public void AddNewHero(string heroName)
    {
        _boughtHeroes.Add(heroName);
    }

    public bool IsHeroInBoughtList(string heroName)
    {
        return _boughtHeroes.Contains(heroName);
    }

    public bool HaveEnoughGold(float price)
    {
        if (_gold >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool HaveEnoughGems(float price)
    {
        if (_gems >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
