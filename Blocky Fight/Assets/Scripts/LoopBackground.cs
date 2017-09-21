using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        MeshRenderer mRenderer = GetComponent<MeshRenderer>();

        Material mat = mRenderer.material;

        Vector3 offset = mat.mainTextureOffset;
        offset.x += 0.1f * Time.deltaTime;

        mat.mainTextureOffset = offset;
	}
}
