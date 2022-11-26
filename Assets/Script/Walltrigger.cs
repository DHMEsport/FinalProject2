using System;
using System.Collections.Generic;
using UnityEngine;

    public class Walltrigger : MonoBehaviour
    {
        public GameObject Roof = null;

        void OnTriggerEnter(Collider col)

        {
            if (col.CompareTag("Player"))

            {
                SetMaterialTransparent();

                iTween.FadeTo(Roof, 0, 1);
            }
        }

        private bool IsCharacter(Collider collider)

        {
            return true;
        }

        private void SetMaterialTransparent()

        {
            foreach (Material m in Roof.GetComponent<Renderer>().materials)

            {
                m.SetFloat("_Mode", 2);

                m.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);

                m.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

                m.SetInt("_ZWrite", 0);

                m.DisableKeyword("_ALPHATEST_ON");

                m.EnableKeyword("_ALPHABLEND_ON");

                m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                m.renderQueue = 3000;
                Debug.Log("SetMaterial Transparent");
            }
        }

        private void SetMaterialOpaque()

        {
            foreach (Material m in Roof.GetComponent<Renderer>().materials)

            {
                m.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);

                m.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);

                m.SetInt("_ZWrite", 1);

                m.DisableKeyword("_ALPHATEST_ON");

                m.DisableKeyword("_ALPHABLEND_ON");

                m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                m.renderQueue = -1;
                Debug.Log("seting material");
            }
        }

        void OnTriggerExit(Collider collider)

        {
            if (IsCharacter(collider))

            {
                // Set material to opaque

                iTween.FadeTo(Roof, 1, 1);

                Debug.Log("on trigger exit");
                Invoke("SetMaterialOpaque", 1.0f);
            }
        }
    }