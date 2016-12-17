//-----------------------------------------------------------
// GradientSkyboxEditor CREATED BY "GhaziXX"
//-----------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(GradiantSkybox))]
public class GradientSkyboxEditor : Editor {
 
    

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GradiantSkybox gradient = target as GradiantSkybox;
        gradient.topAndBottom = GUILayout.Toggle(gradient.topAndBottom, " Enable top and bottom");

        if(gradient.topAndBottom)
        {
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.ExpandHeight(true);
            GUILayout.Label("Bottom Duration", GUILayout.Width(130));
            gradient.bottomDuration = EditorGUILayout.FloatField(gradient.bottomDuration);
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.ExpandHeight(true);
            GUILayout.Label("Bottom Color Animation Curve", GUILayout.Width(130));
            gradient.bottomColorAnimationCurve = EditorGUILayout.CurveField(gradient.bottomColorAnimationCurve);
            GUILayout.EndHorizontal();

        }
    }
}
