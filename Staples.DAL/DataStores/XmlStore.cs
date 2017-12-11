// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlStore.cs" company="">
//   
// </copyright>
// <summary>
//   The xml store.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.DAL.DataStores
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using AutoMapper;

    using Staples.Model;

    /// <summary>
    /// The xml store.
    /// </summary>
    public class XmlStore : IDataStore
    {
        /// <summary>
        /// The file name.
        /// TODO this should be configurable ?
        /// </summary>
        private const string fileName = @"C:\temp\mamelski\data.xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlStore"/> class.
        /// </summary>
        public XmlStore()
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
        public void Save(PersonDetails personDetails)
        {
            // TODO maybe some kind of append would be better instead of deserializing and serializing (no time :(((( ) ?
            var allPersons = new List<PersonBase>();

            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    var deserializer = new XmlSerializer(typeof(List<PersonBase>));
                    allPersons = (List<PersonBase>)deserializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException)
            {
                // TODO this is bad, but for now do nothing, initial empty, can cause this exception
                // TODO this should not be handled like this....
            }

            var personBase = Mapper.Instance.Map<PersonDetails, PersonBase>(personDetails);

            if (allPersons.Any(PersonBase.Comparer(personBase)))
            {
                // TODO some message/exception/log ?
                return;
            }

            allPersons.Add(personBase);

            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(List<PersonBase>));
                serializer.Serialize(writer, allPersons);
            }
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