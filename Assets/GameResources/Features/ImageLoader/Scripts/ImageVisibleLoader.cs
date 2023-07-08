namespace LoadImages.Features.ImageLoader
{
    using System.Threading.Tasks;
    using UnityEngine;

    /// <summary>
    /// Подгружает изображение при появлении в камере
    /// </summary>
    [RequireComponent(typeof(LoadedImage), typeof(RectTransform))]
    public class ImageVisibleLoader : MonoBehaviour
    {
        private LoadedImage _loadedImage = default;
        private RectTransform _rectTransform = default;
        private bool _isVisable = false;

        private void Awake()
        {
            _loadedImage = GetComponent<LoadedImage>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start() => CheckVisible();

        private async void CheckVisible()
        {
            while (!_isVisable && enabled)
            {
                _isVisable = _rectTransform.IsFullyVisibleFrom(Camera.main);
                await Task.Delay(1000);
            }
            _loadedImage.LoadImage();
        }
    }
}
