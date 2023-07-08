namespace LoadImages.Features.LoadSceneManager
{
    using UnityEditor;
    using UnityEngine;
    /// <summary>
    ///  нопка загрузки другой сцены.
    /// </summary>
    public sealed class ButtonLoadSceneView : AbstractButtonView
    {
        [SerializeField]
        private string _nextScene = default;

        protected override void OnButtonClicked() => LoadSceneManager.Instance.LoadSceneByName(_nextScene);
    }
}