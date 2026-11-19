using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public const int LastSceneIndex = 1;
    public int CurrentSceneIndex;

    public Image fadeImage;
    // Length of the fade
    public float fadeDuration = 0.4f;


    public float fadeAmount = 1;
    private int sceneToLoad = -1;
    // Only true when the fade starts as user moves to another scene.
    private bool isLeaving = false;

    void Start() {
        fadeAmount = 1;
        ApplyFade();
    }

    void Update(){
        // If there is no fade image that has been set up there should be nothing to animate
        if (fadeImage == null)
        {
            return;
        }

        // delta.Time / fadeDuration = how much of the fade will fit.
        if (isLeaving) {
            // Gets darker
            fadeAmount += Time.deltaTime / fadeDuration;
        }
        else {
            fadeAmount -= Time.deltaTime / fadeDuration;
        }

        // This code keeps fadeAmount between 0 and 1
        fadeAmount = Mathf.Clamp(fadeAmount, 0, 1);

        ApplyFade();

        // When the screen is fully black, the scene can be changed.
        if (isLeaving && fadeAmount >= 1){
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void NextScene()
    {
        // Code that gets current index and turns it into int
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If current scene index is >= last scene index there is no next scene to go to
        if (CurrentSceneIndex < LastSceneIndex){
            GoToScene(CurrentSceneIndex + 1);
        }
    }

    public void PreviousScene()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If current scene index is <= 0 there is no last screen
        if (CurrentSceneIndex > 0){
            GoToScene(CurrentSceneIndex - 1);
        }
    }

    public void HomeScene()
    {
        GoToScene(0);
    }

    // One method that always changes the scenes.
    public void GoToScene(int index)
    {
        // Ignoring user inputs while the scenes are fading between each other.
        if (isLeaving)
        {
            return;
        }

        if (fadeImage == null)
        {
            SceneManager.LoadScene(index);
            return;
        }

        sceneToLoad = index;
        isLeaving = true;
    }
    public void ApplyFade(){
        if (fadeImage != null){
            fadeImage.color = new Color(0, 0, 0, fadeAmount);
        }
    }
}
