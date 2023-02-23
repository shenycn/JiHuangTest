using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//特性：自定义的地图编译器
[CustomEditor(typeof( Myworld))]
public class MyworldEditor : Editor
{
 public override void OnInspectorGUI()
 {
     
   base.OnInspectorGUI();
   if (GUILayout.Button("生成"))
   {
       (( Myworld)target).GenerateMap();//强制转换成地图生成
   }

 }
}
