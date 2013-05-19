﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace DurMap.Site.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class StatesEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new StatesEntities object using the connection string found in the 'StatesEntities' section of the application configuration file.
        /// </summary>
        public StatesEntities() : base("name=StatesEntities", "StatesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new StatesEntities object.
        /// </summary>
        public StatesEntities(string connectionString) : base(connectionString, "StatesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new StatesEntities object.
        /// </summary>
        public StatesEntities(EntityConnection connection) : base(connection, "StatesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<State> States
        {
            get
            {
                if ((_States == null))
                {
                    _States = base.CreateObjectSet<State>("States");
                }
                return _States;
            }
        }
        private ObjectSet<State> _States;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<USAstate> USAstates
        {
            get
            {
                if ((_USAstates == null))
                {
                    _USAstates = base.CreateObjectSet<USAstate>("USAstates");
                }
                return _USAstates;
            }
        }
        private ObjectSet<USAstate> _USAstates;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the States EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToStates(State state)
        {
            base.AddObject("States", state);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the USAstates EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUSAstates(USAstate uSAstate)
        {
            base.AddObject("USAstates", uSAstate);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="StatesModel", Name="State")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class State : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new State object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static State CreateState(global::System.Int32 id)
        {
            State state = new State();
            state.Id = id;
            return state;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                OnCodeChanging(value);
                ReportPropertyChanging("Code");
                _Code = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Code");
                OnCodeChanged();
            }
        }
        private global::System.String _Code;
        partial void OnCodeChanging(global::System.String value);
        partial void OnCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FipsCode
        {
            get
            {
                return _FipsCode;
            }
            set
            {
                OnFipsCodeChanging(value);
                ReportPropertyChanging("FipsCode");
                _FipsCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FipsCode");
                OnFipsCodeChanged();
            }
        }
        private global::System.String _FipsCode;
        partial void OnFipsCodeChanging(global::System.String value);
        partial void OnFipsCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Zoom
        {
            get
            {
                return _Zoom;
            }
            set
            {
                OnZoomChanging(value);
                ReportPropertyChanging("Zoom");
                _Zoom = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Zoom");
                OnZoomChanged();
            }
        }
        private Nullable<global::System.Int32> _Zoom;
        partial void OnZoomChanging(Nullable<global::System.Int32> value);
        partial void OnZoomChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="StatesModel", Name="USAstate")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class USAstate : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new USAstate object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static USAstate CreateUSAstate(global::System.Int32 id)
        {
            USAstate uSAstate = new USAstate();
            uSAstate.ID = id;
            return uSAstate;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> OBJECTID
        {
            get
            {
                return _OBJECTID;
            }
            set
            {
                OnOBJECTIDChanging(value);
                ReportPropertyChanging("OBJECTID");
                _OBJECTID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OBJECTID");
                OnOBJECTIDChanged();
            }
        }
        private Nullable<global::System.Int64> _OBJECTID;
        partial void OnOBJECTIDChanging(Nullable<global::System.Int64> value);
        partial void OnOBJECTIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Single> VertexCou
        {
            get
            {
                return _VertexCou;
            }
            set
            {
                OnVertexCouChanging(value);
                ReportPropertyChanging("VertexCou");
                _VertexCou = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VertexCou");
                OnVertexCouChanged();
            }
        }
        private Nullable<global::System.Single> _VertexCou;
        partial void OnVertexCouChanging(Nullable<global::System.Single> value);
        partial void OnVertexCouChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ISO
        {
            get
            {
                return _ISO;
            }
            set
            {
                OnISOChanging(value);
                ReportPropertyChanging("ISO");
                _ISO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ISO");
                OnISOChanged();
            }
        }
        private global::System.String _ISO;
        partial void OnISOChanging(global::System.String value);
        partial void OnISOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NAME_0
        {
            get
            {
                return _NAME_0;
            }
            set
            {
                OnNAME_0Changing(value);
                ReportPropertyChanging("NAME_0");
                _NAME_0 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NAME_0");
                OnNAME_0Changed();
            }
        }
        private global::System.String _NAME_0;
        partial void OnNAME_0Changing(global::System.String value);
        partial void OnNAME_0Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                OnNAMEChanging(value);
                ReportPropertyChanging("NAME");
                _NAME = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NAME");
                OnNAMEChanged();
            }
        }
        private global::System.String _NAME;
        partial void OnNAMEChanging(global::System.String value);
        partial void OnNAMEChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String VARNAME_1
        {
            get
            {
                return _VARNAME_1;
            }
            set
            {
                OnVARNAME_1Changing(value);
                ReportPropertyChanging("VARNAME_1");
                _VARNAME_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("VARNAME_1");
                OnVARNAME_1Changed();
            }
        }
        private global::System.String _VARNAME_1;
        partial void OnVARNAME_1Changing(global::System.String value);
        partial void OnVARNAME_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NL_NAME_1
        {
            get
            {
                return _NL_NAME_1;
            }
            set
            {
                OnNL_NAME_1Changing(value);
                ReportPropertyChanging("NL_NAME_1");
                _NL_NAME_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NL_NAME_1");
                OnNL_NAME_1Changed();
            }
        }
        private global::System.String _NL_NAME_1;
        partial void OnNL_NAME_1Changing(global::System.String value);
        partial void OnNL_NAME_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HASC_1
        {
            get
            {
                return _HASC_1;
            }
            set
            {
                OnHASC_1Changing(value);
                ReportPropertyChanging("HASC_1");
                _HASC_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HASC_1");
                OnHASC_1Changed();
            }
        }
        private global::System.String _HASC_1;
        partial void OnHASC_1Changing(global::System.String value);
        partial void OnHASC_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TYPE_1
        {
            get
            {
                return _TYPE_1;
            }
            set
            {
                OnTYPE_1Changing(value);
                ReportPropertyChanging("TYPE_1");
                _TYPE_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TYPE_1");
                OnTYPE_1Changed();
            }
        }
        private global::System.String _TYPE_1;
        partial void OnTYPE_1Changing(global::System.String value);
        partial void OnTYPE_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ENGTYPE_1
        {
            get
            {
                return _ENGTYPE_1;
            }
            set
            {
                OnENGTYPE_1Changing(value);
                ReportPropertyChanging("ENGTYPE_1");
                _ENGTYPE_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ENGTYPE_1");
                OnENGTYPE_1Changed();
            }
        }
        private global::System.String _ENGTYPE_1;
        partial void OnENGTYPE_1Changing(global::System.String value);
        partial void OnENGTYPE_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String VALIDFR_1
        {
            get
            {
                return _VALIDFR_1;
            }
            set
            {
                OnVALIDFR_1Changing(value);
                ReportPropertyChanging("VALIDFR_1");
                _VALIDFR_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("VALIDFR_1");
                OnVALIDFR_1Changed();
            }
        }
        private global::System.String _VALIDFR_1;
        partial void OnVALIDFR_1Changing(global::System.String value);
        partial void OnVALIDFR_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String VALIDTO_1
        {
            get
            {
                return _VALIDTO_1;
            }
            set
            {
                OnVALIDTO_1Changing(value);
                ReportPropertyChanging("VALIDTO_1");
                _VALIDTO_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("VALIDTO_1");
                OnVALIDTO_1Changed();
            }
        }
        private global::System.String _VALIDTO_1;
        partial void OnVALIDTO_1Changing(global::System.String value);
        partial void OnVALIDTO_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String REMARKS_1
        {
            get
            {
                return _REMARKS_1;
            }
            set
            {
                OnREMARKS_1Changing(value);
                ReportPropertyChanging("REMARKS_1");
                _REMARKS_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("REMARKS_1");
                OnREMARKS_1Changed();
            }
        }
        private global::System.String _REMARKS_1;
        partial void OnREMARKS_1Changing(global::System.String value);
        partial void OnREMARKS_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region
        {
            get
            {
                return _Region;
            }
            set
            {
                OnRegionChanging(value);
                ReportPropertyChanging("Region");
                _Region = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region");
                OnRegionChanged();
            }
        }
        private global::System.String _Region;
        partial void OnRegionChanging(global::System.String value);
        partial void OnRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String RegionVar
        {
            get
            {
                return _RegionVar;
            }
            set
            {
                OnRegionVarChanging(value);
                ReportPropertyChanging("RegionVar");
                _RegionVar = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RegionVar");
                OnRegionVarChanged();
            }
        }
        private global::System.String _RegionVar;
        partial void OnRegionVarChanging(global::System.String value);
        partial void OnRegionVarChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ProvNumber
        {
            get
            {
                return _ProvNumber;
            }
            set
            {
                OnProvNumberChanging(value);
                ReportPropertyChanging("ProvNumber");
                _ProvNumber = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ProvNumber");
                OnProvNumberChanged();
            }
        }
        private Nullable<global::System.Int32> _ProvNumber;
        partial void OnProvNumberChanging(Nullable<global::System.Int32> value);
        partial void OnProvNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NEV_Countr
        {
            get
            {
                return _NEV_Countr;
            }
            set
            {
                OnNEV_CountrChanging(value);
                ReportPropertyChanging("NEV_Countr");
                _NEV_Countr = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NEV_Countr");
                OnNEV_CountrChanged();
            }
        }
        private global::System.String _NEV_Countr;
        partial void OnNEV_CountrChanging(global::System.String value);
        partial void OnNEV_CountrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FIRST_FIPS
        {
            get
            {
                return _FIRST_FIPS;
            }
            set
            {
                OnFIRST_FIPSChanging(value);
                ReportPropertyChanging("FIRST_FIPS");
                _FIRST_FIPS = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FIRST_FIPS");
                OnFIRST_FIPSChanged();
            }
        }
        private global::System.String _FIRST_FIPS;
        partial void OnFIRST_FIPSChanging(global::System.String value);
        partial void OnFIRST_FIPSChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FIRST_HASC
        {
            get
            {
                return _FIRST_HASC;
            }
            set
            {
                OnFIRST_HASCChanging(value);
                ReportPropertyChanging("FIRST_HASC");
                _FIRST_HASC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FIRST_HASC");
                OnFIRST_HASCChanged();
            }
        }
        private global::System.String _FIRST_HASC;
        partial void OnFIRST_HASCChanging(global::System.String value);
        partial void OnFIRST_HASCChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FIPS_1
        {
            get
            {
                return _FIPS_1;
            }
            set
            {
                OnFIPS_1Changing(value);
                ReportPropertyChanging("FIPS_1");
                _FIPS_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FIPS_1");
                OnFIPS_1Changed();
            }
        }
        private global::System.String _FIPS_1;
        partial void OnFIPS_1Changing(global::System.String value);
        partial void OnFIPS_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Single> gadm_level
        {
            get
            {
                return _gadm_level;
            }
            set
            {
                Ongadm_levelChanging(value);
                ReportPropertyChanging("gadm_level");
                _gadm_level = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("gadm_level");
                Ongadm_levelChanged();
            }
        }
        private Nullable<global::System.Single> _gadm_level;
        partial void Ongadm_levelChanging(Nullable<global::System.Single> value);
        partial void Ongadm_levelChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CheckMe
        {
            get
            {
                return _CheckMe;
            }
            set
            {
                OnCheckMeChanging(value);
                ReportPropertyChanging("CheckMe");
                _CheckMe = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CheckMe");
                OnCheckMeChanged();
            }
        }
        private Nullable<global::System.Int32> _CheckMe;
        partial void OnCheckMeChanging(Nullable<global::System.Int32> value);
        partial void OnCheckMeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region_Cod
        {
            get
            {
                return _Region_Cod;
            }
            set
            {
                OnRegion_CodChanging(value);
                ReportPropertyChanging("Region_Cod");
                _Region_Cod = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region_Cod");
                OnRegion_CodChanged();
            }
        }
        private global::System.String _Region_Cod;
        partial void OnRegion_CodChanging(global::System.String value);
        partial void OnRegion_CodChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region_C_1
        {
            get
            {
                return _Region_C_1;
            }
            set
            {
                OnRegion_C_1Changing(value);
                ReportPropertyChanging("Region_C_1");
                _Region_C_1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region_C_1");
                OnRegion_C_1Changed();
            }
        }
        private global::System.String _Region_C_1;
        partial void OnRegion_C_1Changing(global::System.String value);
        partial void OnRegion_C_1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ScaleRank
        {
            get
            {
                return _ScaleRank;
            }
            set
            {
                OnScaleRankChanging(value);
                ReportPropertyChanging("ScaleRank");
                _ScaleRank = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ScaleRank");
                OnScaleRankChanged();
            }
        }
        private Nullable<global::System.Int32> _ScaleRank;
        partial void OnScaleRankChanging(Nullable<global::System.Int32> value);
        partial void OnScaleRankChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region_C_2
        {
            get
            {
                return _Region_C_2;
            }
            set
            {
                OnRegion_C_2Changing(value);
                ReportPropertyChanging("Region_C_2");
                _Region_C_2 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region_C_2");
                OnRegion_C_2Changed();
            }
        }
        private global::System.String _Region_C_2;
        partial void OnRegion_C_2Changing(global::System.String value);
        partial void OnRegion_C_2Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region_C_3
        {
            get
            {
                return _Region_C_3;
            }
            set
            {
                OnRegion_C_3Changing(value);
                ReportPropertyChanging("Region_C_3");
                _Region_C_3 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region_C_3");
                OnRegion_C_3Changed();
            }
        }
        private global::System.String _Region_C_3;
        partial void OnRegion_C_3Changing(global::System.String value);
        partial void OnRegion_C_3Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country_Pr
        {
            get
            {
                return _Country_Pr;
            }
            set
            {
                OnCountry_PrChanging(value);
                ReportPropertyChanging("Country_Pr");
                _Country_Pr = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country_Pr");
                OnCountry_PrChanged();
            }
        }
        private global::System.String _Country_Pr;
        partial void OnCountry_PrChanging(global::System.String value);
        partial void OnCountry_PrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Single> Shape_Leng
        {
            get
            {
                return _Shape_Leng;
            }
            set
            {
                OnShape_LengChanging(value);
                ReportPropertyChanging("Shape_Leng");
                _Shape_Leng = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Shape_Leng");
                OnShape_LengChanged();
            }
        }
        private Nullable<global::System.Single> _Shape_Leng;
        partial void OnShape_LengChanging(Nullable<global::System.Single> value);
        partial void OnShape_LengChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Single> AREA
        {
            get
            {
                return _AREA;
            }
            set
            {
                OnAREAChanging(value);
                ReportPropertyChanging("AREA");
                _AREA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AREA");
                OnAREAChanged();
            }
        }
        private Nullable<global::System.Single> _AREA;
        partial void OnAREAChanging(Nullable<global::System.Single> value);
        partial void OnAREAChanged();

        #endregion
    
    }

    #endregion
    
}
