using System.Drawing;

namespace CT_Win.Recursos
{
    public static class Theme
    {
        // Primárias
        public static readonly Color PrimaryDark  = ColorTranslator.FromHtml("#1F4860");
        public static readonly Color Primary      = ColorTranslator.FromHtml("#2C5F7F");
        public static readonly Color PrimaryHover = ColorTranslator.FromHtml("#3A6F8F");
        public static readonly Color PrimaryLight = ColorTranslator.FromHtml("#D5E1EB");

        // Semânticas
        public static readonly Color Success      = ColorTranslator.FromHtml("#52A88C");
        public static readonly Color Warning      = ColorTranslator.FromHtml("#D4A437");
        public static readonly Color Danger       = ColorTranslator.FromHtml("#B83A30");
        public static readonly Color Info         = ColorTranslator.FromHtml("#3A7DC9");

        public static readonly Color SuccessLight = ColorTranslator.FromHtml("#E7F3EE");
        public static readonly Color WarningLight = ColorTranslator.FromHtml("#FAF1DC");
        public static readonly Color DangerLight  = ColorTranslator.FromHtml("#FCF3F2");

        // Neutras
        public static readonly Color Bg1     = ColorTranslator.FromHtml("#FFFFFF");
        public static readonly Color Bg2     = ColorTranslator.FromHtml("#F7F8FA");
        public static readonly Color Bg3     = ColorTranslator.FromHtml("#EDF1F4");

        public static readonly Color Border1 = ColorTranslator.FromHtml("#E0E5EB");
        public static readonly Color Border2 = ColorTranslator.FromHtml("#C5CDD6");
        public static readonly Color Border3 = ColorTranslator.FromHtml("#8B96A3");

        public static readonly Color TextStrong = ColorTranslator.FromHtml("#1F2937");
        public static readonly Color TextBody   = ColorTranslator.FromHtml("#374151");
        public static readonly Color TextMuted  = ColorTranslator.FromHtml("#5B6573");
        public static readonly Color TextWeak   = ColorTranslator.FromHtml("#8B96A3");

        // Especialidades (espelha Especialidade.CorHex do banco)
        public static readonly Color EspPsicologia    = ColorTranslator.FromHtml("#4A7CA8");
        public static readonly Color EspFonoaudiologia = ColorTranslator.FromHtml("#B85450");
        public static readonly Color EspTerapiaOcup   = ColorTranslator.FromHtml("#5BA88C");
        public static readonly Color EspPsicopedagogia = ColorTranslator.FromHtml("#C9904B");
        public static readonly Color EspMusicoterapia  = ColorTranslator.FromHtml("#8B6FA8");

        // Tipografia
        private const string FontFamily = "Segoe UI";

        public static readonly Font H1       = new Font(FontFamily, 16f, FontStyle.Bold);
        public static readonly Font H2       = new Font(FontFamily, 12f, FontStyle.Bold);
        public static readonly Font H3       = new Font(FontFamily, 10f, FontStyle.Bold);
        public static readonly Font Body     = new Font(FontFamily,  9f, FontStyle.Regular);
        public static readonly Font BodyBold = new Font(FontFamily,  9f, FontStyle.Bold);
        public static readonly Font Caption  = new Font(FontFamily,  8f, FontStyle.Regular);
        public static readonly Font Button   = new Font(FontFamily, 9.5f, FontStyle.Regular);

        // Espaçamento (grid 8px)
        public const int Space0_5 = 4;
        public const int Space1   = 8;
        public const int Space2   = 16;
        public const int Space3   = 24;
        public const int Space4   = 32;
        public const int Space6   = 48;
        public const int Space8   = 64;

        // Alturas padrão
        public const int InputHeight  = 30;
        public const int ButtonHeight = 36;
        public const int RowHeight    = 28;
    }
}
