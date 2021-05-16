using System;
using TrouvailleFrontend.Shared.Enums;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class EnumIconRetriever {
        private static T GetAttribute<T, ET>(ET methodType) where T : System.Attribute where ET : System.Enum {
            var enumArray = methodType.GetType().GetMember(Enum.GetName(methodType.GetType(), methodType));
            var output = enumArray[0].GetCustomAttributes(typeof(T), inherit: false)[0] as T;
            return output;
        }

        public static string GetIcon<T>(T status) where T : System.Enum {
            return GetAttribute<IconsAttribute, T>(status).Icon;
        }
    }
}