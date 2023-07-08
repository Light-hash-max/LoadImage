namespace LoadImages.Features.ImageLoader
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;

    /// <summary>
    /// Загружаемое изображение
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class LoadedImage : MonoBehaviour
    {
        /// <summary>
        /// Загружено ли изображение
        /// </summary>
        public bool IsImageLoaded { get; protected set; } = false;

        [SerializeField]
        protected Sprite _errorSprite = default;
        [SerializeField]
        protected LoadedImageIdSO _loadedImageIdSO = default;
        [SerializeField]
        protected bool _isUseSavedId = false;

        protected Image _image = default;
        protected string _id = default;
        protected Texture2D _loadedTexture = null;
        protected Coroutine _loadCoroutine = null;
        protected UnityWebRequest _request = default;

        protected virtual void Awake()
        {
            _image = GetComponent<Image>();

            if (_isUseSavedId)
            {
                _id = _loadedImageIdSO.LoadedImageId;
            }
        }

        /// <summary>
        /// Подгрузить изображение
        /// </summary>
        public void LoadImage()
        {
            if (_loadCoroutine != null)
            {
                StopCoroutine(_loadCoroutine);
                _loadCoroutine = null;
            }
            _loadCoroutine = StartCoroutine(GetRemoteTexture(_id));
        }

        protected IEnumerator GetRemoteTexture(string url)
        {
            _request = UnityWebRequestTexture.GetTexture(url);

            yield return _request.SendWebRequest();

            if (_request.result == UnityWebRequest.Result.Success)
            {
                _loadedTexture = DownloadHandlerTexture.GetContent(_request);
                _image.sprite = Sprite.Create(_loadedTexture, new Rect(0f, 0f, _loadedTexture.width, _loadedTexture.height), new Vector2(0.5f, 0.5f), 100f);
                SetAdditionalImageSettings();
            }
            else
            {
                _image.sprite = _errorSprite;
            }
        }

        protected virtual void SetAdditionalImageSettings() => IsImageLoaded = true;

    }
}