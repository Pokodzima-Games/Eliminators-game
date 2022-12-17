using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class DayNight : MonoBehaviour
{
    //  In the 2 fields below, only the materials that will be alternated in the day/night exchange are registered
    //  When adding your buildings(which will have their own materials), you can register the day and night versions of the materials here.
    //  The index of the daytime version of the material must match the index of the nighttime version of the material
    //  Example: When switching to night scene, materialDay[1] will be replaced by materialNight[1]
    //  (Materials that will be used both night and day do not need to be here)
    public Material[] materialDay;    // Add materials that are only used in the day scene, and are substituted in the night scene
    public Material[] materialNight;  // Add night scene materials that will replace day scene materials. (The sequence must be respected)
    
    private bool isNight;

    public void SetTimeOfADay(bool Night)
    {
        isNight = Night;
        ChangeMaterial();
    }

    public void ChangeMaterial()
    {

        /*
        Substituting Night materials for Day materials (or vice versa) in all Mesh Renders within City-Maker
        Only materials that have been added in "materialDay" and "materialNight" Array
        */

        GameObject GmObj = GameObject.Find("City-Maker"); ;

        if (GmObj == null) return;

        Renderer[] children = GmObj.GetComponentsInChildren<Renderer>();

        Material[] myMaterials;

        for (int i = 0; i < children.Length; i++)
        {
            myMaterials = children[i].GetComponent<Renderer>().sharedMaterials;

            for (int m = 0; m < myMaterials.Length; m++)
            {
                for (int mt = 0; mt < materialDay.Length; mt++)
                    if (isNight)
                    {
                        if (myMaterials[m] == materialDay[mt])
                            myMaterials[m] = materialNight[mt];

                    }
                    else
                    {
                        if (myMaterials[m] == materialNight[mt])
                            myMaterials[m] = materialDay[mt];
                    }


                children[i].GetComponent<MeshRenderer>().sharedMaterials = myMaterials;
            }


        }

        //Toggles street lamp lights on/off
        SetStreetLights();





    }
    
    public void SetStreetLights()  //Toggles street lamp lights on/off
    {
        GameObject[] tempArray = GameObject.FindObjectsOfType(typeof(GameObject)).Select(g => g as GameObject).Where(g => g.name == ("_LightV")).ToArray();
        foreach (GameObject lines in tempArray)
            lines.GetComponent<MeshRenderer>().enabled = isNight;
    }
}
