using Rhino.Security;
using Rhino.Commons;
using van.Core;

namespace van.Web.CastleWindsor{
    ///<summary>
    ///</summary>
    public class FacilitiesRegistrar {
        /// <summary>
        /// Adds the facilities to.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void AddFacilitiesTo(Castle.Windsor.IWindsorContainer container)
        {
            container.AddFacility("rhinoSecurityFacility",
                new RhinoSecurityFacility(SecurityTableStructure.Prefix, typeof(User)));

            IoC.Initialize(container);
        }
    }
}