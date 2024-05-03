using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace archero
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            transform.position = _target.position;

        }
    }
}
