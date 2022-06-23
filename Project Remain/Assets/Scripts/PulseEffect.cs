
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PulseEffect : MonoBehaviour
{
   PostProcessVolume m_Volume;
   Vignette m_Vignette;
   void Start()
  {
      // Create an instance of a vignette
       m_Vignette = ScriptableObject.CreateInstance<Vignette>();
       m_Vignette.enabled.Override(true);
       //m_Vignette.intensity.Override(1f);
      // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
       m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
   void Update()
  {
       // Change vignette intensity using a sinus curve
        //m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        m_Vignette.intensity.Override(Mathf.Sin(Time.realtimeSinceStartup));
        

  }
   void OnDestroy()
  {
       RuntimeUtilities.DestroyVolume(m_Volume, true, true);
  }
}
}
