using System;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
        
        
        
        public float lookSenitivity = 5;
        public float lookSmoothDamp = 0.1f;
        public float xRotation;
        public float yRotation;
        public float xRotationV;
        public float yRotationV;
        public float currentXRotation;
        public float currentYRotation;
        [HideInInspector]
        public float lStickHorizontal;
        [HideInInspector]
        public float lStickVertical;
        public float lStickV;
        public float lStickH;
        
        float horizontalSpeed = 2.0f;
        float verticalSpeed = 2.0f;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }


        public void LookRotation(Transform character, Transform camera)
        {
            //Option 1
            float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
            
            //Option 2
            /*lStickHorizontal = Input.GetAxis("Mouse X");
            lStickVertical = Input.GetAxis("Mouse Y");

            lStickH = lStickHorizontal;
            lStickV = lStickVertical;

            xRotation += Input.GetAxis("Mouse Y") * lookSenitivity;
            yRotation += Input.GetAxis("Mouse X") * lookSenitivity;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
            currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

            camera.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

            camera.position = camera.position;*/
            
        }
        


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
