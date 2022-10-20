using System;
namespace VistaLifeSampleApp.Common.Utilities
{
    public static class ApplicationConstants
    {
        //TODO: For now storing the user name and password in constants file
        //For a production app this is NOT recommended at all and passwords should not be stored in code.
        public static string UserName = "test";
        public static string Password = "test";

        public static string InvalidCredentials = "The user name or password is invalid";

        public static string CannotFindDetailItem = "Not able to find the selected item";

        public static string BaseURL = "https://jsonplaceholder.typicode.com/users";

        public const string JsonType = "application/json";

    }
}
