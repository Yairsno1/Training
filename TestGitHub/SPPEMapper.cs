using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Ingr.SPPE.BusinessServices.BusinessObject.SPBOConnection;
using Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII;
using Ingr.SPPE.Interfaces.BusinessObject.SPPEMapping;
using Ingr.SPPE.Interfaces.DataObject;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping
{
  public class SPPEMapper : ISPPEMapper
  {
    private BOConnection m_conn;
    private Dictionary<string, SPPEClass> m_SPPEClassCollection;
    private UOMsMap m_UOMs;

    public SPPEMapper(BOConnection p_connection)
    {
      m_conn = p_connection;
      Initialize();
    }

       #region ISPPEMapper
    public ISimItem[] FindNotMappedItems(ISimItem[] p_simulationItems)
    {
      List<ISimItem> rv;
      int simItemCount = 0;
      int i;
      string uopSubClass = string.Empty;
      SPPEClass sppeClass = null;

      if (p_simulationItems == null)
      {
        throw new ArgumentNullException("p_simulationItems", "Simulation items object cannot be a null reference");
      }

      rv = new List<ISimItem>();

      simItemCount = p_simulationItems.Length;
      for (i = 0; i < simItemCount; i++)
      {
        uopSubClass = p_simulationItems[i].UOPSubClass;
        sppeClass = GetSPPEClass(uopSubClass,
                                 uopSubClass,
                                 p_simulationItems[i].UOPType,
                                 p_simulationItems[i].UOPType2);
        if (sppeClass == null)
        {
          rv.Add(p_simulationItems[i]);
        }

      }

      return rv.ToArray();
    }

    public ISPPEAttribute GetAttribute(ISimItem p_simulationItem, string p_simualationAttributeName)
    {
      SPPEAttribute rv = null;
      SPPEClass sppeClass = null;
      string uopSubClass = string.Empty;

      if (p_simulationItem == null)
      {
        throw new ArgumentNullException("p_simulationItem", "Simulation item object cannot be a null reference");
      }
      else if (string.IsNullOrEmpty(p_simualationAttributeName))
      {
        throw new ArgumentException("Simualation attribute name can not be empty", "p_simualationAttributeName");
      }

      uopSubClass = p_simulationItem.UOPSubClass;
      sppeClass = GetSPPEClass(uopSubClass, uopSubClass, p_simulationItem.UOPType, p_simulationItem.UOPType2);
      if (sppeClass != null)
      {
        rv = sppeClass.GetAttribute(p_simualationAttributeName);
      }

      return rv;
    }

    public string GetAttributeName(ISimItem p_simulationItem, string p_simualationAttributeName)
    {
      string uopSubClass = string.Empty;

      if (p_simulationItem == null)
      {
        throw new ArgumentNullException("p_simulationItem", "Simulation item object cannot be a null reference");
      }
      else if (string.IsNullOrEmpty(p_simualationAttributeName))
      {
        throw new ArgumentException("Simualation attribute name can not be empty", "p_simualationAttributeName");
      }

      uopSubClass = p_simulationItem.UOPSubClass;
      return GetAttributeName(uopSubClass,
                              uopSubClass,
                              p_simulationItem.UOPType,
                              p_simulationItem.UOPType2, 
                              p_simualationAttributeName); 
    }

    public string GetAttributeName(string p_className,
                                   string p_subClass,
                                   string p_type1,
                                   string p_type2,
                                   string p_simualationAttributeName)
    {
      string rv = string.Empty;
      SPPEClass sppeClass = null;

      sppeClass = GetSPPEClass(p_className, p_subClass, p_type1, p_type2);
      if (sppeClass != null)
      {
        rv = sppeClass.GetAttributeName(p_simualationAttributeName);
      }

      return rv;
    }

    public string GetDefinitionFileName(ISimItem p_simulationItem)
    {
      string rv = string.Empty;
      string uopSubClass = string.Empty;
      SPPEClass sppeClass = null;

      if (p_simulationItem == null)
      {
        throw new ArgumentNullException("p_simulationItem", "Simulation item object cannot be a null reference");
      }

      uopSubClass = p_simulationItem.UOPSubClass;
      sppeClass = GetSPPEClass(uopSubClass,
                               uopSubClass,
                               p_simulationItem.UOPType,
                               p_simulationItem.UOPType2);
      if (sppeClass != null)
      {
        rv = sppeClass.DefinitionFileName;
      }

      return rv;
    }

    public string GetType(ISimItem p_simulationItem)
    {
      string rv = string.Empty;
      string uopSubClass = string.Empty;
      SPPEClass sppeClass = null;

      if (p_simulationItem == null)
      {
        throw new ArgumentNullException("p_simulationItem", "Simulation item object cannot be a null reference");
      }

      uopSubClass = p_simulationItem.UOPSubClass;
      sppeClass = GetSPPEClass(uopSubClass,
                               uopSubClass,
                               p_simulationItem.UOPType,
                               p_simulationItem.UOPType2);
      if (sppeClass != null)
      {
        rv = sppeClass.SppeType;
      }

      return rv;
    }

    public string GetSubClass(ISimItem p_simulationItem)
    {
      string rv = string.Empty;
      string uopSubClass = string.Empty;
      SPPEClass sppeClass = null;

      if (p_simulationItem == null)
      {
        throw new ArgumentNullException("p_simulationItem", "Simulation item object cannot be a null reference");
      }

      uopSubClass = p_simulationItem.UOPSubClass;
      sppeClass = GetSPPEClass(uopSubClass,
                               uopSubClass,
                               p_simulationItem.UOPType,
                               p_simulationItem.UOPType2);
      if (sppeClass != null)
      {
        rv = sppeClass.SubClass;
      }

      return rv;
    }
       #endregion

    internal void GetUOM(string p_simulationUOM, out string p_UOMName, out string p_UOMTypeID)
    {
      p_UOMName = string.Empty;
      p_UOMTypeID = string.Empty;

      UOMMap um = m_UOMs[p_simulationUOM];

      if (um != null)
      {
        p_UOMName = um.SPPEUnit;
        p_UOMTypeID = um.Parent.SPPEUnitTypeID;
      }
    }

    private SPPEClass GetSPPEClass(string p_className,
                                   string p_subClass,
                                   string p_type1,
                                   string p_type2)
    {
      SPPEClass rv = null;
      string id = string.Empty;

      id = SPPEClass.GenerateID(p_className, p_subClass, p_type1, p_type2);
      if (m_SPPEClassCollection.ContainsKey(id))
      {
        rv = m_SPPEClassCollection[id];
      }

      return rv;
    }

    private void Initialize()
    {
      SPPEProIIMappingSchema mappingSchema = null;
      int objClassCount = 0;
      int i = 0;

      mappingSchema = LoadXML();

      m_SPPEClassCollection = new Dictionary<string, SPPEClass>();
      List<ObjectClass> objClassCollection = mappingSchema.ObjectClassCollection;
      objClassCount = objClassCollection.Count;
      for (i = 0; i < objClassCount; i++)
      {
        SPPEClass sppeClass = new SPPEClass(objClassCollection[i]);
        if (!m_SPPEClassCollection.ContainsKey(sppeClass.ID))
        {
          m_SPPEClassCollection.Add(sppeClass.ID, sppeClass);
        }
      }

      m_UOMs = new UOMsMap();
      List<UOMClass> UOMClasses = mappingSchema.UOMClassCollection;
      for (i = 0; i < UOMClasses.Count; i++)
      {
        m_UOMs.Add(UOMClasses[i]);
      }
    }

    private SPPEProIIMappingSchema LoadXML()
    {
      SPPEProIIMappingSchema rv = null;
      BOFactory boFactory = null;
      string mappingSchemaFile = string.Empty;

      boFactory = m_conn.CreateBOFactory();
      mappingSchemaFile = boFactory.GetOptionSettingManager.ImportMapPath + "SPPEMappingSchema.xml"; //(Y.S) Todo: replace this with Option Setting value when available.

      XmlSerializer xmlSerializer = new XmlSerializer(typeof(SPPEProIIMappingSchema));

      using (StreamReader  reader = new StreamReader(mappingSchemaFile))
      {
        rv = (SPPEProIIMappingSchema)xmlSerializer.Deserialize(reader);
      }

      return rv;
    }

  }
}
