//using System;

//namespace vp_new_project.Services
//{
//    public static class AppThemeState
//    {
//        public static bool IsDark { get; set; } = true;
//        public static event Action? OnChange;

//        public static void ToggleTheme()
//        {
//            IsDark = !IsDark;
//            OnChange?.Invoke(); // Tells pages to redraw immediately
//        }
//    }
//}

using System;

namespace blazor_final_pro.Services
{
    public static class AppThemeState
    {
        public static bool IsDark { get; set; } = true;
        public static event Action? OnChange;

        public static void ToggleTheme()
        {
            IsDark = !IsDark;
            OnChange?.Invoke();
        }
    }
}