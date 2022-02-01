using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carfup.XTBPlugins.AppCode
{
    public class DataManager
    {
        #region Variables

        /// <summary>
        /// Crm web service
        /// </summary>
        private readonly ControllerManager connection = null;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class DataManager
        /// </summary>
        /// <param name="service">Details of the connected user</param>
        public DataManager(ControllerManager connection)
        {
            this.connection = connection;
        }

        #endregion Constructor

        public List<Entity> retrieveBPFEntities()
        {
            return this.connection.serviceClient.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "workflow",
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("category", ConditionOperator.Equal, 4)
                    }
                }
            }).Entities.ToList();
        }

        public List<Entity> retrievePcfList()
        {
            return this.connection.serviceClient.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "customcontrol",
                ColumnSet = new ColumnSet("compatibledatatypes", "manifest", "name")
            }).Entities.ToList();
        }

        public Entity retrieveBpfForm(string entity)
        {
            return this.connection.serviceClient.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "systemform",
                ColumnSet = new ColumnSet("name", "formxml", "objecttypecode"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.Like, entity),
                    }
                }
            }).Entities.FirstOrDefault();
        }

        public List<AttributeMetadata> getEntityAttributesMetadata(string entity)
        {
            RetrieveEntityRequest retrieveEntityAttributesRequest = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entity
            };
            var metadata = (RetrieveEntityResponse)this.connection.serviceClient.Execute(retrieveEntityAttributesRequest);
            return metadata.EntityMetadata.Attributes.ToList();
        }
    }
}