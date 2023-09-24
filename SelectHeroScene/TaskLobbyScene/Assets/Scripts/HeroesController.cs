using UnityEngine;
public class HeroesController : MonoBehaviour
{
    private readonly Vector3 _spawnPoint = new Vector3(0f, -0.92f, 80f);
    private readonly Vector3 _heroScale = new Vector3(2.2f, 2.2f, 2.2f);
    private readonly Quaternion _heroRotation = new Quaternion(0, 180, 0, 0);
    private static HeroesController _instance;
    
    public GameObject _currentHero;
    public int IndexOfCurrentHero = 1;
    public Hero[] HeroesWithStats;
    public string[] HeroesNames;
    public string[] HeroesWeapons;

    [SerializeField] public GameObject[] AllHeroes;
    [SerializeField] public Canvas CanvasSelectHeroScene;
    
    public static HeroesController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HeroesController>();
                
                if (_instance == null)
                {
                    var singleton = new GameObject(name: "HeroesController");
                    _instance = singleton.AddComponent<HeroesController>();
                }

                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeAllHeroes()
    {

        if (HeroesWithStats == null)
        {
            HeroesWithStats = new Hero[AllHeroes.Length];
            HeroesNames = new[]
                { "Bow02", "DoubleSword05", "MagicWand01", "NoWeapon01", "SwordShield03", "TwoHandsSword02" };
        
            HeroesWeapons = new[]
                { "Bow hero", "Dual sword hero", "Magic wand hero", "No weapon hero", "Sword and shield hero", "Two-handed sword hero" };
            for (int i = 0; i < HeroesWithStats.Length; i++)
            {
                var random = new System.Random();
            
                float health = (float)random.NextDouble();
                float attack = (float)random.NextDouble();
                float defence = (float)random.NextDouble();
                float speed = (float)random.NextDouble();
                int level = random.Next(1, 10);
                float currentValueOfExperience = random.Next(10, 100);

                HeroesWithStats[i] = new Hero(HeroesNames[i], 0, HeroesWeapons[i], health, attack, defence, speed, AllHeroes[i], 5000, currentValueOfExperience, level);
            }
        }
        
    }
  
    public void SetNextHeroOnScene(Vector3 spawnPoint, Vector3 scale, Quaternion rotation)
    {
        if (IndexOfCurrentHero +1  < AllHeroes.Length)
        {
            Destroy(_currentHero);
            _currentHero = Instantiate(AllHeroes[IndexOfCurrentHero +1]);
        
            _currentHero.transform.position = spawnPoint;
            _currentHero.transform.rotation = rotation;
            _currentHero.transform.localScale = scale;
            IndexOfCurrentHero++;
        }
    }
    public void SetPreviousHeroOnScene(Vector3 spawnPoint, Vector3 scale, Quaternion rotation)
    {
        if (IndexOfCurrentHero - 1 >= 0)
        {
            Destroy(_currentHero);
            _currentHero = Instantiate(AllHeroes[IndexOfCurrentHero - 1]);
        
            _currentHero.transform.position = spawnPoint;
            _currentHero.transform.rotation = rotation;
            _currentHero.transform.localScale = scale;
            IndexOfCurrentHero--;
        }
    }
    
    public void SetCurrentHeroOnScene(Vector3 spawnPoint, Vector3 scale, Quaternion rotation)
    {
        if (IndexOfCurrentHero >= 0)
        {
            _currentHero = Instantiate(AllHeroes[IndexOfCurrentHero]);
        
            _currentHero.transform.position = spawnPoint;
            _currentHero.transform.rotation = rotation;
            _currentHero.transform.localScale = scale;
        }
    }
    
    public void SetSelectedHeroOnLobbyScene()
    {
        _currentHero = Instantiate(AllHeroes[IndexOfCurrentHero]);

        _currentHero.transform.position = _spawnPoint;
        _currentHero.transform.rotation = _heroRotation;
        _currentHero.transform.localScale = _heroScale;

    }
    

}
