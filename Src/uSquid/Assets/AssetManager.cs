using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace uSquid.Assets
{
    public class AssetManager
    {
        static AssetManager _instance = new AssetManager();

        //Simple singleton
        static AssetManager() { }
        private AssetManager()
        {
            _loadedAssets = new Dictionary<string, UnityEngine.Object>();
        }

        public static List<KeyValuePair<string, UnityEngine.Object>> GetAllLoadedAssets()
        {
            var list = _instance._loadedAssets.ToList();
            return list;
        }

        public static bool HasLoaded(string assetPath)
        {
            return assetPath.Contains(assetPath);
        }

        public static T Load<T>(string assetPath) where T : UnityEngine.Object
        {
            if (HasLoaded(assetPath))
                return (T)_instance._loadedAssets[assetPath];

            var asset = Resources.Load<T>(assetPath);
            _instance._loadedAssets.Add(assetPath, asset);

            return asset;
        }

        public static void Unload(string assetPath, bool immediate = false)
        {
            if (!HasLoaded(assetPath))
                return;

            if (immediate)
            {
                UnityEngine.Object.DestroyImmediate(_instance._loadedAssets[assetPath]);
            }
            else
            {
                UnityEngine.Object.Destroy(_instance._loadedAssets[assetPath]);
            }

            _instance._loadedAssets.Remove(assetPath);
        }

        Dictionary<string, UnityEngine.Object> _loadedAssets;
    }
}
