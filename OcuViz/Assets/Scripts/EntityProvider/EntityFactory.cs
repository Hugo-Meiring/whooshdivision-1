using System;

namespace EntityProvider
{
    /// <summary>
    /// An abstract class definition specifying how factories which build entities should function.
    /// These factories will be used for creating entities containing GameObjects from a list of parameters.
    /// </summary>
	public abstract class EntityFactory
	{
		/// <summary>
        /// Describes the type of Entity the factory builds.
        /// </summary>
		public String typeName;
		
        /// <summary>
        /// Definition of a method used to build Entities containing GameObjects. Each concrete implementation
        /// will handle the creation of these Entities according to the parameters it expects.
        /// </summary>
        /// <param name="list">A string list of parameters to build the Entity.</param>
        /// <returns>Entity containing the necessary GameObject.</returns>
		public abstract Entity build(string[] list);

        /// <summary>
        /// Definition of creating basic Entities. Should be used to create generic GameObjects.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>Basic functional Entity</returns>
        public abstract Entity buildBasic(string button, string entityLink, string type);
	}
}
