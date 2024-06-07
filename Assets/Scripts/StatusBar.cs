using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateBar(float currentValue, float maxValue)
    {
        var result = currentValue / maxValue;
        slider.value = result;
    }
}
