﻿using Config;
using DG.Tweening;
using Game.CarSystem.Controllers;
using UnityEngine;

namespace Game.CarSystem.Base
{
    public class CarBase : MonoBehaviour
    {
        [SerializeField] 
        private Camera _carCamera;
        private Vector3 _cameraOffset;
        private CarController _carController;

        public void Initialize(Transform objeTransform)
        {
            _carCamera = _carCamera == null ? Camera.main : _carCamera;
            _cameraOffset = _carCamera.transform.position - transform.position;
            transform.position = objeTransform.position;
            transform.eulerAngles = objeTransform.eulerAngles;
            
            transform.DOShakeRotation(0.2f,Vector3.up * 5f).SetLoops(-1);

            _carController = GetComponent<CarController>();
            _carController.Initialize();
        }

        private void LateUpdate()
        {
            _carCamera.transform.position = transform.position + _cameraOffset;
        }


    }
}
