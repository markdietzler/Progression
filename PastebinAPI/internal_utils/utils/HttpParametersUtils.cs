using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinAPI.internal_utils.utils
{
    public class HttpParametersUtils
    {
        private Dictionary<String, String> parameters = new Dictionary<string, string>();

        public void Put(string key, string value)
        {
            try
            {
                parameters.put(URLEncoder.encode(key, StandardCharsets.UTF_8.displayName()), URLEncoder.encode(value, StandardCharsets.UTF_8.displayName()));
            }
            catch (UnsupportedEncodingException e)
            {
                throw new AssertionError(e);// can't happen
            }
        }

        public void remove(string key)
        {
            try
            {
                parameters.Remove(URLEncoder.encode(key, StandardCharsets.UTF_8.displayName()));
            }
            catch (EncoderFallbackException e)
            {
                throw new Exception(e); // can't happen
            }
        }

        public String toUrlFormat()
        {
            StringBuilder builder = new StringBuilder();

            for (Map.Entry < String, String > entry : parameters.entrySet())
            {
                builder.Append(entry.getKey())
                    .append("=")
                    .append(entry.getValue())
                    .append("&");
            }

            if (builder.Length > 0)
            {
                builder.Length --;
            }

            return builder.ToString();
        }
    }
}
