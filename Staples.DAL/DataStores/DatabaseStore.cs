// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseStore.cs" company="">
//   
// </copyright>
// <summary>
//   The database store.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.DAL.DataStores
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Staples.Model;

    /// <summary>
    /// The database store.
    /// </summary>
    public class DatabaseStore : IDataStore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseStore"/> class.
        /// </summary>
        public DatabaseStore()
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
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public void Save(PersonDetails personDetails)
        {
            var personBase = Mapper.Instance.Map<PersonDetails, PersonBase>(personDetails);

            using (var dbContext = new StaplesDatabaseContext())
            {
                if (dbContext.Persons.Any(PersonBase.Comparer(personBase)))
                {
                    // TODO some message ?
                    return;
                }

                dbContext.Persons.Add(personBase);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}