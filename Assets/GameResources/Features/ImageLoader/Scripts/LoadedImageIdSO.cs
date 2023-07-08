namespace LoadImages.Features.ImageLoader
{
    using UnityEngine;
    /// <summary>
    /// СО c id загруженной картинки
    /// </summary>
    [CreateAssetMenu(fileName = "LoadedImageIdSO", menuName = "LoadImages/Features/ImageLoader/Create LoadedImageIdSO")]
    public class LoadedImageIdSO : ScriptableObject
    {
        /// <summary>
        /// id загруженной подписки
        /// </summary>
        public string LoadedImageId
        {
            get => PlayerPrefs.GetString(nameof(LoadedImageIdSO), string.Empty);

            set
            {
                PlayerPrefs.SetString(nameof(LoadedImageIdSO), value);
                PlayerPrefs.Save();
            }
        }
    }
}