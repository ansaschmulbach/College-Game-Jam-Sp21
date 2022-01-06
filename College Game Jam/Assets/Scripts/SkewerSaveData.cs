using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkewerSaveData
{
    [System.Serializable]
    public class DangoSaveData
    {
        [System.Serializable]
        public class ToppingsSaveData
        {
            public bool enabled;

            public ToppingsSaveData(bool enabled)
            {
                this.enabled = enabled;
            }
            
        }

        public ToppingsSaveData sprinkles;
        public ToppingsSaveData marshmallows;
        public float[] position;
        public float[] rotation;
        public float[] localScale;
        public string name;
        public bool condensed;

        public DangoSaveData(FoodController fc)
        {
            position = new float[3];
            rotation = new float[3];
            localScale = new float[3];
            
            for (int i = 0; i < 3; i++)
            {
                position[i] = fc.gameObject.transform.localPosition[i];
                rotation[i] = fc.gameObject.transform.localRotation.eulerAngles[i];
                localScale[i] = fc.gameObject.transform.localScale[i];
            }
            sprinkles = new ToppingsSaveData(fc.hasSprinkles);
            marshmallows = new ToppingsSaveData(fc.hasMarshmallows);
            name = fc.gameObject.name.Replace("(Clone)","").Trim();
            condensed = fc.isCondensed;
        }

    }

    public DangoSaveData[] dangos;

    public SkewerSaveData(SkewerController sc)
    {
        dangos = new DangoSaveData[sc.skeweredItems.Count];
        for (int i = 0; i < sc.skeweredItems.Count; i++)
        {
            dangos[i] = new DangoSaveData(sc.skeweredItems[i].GetComponent<FoodController>());
        }
    }

}
