using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DailyCircleScript : MonoBehaviour
{
	[SerializeField] private Light2D globalLight;
    [SerializeField] private float dayDuration;
	[SerializeField] private float timeCoeff = 10.2f;
    private Coroutine _dayDuration;
	private float _timeDelta = 0;

    private void Start()
    {
        GameManager.instance.gameIsStart += StartDay;
        GameManager.instance.gameIsEnd += StopDay;
    }

    private void StartDay()
    {
        _dayDuration = StartCoroutine(StartedDay(dayDuration * 60f));
    }

    private void StopDay()
    {
        if (_dayDuration != null)
        {
            StopCoroutine(_dayDuration);
        }
    }

    IEnumerator StartedDay(float dayDuration)
    {
        while (true)
        {
			if (dayDuration < 0 ) break;
			
			_timeDelta += Time.deltaTime * timeCoeff / dayDuration;
			globalLight.color = new Color(globalLight.color.r - _timeDelta,
										globalLight.color.g - _timeDelta, globalLight.color.b);
            dayDuration--;
			Debug.Log("time " + dayDuration);
            yield return new WaitForSeconds(1f);
        }

    }
}
