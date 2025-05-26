using UnityEditor;
using UnityEngine;

namespace PUCPR.ColliderLimiter.Editor
{
    [CustomPropertyDrawer(typeof(EnumNamedArrayAttribute))]
    public class DrawerEnumNamedArray : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumNamedArrayAttribute enumNames = attribute as EnumNamedArrayAttribute;

            int index = System.Convert.ToInt32(
                property.propertyPath.Substring(
                    property.propertyPath.IndexOf("[")).Replace("[", "").Replace("]", ""));

            label.text = enumNames.names[index];

            EditorGUI.PropertyField(position, property, label, true);
        }
    }


    [CustomPropertyDrawer(typeof(LayerAttribute))]
    public class LayerAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }


}
