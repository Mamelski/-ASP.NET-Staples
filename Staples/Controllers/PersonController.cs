// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonController.cs" company="">
//   
// </copyright>
// <summary>
//   The person controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Staples.DAL.DataStores;
    using Staples.Model;

    /// <summary>
    /// The person controller.
    /// </summary>
    public class PersonController : Controller
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="personDetails">
        /// The person details.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Create(PersonDetails personDetails)
        {
            // TODO this should be taken from config/IoC/factory but for now it is inside method 
            var dataStores = new List<IDataStore>
                                 {
                                     new DatabaseStore(),
                                     new XmlStore(),
                                     new NLogStore()
                                 };

            var errorMessage = string.Empty;

            foreach (var dataStore in dataStores)
            {
                try
                {
                    dataStore.Save(personDetails);
                }
                catch (Exception ex)
                {
                    // TODO those messages should be custom, maybe IDataStore should handle error himself ? not enough time
                    // TODO maybe custom exception type with error code and nice messages, maybe custom return type ?
                    errorMessage += $"Exception while saving data {ex.Message}";
                    continue;
                }
            }

            // TODO dummy handling and returning dummy custom views
            if (errorMessage != string.Empty)
            {
                this.ViewBag.ErrorMessage = errorMessage;
                return this.View("ErrorSave");
            }

            return this.View("SuccessSave");
        }
    }
}