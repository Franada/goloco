using UnityEngine;
using UnityEditor;

class GoGoLocoLink : EditorWindow
{

    [MenuItem("Tools/GoGoLoco/Show Folder")]
    public static void ShowFolder()
    {
        Object asset = AssetDatabase.LoadAssetAtPath<Object>("Packages/gogoloco/Runtime/GoLoco/README!.txt");
        EditorGUIUtility.PingObject(asset);
    }
}
