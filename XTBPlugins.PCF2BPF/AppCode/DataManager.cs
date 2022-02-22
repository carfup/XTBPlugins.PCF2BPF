using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Entity> RetrieveBPFEntities()
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

        public List<Entity> RetrievePcfList()
        {

            return new List<Entity>();
            /*return this.connection.serviceClient.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "customcontrol",
                ColumnSet = new ColumnSet("compatibledatatypes", "manifest", "name"),
            }).Entities.ToList();*/
        }

        internal List<EntityMetadata> GetMetadata(IEnumerable<string> rels)
        {
            var entities = new List<string>();

            foreach (var rel in rels)
            {
                RetrieveRelationshipRequest r = new RetrieveRelationshipRequest
                {
                    Name = rel
                };
                var relResponse = (RetrieveRelationshipResponse)this.connection.serviceClient.Execute(r);
                entities.Add(((OneToManyRelationshipMetadata)relResponse.RelationshipMetadata).ReferencedEntity);
            }

            var query = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression("DisplayName", "Attributes", "OneToManyRelationships"),
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("LogicalName", MetadataConditionOperator.In, entities.ToArray())
                    }
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression("DisplayName", "FormatName", "Format"),
                },
                RelationshipQuery = new RelationshipQueryExpression
                {
                    Properties = new MetadataPropertiesExpression("SchemaName"),
                    Criteria = new MetadataFilterExpression
                    {
                        Conditions =
                        {
                             new MetadataConditionExpression("SchemaName", MetadataConditionOperator.In, rels.ToArray())
                        }
                    }
                }
            };

            var response = (RetrieveMetadataChangesResponse)this.connection.serviceClient.Execute(new RetrieveMetadataChangesRequest { Query = query });
            return response.EntityMetadata.Where(emd => emd.OneToManyRelationships.Count() > 0).ToList();
        }

        internal int GetUserLcid()
        {
            return this.connection.serviceClient.RetrieveMultiple(new QueryExpression("usersettings")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("uilanguageid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("systemuserid", ConditionOperator.EqualUserId)
                    }
                }
            }).Entities.First().GetAttributeValue<int>("uilanguageid");
        }
    }
}