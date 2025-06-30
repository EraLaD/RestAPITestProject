using RestAPITestProject.apimodels;


namespace RestAPITestProject.TestData
{
    public static class TestData
    {
        public static APIRequestObject  NewObject = new APIRequestObject
        {
            name = "ASUS Zenbook S 14",
            data = new DataInfoApiRequest
            {
                year = 2025,
                price = 1668.12f,
                CPUmodel = "Intel Core Ultra 5 125H",
                Harddisksize = "1 TB"
            }
        };

       public static APIRequestObject UpdatedObject => new APIRequestObject
        {
            name = "ASUS Zenbook S 15",
            data = new DataInfoApiRequest
            {
                year = 2025,
                price = 1668.12f,
                CPUmodel = "Intel Core Ultra 5 125H",
                Harddisksize = "1 TB"
            }
        };
    }
}
