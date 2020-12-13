using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMaterial : MonoBehaviour
{
    public float updatetime;
    private int frame;
    //Here you'll put in every frame you want to load
    public Texture[] sprites;
    private Renderer mat;

    void Start()
    {
        //Get the material
        mat = GetComponent<Renderer>();
        StartCoroutine(UpdateFrame());
    }

    private void Update()
    {
        //If the frame counter reached the end of the sprites array, it stops there
        if (frame >= sprites.Length - 1)
        {
            frame = sprites.Length - 1;
        }
        //To prevent the counter go negative 0
        else if (frame <= 0)
        {
            frame = 0;
        }
    }
    
    IEnumerator UpdateFrame()
    {
        while(frame <= sprites.Length - 1)
        {
            //(for example) "updatetime / 10" could also be "10 / 10"
            //If you want to update it 1 frame every second, you have to type "10" in the updatetime
            yield return new WaitForSeconds(updatetime / 10);
            //Next frame
            frame++;
            //Load the frame
            mat.material.SetTexture("_BaseMap", sprites[frame]);
            //Lf the frame counter reached the end of the sprites array, it start's over
            if (frame >= sprites.Length - 1)
            {
                frame = 0;
            }
        }
    }
}