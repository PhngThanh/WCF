using System.Drawing;

namespace POS.CustomControl
{
    public enum BootstrapColorEnum
    {
        Default,
        Primary,
        Success,
        Warning,
        Danger,
        Info,

        //Application Color
        StripColor,
        BackColor,
        MainColor,
    }

    public static class ColorScheme
    {
        public static Color Default = ColorTranslator.FromHtml("#2BBBAD");
        public static Color Primary = ColorTranslator.FromHtml("#4285F4");
        public static Color Success = ColorTranslator.FromHtml("#00c851");
        public static Color Warning = ColorTranslator.FromHtml("#ffbb33");
        public static Color Danger = ColorTranslator.FromHtml("#ff4444");
        public static Color Info = ColorTranslator.FromHtml("#33b5e5");

        public static Color AtStore = ColorTranslator.FromHtml("#ffa500");
        public static Color TakeAway = ColorTranslator.FromHtml("#9c188a");
        public static Color Delivery = ColorTranslator.FromHtml("#5d3241");

        public static Color SecondaryColor = ColorTranslator.FromHtml("#0d47a1");

        public static Color StripColor = ColorTranslator.FromHtml("#ffffff");
        public static Color BackColor = ColorTranslator.FromHtml("#4e4e4e");

        //Yellow SGV
        //public static Color MainColor = ColorTranslator.FromHtml("#ffcc00"); 

        //Green Passio
        public static Color MainColor { get; set; } = ColorTranslator.FromHtml("#a6ce38");

        //Green SKYPOS
        //public static Color MainColor = ColorTranslator.FromHtml("#00c851"); 

        public static Color GetColor(BootstrapColorEnum color)
        {
            switch (color)
            {
                case BootstrapColorEnum.Default:
                    return ColorScheme.Default;
                case BootstrapColorEnum.Primary:
                    return ColorScheme.Primary;
                case BootstrapColorEnum.Success:
                    return ColorScheme.Success;
                case BootstrapColorEnum.Warning:
                    return ColorScheme.Warning;
                case BootstrapColorEnum.Danger:
                    return ColorScheme.Danger;
                case BootstrapColorEnum.Info:
                    return ColorScheme.Info;
                case BootstrapColorEnum.StripColor:
                    return ColorScheme.StripColor;
                case BootstrapColorEnum.BackColor:
                    return ColorScheme.BackColor;
                case BootstrapColorEnum.MainColor:
                    return ColorScheme.MainColor;
                default:
                    return ColorScheme.Info; ;
            }
        }
    }
}
