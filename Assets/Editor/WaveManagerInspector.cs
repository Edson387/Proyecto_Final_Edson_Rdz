using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaveManager))]
public class WaveManagerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        WaveManager wm = (WaveManager)target;

        // Dibuja todas las variables normales primero
        DrawDefaultInspector();

        // Enum para modo de control (Automatico / Manual)
        wm.modoControl = (WaveManager.ModoControl)EditorGUILayout.EnumPopup("Modo de Control", wm.modoControl);

        // Si está en manual, mostramos un botón para iniciar oleada
        if (wm.modoControl == WaveManager.ModoControl.Manual)
        {
            if (GUILayout.Button("Iniciar Oleada"))
            {
                wm.IniciarOleadaManual();
            }
        }
    }
}
