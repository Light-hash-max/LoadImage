namespace LoadImages.Features.ImageLoader
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Загружаемое изображение в галерее
    /// </summary>
    [RequireComponent(typeof(Image))]
    public sealed class LoadedImageGallery : LoadedImage
    {
        [SerializeField]
        private Button _viewImageButton = default;

        protected override void Awake()
        {
            base.Awake();
            _viewImageButton.onClick.AddListener(SelectItem);
            _viewImageButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (_viewImageButton == null)
            {
                return;
            }
            _viewImageButton.onClick.RemoveListener(SelectItem);
        }

        private void SelectItem() => _loadedImageIdSO.LoadedImageId = _id;

        /// <summary>
        /// Записать id
        /// </summary>
        /// <param name="newId"></param>
        public void SetId(string newId) => _id = newId;

        protected override void SetAdditionalImageSettings()
        {
            base.SetAdditionalImageSettings();
            _viewImageButton.gameObject.SetActive(true);
        }
    }
}
