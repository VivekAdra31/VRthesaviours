using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Lex4art at 29 Mar 2018.
//This script does this: then attached to a mesh with Light Probes Proxy Volume component it will allow only one update (on map start) of 
//those Light Probes Proxy Volumes and this will save A LOT of CPU performance for maps were lighting will not change much.
//ATTENTION! This script will automatically switch Light Probe Proxy Volume component to the "ON" state. Also, it will switch MeshRenderer 
//option "Light Probes" to the "Use Proxy Volume". 
//To work this script must be attached to every model (and every LOD of this model) that has a Light Probes Proxy Volume component.

public class LPPV_lighting_update_only_once : MonoBehaviour {
	void Start () {
		//Checking if there is a Light Probe Proxy Volume component at all. If nothing found - put a warning message to the console.
		if (this.GetComponent<LightProbeProxyVolume> () == false) {
			print ("There is no 'Light Probe Proxy Volume' component on the object" + this.name);
		} else {
            //Force "Use Proxy Volume" mode in Mesh Renderer/Skinned Mesh Renderer "Light Probes" property. For same reasons as above - for editing map in Scene view it's better keep MeshRender property "Light Probes" as a "Blend Probes" and switch only in "Play" mode.
            if (this.GetComponent<MeshRenderer>() != false || this.GetComponent<SkinnedMeshRenderer>() != false)
            {
                if (this.GetComponent<SkinnedMeshRenderer>() == true) this.GetComponent<SkinnedMeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.UseProxyVolume;
                if (this.GetComponent<MeshRenderer>() == true) { this.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.UseProxyVolume; }

                //Put Light Probe Proxy Volume component to the "ON" state. It's not necessary, but I prefer to keep all of them in "OFF" state because of poor Edit mode performance and enable them via this script only in a "Play" mode.
                this.GetComponent<LightProbeProxyVolume>().enabled = true;

                //Perform Light Probe Proxy Volumes update once on this mesh at map start.
                this.GetComponent<LightProbeProxyVolume>().Update();
            }
            else
            {
                print("There is no 'Mesh Renderer or Skinned Mesh Renderer' component on the object" + this.name);
            }
        }
	}
}
