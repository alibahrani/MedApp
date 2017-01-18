using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignUpApplication.Helper
{
    public class Helper
    {
        //Get all user from mongoDB
        public static async Task<List<Patient>> getAllPatient()
        {
            using (var HttpClient = new HttpClient())
            {
                HttpResponseMessage response = await HttpClient.GetAsync(Common.API_SELECT_DOCUMENTS_LINK);
                var responseAsBodyText = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK) //200 - OK
                {
                    //Convert result to JSON
                    var patients = JsonConvert.DeserializeObject<List<Patient>>(responseAsBodyText);
                    return patients;
                }
            }
            return null;
        }

        public static async Task insertNewPatient(string patient, string age, string sickness, string allergies)
        {
            using (var client = new HttpClient())
            {
                var address = new Uri(Common.API_SELECT_DOCUMENTS_LINK);
                Patient addPatient = new Patient();
                addPatient.name = patient;
                addPatient.age = age;
                addPatient.sickness = sickness;
                addPatient.allergies = allergies;

                string postPody = JsonConvert.SerializeObject(addPatient);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var responseBodyAsText = await client.PostAsync(address, new StringContent(postPody, Encoding.UTF8, "application/json"));


            }
        }

        public static async Task deleteUser(Patient patient)
        {
            using (var client = new HttpClient())
            {
                StringBuilder str = new StringBuilder(Common.API_DOCUMENTS_LINK);
                str.Append("/" + patient._id.oid + "?apiKey=" + Common.API_KEY);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var responseBodyAsText = await client.DeleteAsync(str.ToString());
            }
        }
    }
}
