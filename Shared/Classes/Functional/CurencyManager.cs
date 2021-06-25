using System;
using System.Globalization;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class CurencyManager {
        public static string ParseToCurency(decimal value) {
            return String.Format(new CultureInfo("de-DE"), "{0:C}", value);
        }
    }
}