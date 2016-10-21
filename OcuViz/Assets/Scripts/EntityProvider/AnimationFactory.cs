using System;

namespace EntityProvider
{
    /// <summary>
    /// Implementation of EntityFactory building animation scripts.
    /// </summary>
    public class AnimationFactory : EntityFactory
	{
        /// <summary>
        /// Builds an animated GameObject contained in an Entity.
        /// </summary>
        /// <param name="list">List of parameters to animate a GameObject in an Entity.</param>
        /// <returns>Entity containing animated GameObject.</returns>
        public override Entity build(string[] list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function builds basic animated Entity.
        /// </summary>
        /// <param name="button">Input button used.</param>
        /// <param name="entityLink">Name of the Entity (always required).</param>
        /// <param name="type">Type of Entity to return.</param>
        /// <returns>Basic functional animated Entity</returns>
        public override Entity buildBasic(string button, string entityLink, string type)
        {
            throw new NotImplementedException();
        }
    }
}