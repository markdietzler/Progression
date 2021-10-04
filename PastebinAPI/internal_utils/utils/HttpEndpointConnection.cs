using System;
using System.Text;
using PastebinAPI.response;

namespace PastebinAPI.internal_utils.utils
{
    public class HttpEndpointConnection<T>
    {
        private const string PASTEBIN_API_ENDPOINT = "https://pastebin.com/api/api_post.php";
        private const string PASTEBIN_RAW_ENDPOINT = "https://pastebin.com/raw.php";
        private const string PASTEBIN_LOGIN_ENDPOINT = "https://pastebin.com/api/api_login.php";
        private HttpParametersUtils _Parameters = new HttpParametersUtils();
        private string _Endpoint;

        protected HttpEndpointConnection(string new_endpoint)
        {
            this._Endpoint = new_endpoint;
        }

        public static <T> HttpEndpointConnection<T> connectToMainEndpoint()
        {
            return new HttpEndpointConnection<>(PASTEBIN_API_ENDPOINT);
        }

        public static <T> HttpEndpointConnection<T> connectToRawEndpoint()
        {
            return new HttpEndpointConnection<>(PASTEBIN_RAW_ENDPOINT);
        }

        public static <T> HttpEndpointConnection<T> connectToLoginEndpoint()
        {
            return new HttpEndpointConnection<>(PASTEBIN_LOGIN_ENDPOINT);
        }

        public HttpEndpointConnection<T> AddParameter(string key, string value)
        {
            _Parameters.put(key, value);
            return this;
        }

        public HttpEndpointConnection<T> removeParameter(string key)
        {
            parameters.remove(key);
            return this;
        }

        public Response<T> ExecuteAsPost()
        {
            HttpURLConnection connection = null;

            try
            {
                connection = openConnection(endpoint);
                connection.setDoOutput(true);
                connection.setRequestMethod("POST");

                sendParameters(connection.getOutputStream(), parameters);

                string response = buildResponse(connection.getInputStream());
                return handleResponse(response);
            }
            catch (IOException e)
            {
                return Responses.failed("Unable to connect to Pastebin endpoint!");
            }
            finally
            {
                if (connection != null)
                {
                    connection.disconnect();
                }
            }
        }

        public Response<T> ExecuteAsGet()
        {
            HttpURLConnection connection = null;

            try
            {
                connection = openConnection(endpoint + "?" + parameters.toUrlFormat());
                string response = buildResponse(connection.getInputStream());
                return handleResponse(response);
            }
            catch (IOException e)
            {
                return Responses.failed("Unable to connect to Pastebin endpoint!");
            }
            finally
            {
                if (connection != null)
                {
                    connection.disconnect();
                }
            }
        }

        private Response<T> HandleResponse(string response)
        {
            if (response.Contains("Bad API request"))
            {
                return Responses.failed(response);
            }

            Response<T> successResponse = (Response<T>)Responses.success(response);
            return successResponse;
        }

        private HttpURLConnection OpenConnection(string to) throws IOException
        {
    return (HttpURLConnection) URI
        .create(to)
        .toURL()
        .openConnection();
    }

    private String BuildResponse(InputStream source) throws IOException
    {
        BufferedReader inputReader = new BufferedReader(new InputStreamReader(source));
    StringBuilder responseBuilder = new StringBuilder();

    for(String line; (line = inputReader.readLine()) != null;) {
      responseBuilder.append(line);
      responseBuilder.append('\n');
    }

return responseBuilder.toString();
  }

  private void SendParameters(OutputStream destination, HttpParametersUtils parametersUtils) throws IOException
{
    byte[]
    parameters = parametersUtils.toUrlFormat().getBytes(StandardCharsets.UTF_8);
    DataOutputStream dataOutputStream = null;

    try {
        dataOutputStream = new DataOutputStream(destination);
        dataOutputStream.write(parameters);
    } finally {
        if (dataOutputStream != null)
        {
            dataOutputStream.close();
        }
    }
}
    }
}
