//-----------------------------------------------------------
// GradiantSkybox CREATED BY "GhaziXX"
//-----------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GradiantSkybox : MonoBehaviour
{
    
    public Material spaceMaterial;
    [Space(10)]
    public float topDuration;
    public AnimationCurve topColorAnimationCurve;

    [HideInInspector]
    public float bottomDuration;
    [HideInInspector]
    public AnimationCurve bottomColorAnimationCurve;
  
    private float topCounter;
    private float topCurrentLerpTime;
    private float bottomCounter;
    private float bottomCurrentLerpTime;

    private Color topOriginalColor;
    private Color topDesiredColor;
    private Color bottomOriginalColor;
    private Color bottomDesiredColor;

    [HideInInspector]
    public bool topAndBottom;

    private void Update()
    {
        if (topAndBottom)
        {
            topColor();
            bottomColor();
        }
        else
        {
            topColor();
        }

    }
    private void topColor()
    {
        topCurrentLerpTime += Time.deltaTime;

        if (topCurrentLerpTime > topDuration)
            topCurrentLerpTime = 0;

        float t = topCurrentLerpTime / topDuration;

        if (topCounter <= Time.time)
        {
            topOriginalColor = GetOriginalColor(true);
            topDesiredColor = GetRandomColor();
            topCounter = topDuration + Time.time;
        }

        Color realtimeColor = Color.Lerp(topOriginalColor, topDesiredColor, topColorAnimationCurve.Evaluate(t));
        spaceMaterial.SetColor(Shader.PropertyToID("_Color2"), realtimeColor);
    }
    private void bottomColor()
    {
        bottomCurrentLerpTime += Time.deltaTime;

        if (bottomCurrentLerpTime > bottomDuration)
            bottomCurrentLerpTime = 0;

        float t = bottomCurrentLerpTime / bottomDuration;

        if (bottomCounter <= Time.time)
        {
            bottomOriginalColor = GetOriginalColor(false);
            bottomDesiredColor = GetRandomColor();
            bottomCounter = bottomDuration + Time.time;
        }

        Color realtimeColor = Color.Lerp(bottomOriginalColor, bottomDesiredColor, bottomColorAnimationCurve.Evaluate(t));
        spaceMaterial.SetColor(Shader.PropertyToID("_Color1"), realtimeColor);
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F)); ;
        return color;
    }
    private Color GetOriginalColor(bool isTop)
    {
        if(isTop)
        {
            Color _originalColor = spaceMaterial.GetColor(Shader.PropertyToID("_Color2"));
            return _originalColor;
        }
        else
        {
            Color _originalColor = spaceMaterial.GetColor(Shader.PropertyToID("_Color1"));
            return _originalColor;
        }
        
    }
    
}
