// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLogStore.cs" company="">
//   
// </copyright>
// <summary>
//   The n log store.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.DAL.DataStores
{
    using System;

    using AutoMapper;

    using NLog;

    using Staples.Model;

    /// <summary>
    /// The n log store.
    /// </summary>
    public class NLogStore : IDataStore
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogStore"/> class.
        /// </summary>
        public NLogStore()
        {
            // TODO this could be called only once (now in every IDataStore)
            Mapper.Initialize(cfg => { cfg.CreateMap<PersonDetails, PersonBase>(); });
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="personDetails">
        /// The person details.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Save(PersonDetails personDetails)
        {
            var personBase = Mapper.Instance.Map<PersonDetails, PersonBase>(personDetails);

            // TODO I should check if this person is already in log file, but I have no better idea than to just read the file line by line, split by "|" and check for values
            // TODO maybe NLog has method for this (no duplicated messages), but again no time.
            // TODO maybe I should check somewhere else if data is saved in storage instead of checking it in every storage ?
            logger.Info($"{personBase.FirstName},{personBase.LastName}");
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}