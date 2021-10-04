using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public Slider coolingSlider;
    public Slider powerSlider;
    public Slider temperatureSlider;

   // public FixPanel[] fixPanels;

    public float breakChance = 0.1f;

    // Update is called once per frame
    void Update()
    {
    //    UpdatePanels();
    }

//     void UpdatePanels() {
//         foreach(FixPanel panel in fixPanels) {
//             bool allScrewsOut = true;

//             foreach(Screw screw in panel.screws) {
//                 if(screw.screwedIn) {
//                     allScrewsOut = false;
//                     screw.screwLevel += Random.Range(-0.1f,0.1f) * breakChance;
//                     if(screw.screwLevel < 0.1f) {
//                         //Shoot out screw
//                     }
//                 }
//             }
//         }
//     }
// }

// public class FixPanel  {
//     public GameObject panelGO;
//     public Screw[] screws;

//     public FixPanel(GameObject panelGO, Screw[] screws) {
//         this.panelGO = panelGO;
//         this.screws = screws;
//     }
}
