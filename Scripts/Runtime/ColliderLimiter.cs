using System;
using System.Collections.Generic;
using UnityEngine;

namespace PUCPR.ColliderLimiter
{
    public class ColliderLimiter : MonoBehaviour
    {
        const float _min = .1f;
        private static int s_collidersSize = Enum.GetNames(typeof(CubeSides)).Length;

        [Space(10)]
        [SerializeField, Min(_min)] private Vector3 _area = Vector3.one;

        [Header("Colliders")]
        [SerializeField, Layer] private int _collidersLayer;
        [SerializeField, Min(_min)] private float _colliderThickness;
        [SerializeField, EnumNamedArray(typeof(CubeSides))] private bool[] _colliders = new bool[s_collidersSize];

        [Space(10)]
        [SerializeField] private bool debugColliders;
        [SerializeField] private bool solidDebugers;

        private float _overlapColThic() => _colliderThickness * 2;

        #region Monobehaviour
        private void OnValidate()
        {
            if (_colliders.Length != s_collidersSize)
                Array.Resize(ref _colliders, s_collidersSize);


            if (_area.y < _min) _area.y = _min;
            if (_area.x < _min) _area.x = _min;
            if (_area.z < _min) _area.z = _min;
            if (_colliderThickness < _min) _colliderThickness = _min;
        }

        private void Start()
        {
            InstantiateColliders();
        }

        #endregion

        #region Gizmos
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            DrawForwardArrow();

            Gizmos.matrix = NormalizeMatrixRotation();

            DrawLimitArea();

            if (debugColliders)
                DrawDebugColliders();
        }

        private Matrix4x4 NormalizeMatrixRotation() =>
            Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

        private void DrawForwardArrow()
        {
            Vector3 forward = transform.forward * 2;
            float arrowHeadAngle = 20.0f;
            float arrowHeadLength = 0.25f;

            Vector3 right = Quaternion.LookRotation(forward) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(forward) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);

            Gizmos.color = Color.white;
            Gizmos.DrawRay(transform.position, forward);
            Gizmos.DrawRay(transform.position + forward, right * arrowHeadLength);
            Gizmos.DrawRay(transform.position + forward, left * arrowHeadLength);

        }

        private void DrawLimitArea()
        {
            Gizmos.color = Color.blue;
            var area = CalculatedArea();

            Gizmos.DrawWireCube(area.pos, area.size);
        }

        private void DrawDebugColliders()
        {
            Gizmos.color = Color.green;

            var activedColliders = ActivedColliders();

            foreach (var aCol in activedColliders)
            {
                if (solidDebugers)
                    Gizmos.DrawCube(aCol.pos, aCol.size);
                else
                    Gizmos.DrawWireCube(aCol.pos, aCol.size);
            }
        }
#endif
        #endregion


        #region CalculatedValues
        private (Vector3 pos, Vector3 size) CalculatedArea()
        {
            return (CenterAreaPosition(), new Vector3(_area.x, _area.y, _area.z));
        }

        private Vector3 CenterAreaPosition()
        {
            return new Vector3(0, (_area.y / 2), 0);
        }

        private float ColliderPivotPosition(float axisRef)
        {
            return (axisRef > 0 ? (axisRef + _colliderThickness) : (axisRef - _colliderThickness)) / 2;
        }

        private (Vector3 pos, Vector3 size) CalculatedColliderArea(CubeSides side)
        {
            switch (side)
            {
                case CubeSides.top:
                    return (CenterAreaPosition() + new Vector3(0, ColliderPivotPosition(_area.y), 0),
                        new Vector3(_area.x + _overlapColThic(), _colliderThickness, _area.z + _overlapColThic()));

                case CubeSides.bottom:
                    return (CenterAreaPosition() + new Vector3(0, ColliderPivotPosition(-_area.y), 0),
                        new Vector3(_area.x + _overlapColThic(), _colliderThickness, _area.z + _overlapColThic()));

                case CubeSides.left:
                    return (CenterAreaPosition() + new Vector3(ColliderPivotPosition(-_area.x), 0, 0),
                        new Vector3(_colliderThickness, _area.y + _overlapColThic(), _area.z + _overlapColThic()));

                case CubeSides.right:
                    return (CenterAreaPosition() + new Vector3(ColliderPivotPosition(_area.x), 0, 0),
                        new Vector3(_colliderThickness, _area.y + _overlapColThic(), _area.z + _overlapColThic()));

                case CubeSides.front:
                    return (CenterAreaPosition() + new Vector3(0, 0, ColliderPivotPosition(_area.z)),
                        new Vector3(_area.x + _overlapColThic(), _area.y + _overlapColThic(), _colliderThickness));

                case CubeSides.back:
                    return (CenterAreaPosition() + new Vector3(0, 0, ColliderPivotPosition(-_area.z)),
                        new Vector3(_area.x + _overlapColThic(), _area.y + _overlapColThic(), _colliderThickness));

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        private void InstantiateColliders()
        {
            var activedColliders = ActivedColliders();
            Debug.Log("init = instantiate");

            foreach (var activedColliderReference in activedColliders)
            {
                Debug.Log("instantiate");
                GameObject colliderObject = new GameObject("Collider", typeof(BoxCollider));

                colliderObject.transform.SetParent(transform);
                colliderObject.layer = _collidersLayer;

                colliderObject.transform.localPosition = activedColliderReference.pos;
                colliderObject.transform.localScale = activedColliderReference.size;

            }

        }

        private (Vector3 pos, Vector3 size)[] ActivedColliders()
        {
            List<(Vector3, Vector3)> activeColliders = new List<(Vector3, Vector3)>();

            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i])
                    activeColliders.Add(CalculatedColliderArea((CubeSides)i));
            }

            return activeColliders.ToArray();
        }
    }

}
