using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseMaker))]
public class NoiseMakerInspector : Editor {

	private NoiseMaker noiseMaker;

	private void OnEnable () {
		noiseMaker = target as NoiseMaker;
		Undo.undoRedoPerformed += RefreshCreator;
	}

	private void OnDisable () {
		Undo.undoRedoPerformed -= RefreshCreator;
	}

	private void RefreshCreator () {
			noiseMaker.onChange.Invoke();
	}

	public override void OnInspectorGUI () {
		EditorGUI.BeginChangeCheck();
		DrawDefaultInspector();
		if (EditorGUI.EndChangeCheck()) {
			RefreshCreator();
		}
	}
}