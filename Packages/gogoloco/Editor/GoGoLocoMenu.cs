#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using VRC.SDK3.Avatars.Components;

public class GoGoLocoMenu : EditorWindow
{
    private GameObject avatarTarget;

    private GameObject gogolocoAllVRCFuryPrefab;
    private GameObject gogolocoBeyondVRCFuryPrefab;

    private string errorLabel = "";

    private Texture2D headerImage;

    /**
    *  Load the GoGoLoco Prefab Window
    */
    [MenuItem("Tools/GoGoLoco/Add Prefabs")]
    public static void ShowWindow()
    {
        GetWindow<GoGoLocoMenu>("GoGoLoco Prefabs");
    }

    /**
    *  Load the GoGoLoco ressources
    */
    private void OnEnable()
    {
        headerImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/gogoloco/Runtime/GoLoco/Icons/icon_Go_Loco.png");

        gogolocoAllVRCFuryPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/gogoloco/Runtime/GoLoco/GogoLoco All (VRCFury).prefab");
        gogolocoBeyondVRCFuryPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/gogoloco/Runtime/GoLoco/GogoLoco Beyond (VRCFury).prefab");

        avatarTarget = Selection.activeGameObject;
    }

    /**
    *  Flow of the GoGoLoco Prefab Window
    */
    private void OnGUI()
    {
        // GoGoLoco Logo
        GUILayout.Label(headerImage, GUILayout.ExpandWidth(true), GUILayout.MaxHeight(headerImage.height));

        // Help Box
        GUILayout.Label("Select your avatar in the hierarchy");
        // Avatar Selector 
        avatarTarget = EditorGUILayout.ObjectField(avatarTarget, typeof(GameObject), true) as GameObject;

        if (avatarTarget == null)
        {
            errorLabel = "Error: No object selected in the Hierarchy.";
            GUI.color = Color.red;
            GUILayout.Label(errorLabel);
            GUI.color = Color.white;
        }
        else if (avatarTarget.GetComponent<VRCAvatarDescriptor>() == null)
        {
            errorLabel = "Error: Selected object isn't an avatar (Doesn't have an AvatarDescriptor Component).";
            GUI.color = Color.red;
            GUILayout.Label(errorLabel);
            GUI.color = Color.white;
        }
        else
        {
            errorLabel = "";
        }

        // Disable buttons if wrong avatar selected
        GUI.enabled = errorLabel == "";
        
        if (GUILayout.Button("Add GoGoLoco All (VRCFury) Prefab"))
        {
            GameObject instantiatedPrefab = PrefabUtility.InstantiatePrefab(gogolocoAllVRCFuryPrefab) as GameObject;
            instantiatedPrefab.transform.SetParent(avatarTarget.transform);
        }
        if (GUILayout.Button("Add GoGoLoco Beyond (VRCFury) Prefab"))
        {
            GameObject instantiatedPrefab = PrefabUtility.InstantiatePrefab(gogolocoBeyondVRCFuryPrefab) as GameObject;
            instantiatedPrefab.transform.SetParent(avatarTarget.transform);
        }
        GUI.enabled = true;
    }
}

#endif