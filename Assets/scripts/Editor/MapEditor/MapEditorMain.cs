﻿using System;
using UnityEditor;
using UnityEngine;

namespace MapEditor {

    public class Main: Editor {

        public static bool EnableEdit { get; set; }
        private static GameObject mappingReference;

        public static void OnSceneGUI(SceneView sceneView) {
            if(EnableEdit) {
                PreviewObject.SetActive(true);
                PreviewObject.Update(sceneView);
                InputControl.ReactInput(sceneView);

                UnselectMapReference();
            }else {
                PreviewObject.SetActive(false);
            }
        }

        private static void UnselectMapReference() {
            if(!mappingReference) {
                mappingReference = GameObject.FindGameObjectWithTag("MapEditor").transform.FindChild("Mapping_Reference").gameObject;
            }

            if(mappingReference) {
                if(Selection.Contains(mappingReference)) {
                    Selection.objects = Array.FindAll(Selection.objects, o => (o != mappingReference));
                }
            }
        }
    }
}