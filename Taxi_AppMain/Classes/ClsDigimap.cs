using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Taxi_Model;

namespace Taxi_AppMain.Digi
{
    

        public class digimapRequest
        {
            public string key { get; set; }
            public string Address { get; set; }
            public string value { get; set; }
        }
        public class digimapResponse
        {
            public int count { get; set; }
            public List<Result> results { get; set; }
        }
        public class LatLong
        {
            public double x { get; set; }
            public double y { get; set; }
        }
        public class Attributes
        {
            public string text { get; set; }
            public LatLong latLong { get; set; }
        }
        public class Result
        {
            public string journal { get; set; }
            public int doc { get; set; }
            public int rev { get; set; }
            public int @ref { get; set; }
            public Attributes attributes { get; set; }
            public DateTime from { get; set; }
            public int predecessorRef { get; set; }
        }




        public class AddressDetails
        {
            public string AddressLine1;
            public string Coordinates;


        }


        public class DigiMapSearch
        {
        public digimapResponse Getdigimap(digimapRequest digimapRequest)
        {
            //LogUtility.LogInfo(System.Text.Json.JsonSerializer.Serialize(ClsDigimap.digimapRequest), "GetdigimapRequest", "Getdigimap");
            digimapResponse digimapResponse = new digimapResponse();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                using (var client = new HttpClient())
                {
          
                    client.BaseAddress = new Uri("https://cafv3.gov.gg/v3/addresses/search");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(digimapRequest.key));
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
                    var resultTask = client.GetAsync("?term={index:'" + digimapRequest.Address + "',value:'" + digimapRequest.value + "'}&term={index:'active',value:'true'}&include=text,latLong").Result;
                    var response = resultTask.Content.ReadAsStringAsync().Result;
                    digimapResponse = JsonConvert.DeserializeObject<digimapResponse>(response);
                    // LogUtility.LogInfo(System.Text.Json.JsonSerializer.Serialize(digimapResponse), "GetdigimapResponse", "Getdigimap");
                }
            }
            catch (Exception e)
            {
                // LogUtility.LogException(e, "Getdigimap-Exception");
            }
            return digimapResponse;
        }

        public List<AddressDetails> SearchAddress(string Key, string Address, string Value)
            {
                string json = string.Empty;

                digimapRequest st = new digimapRequest();

                Attributes response = new Attributes();

                List<AddressDetails> list = new List<AddressDetails>();

                st.key = Key;
                st.Address = Address;
                st.value = Value;


            //digimapResponse arr= Getdigimap(st);

            //if (arr!=null && arr.results != null)
            //{

            //    foreach (var item in arr.results)
            //    {
            //        try
            //        {
            //            if (item.attributes.latLong != null)
            //                list.Add(new AddressDetails { AddressLine1 = item.attributes.text.Replace("\r\n", " ").ToUpper(), Coordinates = item.attributes.latLong.y + "," + item.attributes.latLong.x });
            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //    }
            //}

            using (var client = new HttpClient())
            {



                var BASE_URL = "https://api-eurosofttech.co.uk/Sandbox-Supplierapi/api/digimap-search-address";
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent
                                             (JsonConvert.SerializeObject(st), Encoding.UTF8, "application/json");
                HttpResponseMessage postTask = client.PostAsync(BASE_URL, stringContent).Result;

                if (postTask.IsSuccessStatusCode)
                {

                    var responses = postTask.Content.ReadAsStringAsync().Result;

                    //int count = JsonConvert.DeserializeObject<ClsDigimap.digimapResponse>(responses).count;

                    if (responses != null)
                    {

                        var arr = JsonConvert.DeserializeObject<digimapResponse>(responses);

                        if (arr.results != null)
                        {

                            foreach (var item in arr.results)
                            {
                                try
                                {
                                    if (item.attributes.latLong != null)
                                        list.Add(new AddressDetails { AddressLine1 = item.attributes.text.Replace("\r\n", " ").ToUpper(), Coordinates = item.attributes.latLong.y + "," + item.attributes.latLong.x });
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                        //for (int i = 0; i < count; i++)
                        //{
                        //    response = JsonConvert.DeserializeObject<ClsDigimap.digimapResponse>(responses).results[i].attributes;

                        //    if (i < 10)
                        //        list.Add(new stp_GetByRoadLevelDataResult { AddressLine1 = response.text.Replace("\r\n", " ").ToUpper() });
                        //    else
                        //        break;
                        //}
                    }

                }
            }

            return list;

            }

            public List<stp_GetByRoadLevelDataResult> SearchAddressOnly(string Key, string Address, string Value)
            {
                string json = string.Empty;

                digimapRequest st = new digimapRequest();

                Attributes response = new Attributes();

                List<stp_GetByRoadLevelDataResult> list = new List<stp_GetByRoadLevelDataResult>();

                st.key = Key;
                st.Address = Address;
                st.value = Value;

                using (var client = new HttpClient())
                {

                    var BASE_URL = "https://api-eurosofttech.co.uk/Sandbox-Supplierapi/api/digimap-search-address";
                    client.BaseAddress = new Uri(BASE_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringContent = new StringContent
                                                 (JsonConvert.SerializeObject(st), Encoding.UTF8, "application/json");
                    HttpResponseMessage postTask = client.PostAsync(BASE_URL, stringContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {

                        var responses = postTask.Content.ReadAsStringAsync().Result;

                        //int count = JsonConvert.DeserializeObject<ClsDigimap.digimapResponse>(responses).count;

                        if (responses != null)
                        {

                            var arr = JsonConvert.DeserializeObject<digimapResponse>(responses);

                            if (arr.results != null)
                            {

                                foreach (var item in arr.results)
                                {
                                    list.Add(new stp_GetByRoadLevelDataResult { AddressLine1 = item.attributes.text.Replace("\r\n", " ").ToUpper() });
                                }
                            }
                            //for (int i = 0; i < count; i++)
                            //{
                            //    response = JsonConvert.DeserializeObject<ClsDigimap.digimapResponse>(responses).results[i].attributes;

                            //    if (i < 10)
                            //        list.Add(new stp_GetByRoadLevelDataResult { AddressLine1 = response.text.Replace("\r\n", " ").ToUpper() });
                            //    else
                            //        break;
                            //}
                        }

                    }
                }

                return list;

            }

            public stp_getCoordinatesByAddressResult SearchSingleAddress(string Key, string Address, string Value)
            {
                stp_getCoordinatesByAddressResult cc = null;
                string json = string.Empty;

                digimapRequest st = new digimapRequest();

                Attributes response = new Attributes();

                List<stp_GetByRoadLevelDataResult> list = new List<stp_GetByRoadLevelDataResult>();

                st.key = Key;
                st.Address = Address;
                st.value = Value.Replace("Ê", "E");




                using (var client = new HttpClient())
                {

                    var BASE_URL = "https://api-eurosofttech.co.uk/Sandbox-Supplierapi/api/digimap-search-address";
                    client.BaseAddress = new Uri(BASE_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringContent = new StringContent
                                                 (JsonConvert.SerializeObject(st), Encoding.UTF8, "application/json");
                    HttpResponseMessage postTask = client.PostAsync(BASE_URL, stringContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {

                        var responses = postTask.Content.ReadAsStringAsync().Result;


                        if (responses != null)
                        {
                            var arr = JsonConvert.DeserializeObject<digimapResponse>(responses);


                            if (arr != null && arr.results != null && arr.results.Count > 0)
                            {
                                var data = arr.results.FirstOrDefault();

                                cc = new stp_getCoordinatesByAddressResult();
                                cc.Latitude = data.attributes.latLong.y;
                                cc.Longtiude = data.attributes.latLong.x;
                            }
                            else
                            {


                            }
                        }
                    }
                }

                return cc;

            }


        }


   




}