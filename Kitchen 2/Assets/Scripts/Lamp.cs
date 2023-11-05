using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light _light;

    private void Start()
    {
        // Получаем компонент свет
        _light = GetComponentInChildren<Light>();
    }

    public void Interact()
    {
        // Включаем или выключаем компонент света
        _light.enabled = !_light.enabled;
    }
}