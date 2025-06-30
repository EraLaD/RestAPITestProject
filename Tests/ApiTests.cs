
using RestAPITestProject.apiresponses;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit.Priority;
using RestAPITestProject.support.utils;
using RestAPITestProject.apimodels;



namespace RestAPITestProject { 
    public class ApiTests 

    {

        private readonly HttpClient _client;
        private string? id;
        

        public ApiTests()
        {
            _client = URLBuilder.GetHttpClient();

        }


        [Fact, Priority(1)]
        public async Task GetListOfAllObjectsTest()
        {
            // Act - GET request to get list of all objects
            var response = await _client.GetAsync(APIEndpoints.GetListOfAllObjects);

            // Assert - Check if the response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Deserialize the response content
            string? jsonContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonContent);
            var apiResponseContent = JsonSerializer.Deserialize<List<APIResponseObject>>(jsonContent);

            // Assert - Check if the response content is not null or empty
            Assert.NotNull(apiResponseContent);
            Assert.NotEmpty(apiResponseContent!);
        }

            [Fact, Priority(2)]
        public async Task AddGetUpdateDeleteObjectTest()
        {


            //-----------ADDING AN OBJECT--------------

           APIRequestObject newObject= TestData.TestData.NewObject;    

            // Serialize the object to JSON
            var jsonRequestContent = new StringContent(JsonSerializer.Serialize(newObject), Encoding.UTF8, "application/json");

            // Act - POST request to add an object
            var responseAddObject = await _client.PostAsync(APIEndpoints.AddObject, jsonRequestContent);


            // Assert - Check if the response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, responseAddObject.StatusCode);

            // Deserialize the response content
            string? jsonContentAddObject = await responseAddObject.Content.ReadAsStringAsync();
            var apiResponseContentAddingObject = JsonSerializer.Deserialize<APIResponseObject>(jsonContentAddObject);

            // Assert - Check if the response content is not null or empty
            Assert.NotNull(apiResponseContentAddingObject);
            Assert.NotEmpty(apiResponseContentAddingObject.id);
            Assert.Equal(newObject.name, apiResponseContentAddingObject.name);
            Assert.True(apiResponseContentAddingObject.createdAt != null, "CreatedAt for adding an object should not be null");
            id = apiResponseContentAddingObject.id;

            //--------------GETTING CREATED OBJECT BY ID----------------
            // Act - GET created object by ID
            String url= APIEndpoints.GetObjectById.Replace("{id}", id);
            var responseGetObjectById = await _client.GetAsync(APIEndpoints.GetObjectById.Replace("{id}", id));


            // Assert - Check if the response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, responseGetObjectById.StatusCode);

            // Deserialize the response content
            string? jsonContentGetObjectById = await responseGetObjectById.Content.ReadAsStringAsync();
            var apiResponseContentGetObjectById = JsonSerializer.Deserialize<APIResponseObject>(jsonContentGetObjectById);

            // Assert - Check if the response content is not null or empty and the name of the object matches the one added
            Assert.NotNull(apiResponseContentGetObjectById);
            Assert.Equal(apiResponseContentGetObjectById.id, id);
            Assert.Equal(newObject.name, apiResponseContentGetObjectById.name);

            //--------------UPDATING THE CREATED OBJECT----------------
            APIRequestObject updatedObject= TestData.TestData.UpdatedObject;

            // Serialize the object to JSON
            var jsonRequestContentUpdateObject = new StringContent(JsonSerializer.Serialize(updatedObject), Encoding.UTF8, "application/json");

            // Act - PUT request to update an object
            var responseUpdateObject = await _client.PutAsync(APIEndpoints.UpdateObjectById.Replace("{id}", id), jsonRequestContentUpdateObject);

            // Assert - Check if the response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, responseUpdateObject.StatusCode);

            // Deserialize the response content
            string? jsonContentUpdateObject = await responseUpdateObject.Content.ReadAsStringAsync();
            var apiResponseContentUpdateObject = JsonSerializer.Deserialize<APIResponseObject>(jsonContentUpdateObject);

            // Assert - Check if the response content is not null or empty & the name is updated
            Assert.NotNull(apiResponseContentUpdateObject);
            Assert.Equal(updatedObject.name, apiResponseContentUpdateObject.name);
        

            //--------------DELETING THE CREATED OBJECT----------------

            // Act - DELETE request to DELETE an object
            var responseDelete = await _client.DeleteAsync(APIEndpoints.DeleteObjectById.Replace("{id}", id));

            // Assert - Check if the response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, responseDelete.StatusCode);

            // Deserialize the response content
            string? jsonContentDelete = await responseDelete.Content.ReadAsStringAsync();
            var apiResponseContentDelete = JsonSerializer.Deserialize<APIResponseObject>(jsonContentDelete);

            // Assert - Check if the response content is not null or empty
            Assert.NotNull(apiResponseContentDelete);
            Assert.Equal("Object with id = " + id.ToString() + " has been deleted.", apiResponseContentDelete.message);
        }

    }
}