using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField] public Slider ExperienceOfCurrentHero;
    [SerializeField] public TextMeshProUGUI LevelOfCurrentHero;
    [SerializeField] public TextMeshProUGUI GoldValue;
    [SerializeField] public TextMeshProUGUI GemsValue;
    [SerializeField] public TextMeshProUGUI NameOfCurrentHero;
    [SerializeField] public TextMeshProUGUI Experience;
    

    private void Awake()
    {
        SetAllInformationAboutCurrentHero();
    }

    private void SetAllInformationAboutCurrentHero()
    {
        HeroesController.Instance.InitializeAllHeroes();
        HeroesController.Instance.SetSelectedHeroOnLobbyScene();
        GoldValue.text = PlayerController.Instance._gold.ToString();
        GemsValue.text = PlayerController.Instance._gems.ToString();
        NameOfCurrentHero.text = HeroesController.Instance.HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Name;
        ExperienceOfCurrentHero.maxValue = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].MaxValueOfExperience;
        ExperienceOfCurrentHero.value = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].CurrentValueOfExperience;
        LevelOfCurrentHero.text = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].Level.ToString();
        SetExperienceInSlider();
    }
    
    public void ChangeHero()
    {
        SceneManager.LoadScene("SelectHeroScene");
    }

    private void SetExperienceInSlider()
    {
        Experience.text = HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].CurrentValueOfExperience + "/" + HeroesController.Instance
            .HeroesWithStats[HeroesController.Instance.IndexOfCurrentHero].MaxValueOfExperience;
    }
}
