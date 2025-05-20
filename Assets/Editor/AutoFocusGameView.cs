#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class AutoFocusGameView
{
    static AutoFocusGameView()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Delay sedikit supaya GameView sempat muncul dulu
            EditorApplication.delayCall += () =>
            {
                // Fokuskan ke Game View
                EditorApplication.ExecuteMenuItem("Window/General/Game");
            };
        }
    }
}
#endif
