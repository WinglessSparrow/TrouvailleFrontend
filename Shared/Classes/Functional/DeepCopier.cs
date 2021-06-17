using System.Text.Json;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class DeepCopier {
        public static T DeepCopy<T>(T objectToCopy) {
            var json = JsonSerializer.Serialize(objectToCopy);
            var copy = JsonSerializer.Deserialize<T>(json);
            return copy;
        }
    }
}