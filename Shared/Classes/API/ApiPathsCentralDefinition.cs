namespace TrouvailleFrontend.Shared.Classes.API {
    public class ApiPathsCentralDefinition {
        public const string API_IP = "https://141.79.34.112:5001";
        public const string API_PRODUCTS_IN_RANGE = API_IP + "/api/Products";
        public const string API_PRODUCT_BY_ID = API_IP + "/api/Products";
        public const string API_PRODUCTS_BY_ID_ARRAY = API_IP + "/api/Products/GetMultiple";
        public const string API_PRODUCT_COUNT = API_IP + "/api/Products/Count";
        public const string API_ORDER = API_IP + "/api/Orders";
        public const string API_LOGIN = API_IP + "/api/Auth/Customer/Login";
        public const string API_REGISTER = API_IP + "/api/Auth/Customer/Register";
        public const string API_CHANGE_USER = API_IP + "/api/Auth/Customer";
        public const string API_GET_USER = API_IP + "/api/Auth/Customer/info";
        public const string API_RESET_PASSWORD = API_IP + "/api/Auth/Customer/ResetPassword";
        public const string API_GET_HISTORY = API_IP + "/api/Orders/History";
        public const string API_SEARCH_QUERY = API_IP + "/api/Products/SearchQuery";
        public const string API_SEARCH_QUERY_COUNT = API_IP + "/api/Products/SearchQueryCount";
    }
}