using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    private Vector3 _spawnPoint = new Vector3(0f, -2.2f, 0f);
    private Vector3 _heroScale = new Vector3(2.2f, 2.2f, 2.2f);
    private Quaternion _heroRotation = new Quaternion(0, 180, 0, 0);

    [SerializeField] public Canvas CanvasLobbyScene;
    [SerializeField] public Slider HealthValue;
    [SerializeField] public Slider  AttackValue;
    [SerializeField] public Slider DefenceValue;
    [SerializeField] public Slider SpeedValue;
    [SerializeField] public TextMeshProUGUI NameOfCurrentHero;
    [SerializeField] public TextMeshProUGUI WeaponOfCurrentHero;
    [SerializeField] public TextMeshProUGUI PriseOCurrentfHero;
    [SerializeField] public TextMeshProUGUI GoldValue;
    [SerializeField] public TextMeshProUGUI GemesValue;
    [SerializeField] public TextMeshProUGUI ExperienceOfCurrentHero;
    [SerializeField] public TextMeshProUGUI LevelOfCurrentHero;
    [SerializeField] public GameObject BuyHeroButton;
    [SerializeField] public Button SelectHeroButton;
    
    

    private void Awake()
    {
        HeroesController.Instance.SetCurrentHeroOnScene(_spawnPoint, _heroScale, _heroRotation);
        SetStatsOfCurrentHero();
        SetRightValueOsButtonsSelectAndBuy();
        SetInformationOfCurrentHero();
    }

    private void SetStatsOfCurrentHero()
    {
        if (HeroesController.Instance.HeroesWithStats != null)
        {
            HealthValue.value = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Health;
            AttackValue.value = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Attack;
            DefenceValue.value = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Defence;
            SpeedValue.value = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Speed;
            NameOfCurrentHero.text = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Name;
            WeaponOfCurrentHero.text = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Weapon;
            PriseOCurrentfHero.text = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Price.ToString();
            GoldValue.text = PlayerController.Instance._gold.ToString();
            GemesValue.text = PlayerController.Instance._gems.ToString();
        }
        
    }
    public void SetNextHeroOnScene()
    {
        HeroesController.Instance.SetNextHeroOnScene(_spawnPoint, _heroScale, _heroRotation);
        SetStatsOfCurrentHero();
        SetRightValueOsButtonsSelectAndBuy();
        SetInformationOfCurrentHero();

    }
    public void SetPreviousHeroOnScene()
    {
        HeroesController.Instance.SetPreviousHeroOnScene(_spawnPoint, _heroScale, _heroRotation);
        SetStatsOfCurrentHero();
        SetRightValueOsButtonsSelectAndBuy();
        SetInformationOfCurrentHero();
    }

    public void BuyHero()
    {
        if (PlayerController.Instance.HaveEnoughGold(HeroesController.Instance
                .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Price))
        {
            PlayerController.Instance.SetNewGoldValue(HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Price);
            SetStatsOfCurrentHero();
            PlayerController.Instance.AddNewHero(HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Name);
            SetActiveBuyHeroButton(false);
            SetInteractableSelectHeroButton(true);
        }
    }

    private void SetActiveBuyHeroButton(bool trueOrFalse)
    {
        BuyHeroButton.SetActive(trueOrFalse);
    }

    private void SetInteractableSelectHeroButton(bool trueOrFalse)
    {
        SelectHeroButton.interactable = trueOrFalse;
    }

    private void SetRightValueOsButtonsSelectAndBuy()
    {
        if (!PlayerController.Instance.IsHeroInBoughtList(HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Name))
        {
            SetActiveBuyHeroButton(true);
            SetInteractableSelectHeroButton(false);
        }
        else
        {
            SetActiveBuyHeroButton(false);
            SetInteractableSelectHeroButton(true);
        }
    }

    private void SetInformationOfCurrentHero()
    {
        ExperienceOfCurrentHero.text = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].CurrentValueOfExperience + "/" + HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].MaxValueOfExperience;
        LevelOfCurrentHero.text = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Level.ToString();
    }
    
    public void SelectHero()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    
    
    
}