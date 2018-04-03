using System.Web.Script.Serialization;
using System.Web.Mvc;
using System;

namespace HospitalAPI.Helper
{
    /// <summary>
    /// Pubilc static class ActionResultToJson
    /// </summary>
    public static class ToJsonConvertor
    {
        /// <summary>
        /// Public static method ToJson to convert ActionResult to Json format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actionResult"></param>
        /// <returns></returns>
        public static T ActionResultToJson<T>(this ActionResult actionResult)
        {
            var jsonResult = (JsonResult)actionResult;

            if (jsonResult == null)
                return default(T);

            return (T)jsonResult.Data;
        }

        /// <summary>
        /// Convert Json to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                return serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}