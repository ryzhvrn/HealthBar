using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player Player;

    [SerializeField] private Coroutine Coroutine;

    private void OnHealthChanged(float health)
    {
        if (Coroutine != null)
        {
            StopCoroutine(Coroutine);
            Coroutine = null;
        }

        Coroutine = StartCoroutine(Changing(health));
    }

    private IEnumerator Changing(float health)
    {
        while (Mathf.Abs(_slider.value - health) > .2f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, 0.1f);

            yield return null;
        }
    }

    private void OnEnable()
    {
        Player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= OnHealthChanged;
    }
}
