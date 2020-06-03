using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //REAL
    [SerializeField]
    private Image foreGroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().healthPctChanged += HealthChange;
    }
    private void HealthChange(float percent)
    {
        //foreGroundImage.fillAmount = percent;
       StartCoroutine(ChangeToPercent(percent));
    }
    private IEnumerator ChangeToPercent(float percent)
    {
        float tempChangePercent = foreGroundImage.fillAmount;
        float tempTime = 0f;

        while (tempTime < updateSpeedSeconds)
        {
            tempTime += Time.deltaTime;
            foreGroundImage.fillAmount = Mathf.Lerp(tempChangePercent, percent, tempTime / updateSpeedSeconds);
            yield return null;
        }
        foreGroundImage.fillAmount = percent;
    }
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
