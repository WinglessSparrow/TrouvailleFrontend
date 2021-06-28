namespace TrouvailleFrontend.Shared.Classes.API {
    public class ApiPathsCentralDefinition {
        public const string API_IP = "https://trouvaille.conveyor.cloud/api/";
        //public const string API_IP = "https://trouvaille.vvjm.dev/api/";
        public const string API_PRODUCTS_IN_RANGE = API_IP + "Products";
        public const string API_PRODUCT_BY_ID = API_IP + "Products";
        public const string API_PRODUCTS_BY_ID_ARRAY = API_IP + "Products/GetMultiple";
        public const string API_PRODUCT_COUNT = API_IP + "Products/Count";
        public const string API_ORDER = API_IP + "Orders";
        public const string API_LOGIN = API_IP + "Auth/Customer/Login";
        public const string API_REGISTER = API_IP + "Auth/Customer/Register";
        public const string API_CHANGE_USER = API_IP + "Auth/Customer";
        public const string API_GET_USER = API_IP + "Auth/Customer/info";
        public const string API_RESET_PASSWORD = API_IP + "Auth/Customer/ResetPassword";
        public const string API_GET_HISTORY = API_IP + "Orders/History";
        public const string API_SEARCH_QUERY = API_IP + "Products/SearchQuery";
        public const string API_SEARCH_QUERY_COUNT = API_IP + "Products/SearchQueryCount";
        public const string API_GET_CATEGORIES = API_IP + "Categories";
    }
}