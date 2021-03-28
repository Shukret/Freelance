using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
    //функция для кнопки поделиться
    public void ShareButtonClick()
    {
        StartCoroutine(TakeSSAndShare());
    }

    //корутина запуска процесса "поделиться"
    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "FlappyRingGame.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Flappy Ring Game").SetText("Привет, хочу поделиться с вами крутой игрой!").Share();
    }
}