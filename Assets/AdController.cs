namespace Assets
{
    using System;
    using UnityEngine.Advertisements;

    public class AdController
    {
        private const string AdId = "video";

        public static void ShowAd(Action onWatched)
        {
            if (Advertisement.IsReady(AdId))
            {
                var showOptions = new ShowOptions
                {
                    resultCallback = (result) => OnAdWatched(result, onWatched)
                };

                Advertisement.Show(AdId, showOptions);
            }
        }

        private static void OnAdWatched(ShowResult watchResult, Action onWatched)
        {
            onWatched.Invoke();
        }
    }
}
