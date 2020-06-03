using UnityEngine;

namespace Custom.Color
{
    public class ShaderColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        // public ShaderColor()
        // {
        // }

        public ShaderColor(string R, string G, string B)
        {
            byte r, g, b;
            byte.TryParse(R, out r);
            byte.TryParse(G, out g);
            byte.TryParse(B, out b);

            Red = ValidateColorValue(r);
            Green = ValidateColorValue(g);
            Blue = ValidateColorValue(b);
            Alpha = 255;
        }

        // Validation is called but it is cancelled out...
        // Some other validation is running (probably InputText) idk how it's called or what eaxctly does
        private byte ValidateColorValue(byte rgbValue)
        {
            if (rgbValue < 0)
            {
                Debug.Log("rgb negative");
                return 0;
            }
            else if (rgbValue > 255)
            {
                Debug.Log("rgb too big");
                return 255;
            }

            return rgbValue;
        }


    }
}