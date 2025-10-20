#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameEditor
{
    [CustomEditor(typeof(SceneTransitionTrigger))]
    public class SceneTransitionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SceneTransitionTrigger trigger = (SceneTransitionTrigger)target;
            
            EditorGUILayout.LabelField("Scene Transition Trigger", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            
            trigger.targetSceneName = EditorGUILayout.TextField("Target Scene Name", trigger.targetSceneName);
            
            trigger.transitionOnEnter = EditorGUILayout.Toggle("Transition On Enter", trigger.transitionOnEnter);
            
            trigger.showTransitionButton = EditorGUILayout.Toggle("Show Transition Button", trigger.showTransitionButton);
            
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("Make sure the target scene is added to Build Settings (File > Build Settings)", MessageType.Info);
            
            if (GUILayout.Button("Open Build Settings"))
            {
                EditorApplication.ExecuteMenuItem("File/Build Settings...");
            }
            
            if (GUI.changed)
            {
                EditorUtility.SetDirty(trigger);
            }
        }
    }
}
#endif