using System;
using RObo;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuangCao : PersistentSingleton<QuangCao>
{
#if UNITY_ANDROID
#elif UNITY_IPHONE
      private const string AD_UNIT_ID = "ca-app-pub-7030564084462348/3506276416";
    private const string BANNER_UNIT_ID = "ca-app-pub-7030564084462348/3332970305";
#else
    private const string AD_UNIT_ID = "unexpected_platform";
#endif
    
}