using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareController : MonoBehaviour
{
    private Vector3 _currentPosition = new Vector3(0, 0, 19);
    private GameObject _currentSquare;
    private readonly GameObject[] _allSquares = new GameObject[400];
    [SerializeField] public float IntervalOfSquaresSpawning;
    [SerializeField] public float IntervalOfChangingColor;
    [SerializeField] public float DurationTimeOfChangingColor;
    [SerializeField] public GameObject SquarePrefab;

    private void Awake()
    {
        StartCoroutine(SpawnSquares());
    }

    private IEnumerator SpawnSquares()
    {
        // x++ добавление куба вправо.
        // z-- переход на след строку.
        
        var index = 0;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                yield return new WaitForSeconds(IntervalOfSquaresSpawning);

                _currentSquare = Instantiate(SquarePrefab);
                _allSquares[index] = _currentSquare;
                _currentSquare.transform.position = _currentPosition;
                _currentPosition.x++;
                index++;
            }

            _currentPosition.x = 0;
            _currentPosition.z--;
        }
    }

    public void StartCoroutineToChangeColor()
    {
        StartCoroutine(ChangeColor());
    }

    public IEnumerator ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);        

        for (int i = 0; i < _allSquares.Length; i++)
        {
            var renderer = _allSquares[i].GetComponent<Renderer>();

            StartCoroutine(ChangeColorSmoothly(renderer,renderer.material.color, randomColor));
            yield return new WaitForSeconds(IntervalOfChangingColor);
        }
    }
    
    private IEnumerator ChangeColorSmoothly(Renderer renderer,Color startColor, Color targetColor)
    {
        float currentTime = 0f;
        while (currentTime < DurationTimeOfChangingColor)
        {
            float t = currentTime / DurationTimeOfChangingColor;
            renderer.material.color = Color.Lerp(startColor, targetColor, t);
            currentTime += Time.deltaTime;
            yield return null;
        }

        renderer.material.color = targetColor;
    }
}






