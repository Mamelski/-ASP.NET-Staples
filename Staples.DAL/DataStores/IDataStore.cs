// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataStore.cs" company="">
//   
// </copyright>
// <summary>
//   The DataStore interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Staples.DAL.DataStores
{
    using Staples.Model;

    /// <summary>
    /// The DataStore interface.
    /// </summary>
    public interface IDataStore
    {
        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="personDetails">
        /// The person details.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// TODO this could return some status class with CompletionCode or something
        void Save(PersonDetails personDetails);

        /// <summary>
        /// The load.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// TODO this could return some status class with CompletionCode or something
        void Load();
    }
}