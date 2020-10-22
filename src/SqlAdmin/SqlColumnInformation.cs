//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2003  Microsoft Corporation.  All rights reserved.
//
//=====================================================================
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;

namespace SqlAdmin {
	/// <summary>
	/// Represents the properties of a SQL column such as name, data type, and size.
	/// </summary>
	public class SqlColumnInformation {
		private bool key;
		private bool identity;
		private string name;
		private string dataType;
		private int size;
		private int scale;
		private int precision;
		private bool nulls;
		private string defaultValue;
		private int identitySeed;
		private int identityIncrement;
		private bool isRowGuid;


        /// <summary>
        /// Initializes a new instance of the SqlColumnInformation class.
        /// </summary>
        public SqlColumnInformation() : this("") {            
        }

        /// <summary>
        /// Initializes a new instance of the SqlColumnInformation class.
        /// </summary>
        /// <param name="name">
        /// The name of the column.
        /// </param>
        public SqlColumnInformation(string name) : this(false, false, name, "char", 10, 0, 0, true, "", 0, 0, false) {
            // REVIEW: check these default values (note that in Enterprise Manager, some of these fields show up blank, where here we are putting a zero [e.g. seed...] Is there a constant that equates to blank for these?)
        }

        /// <summary>
        /// Initializes a new instance of the SqlColumnInformation class.
        /// </summary>
        /// <param name="key">
        /// Indicates whether this column is part of the primary key.
        /// </param>
        /// <param name="identity">
        /// Indicates whether this column is an identity column.
        /// </param>
        /// <param name="name">
        /// The name of this column.
        /// </param>
        /// <param name="dataType">
        /// The data type of this column.
        /// </param>
        /// <param name="size">
        /// The size of this column.
        /// </param>
        /// <param name="scale">
        /// The size of this column.
        /// </param>
        /// <param name="precision">
        /// The precision of this column.
        /// </param>
        /// <param name="nulls">
        /// Whether this column allows nulls/
        /// </param>
        /// <param name="defaultValue">
        /// The default value of this column.
        /// </param>
        /// <param name="identitySeed">
        /// If this column is an identity column, the seed for this column.
        /// </param>
        /// <param name="identityIncrement">
        /// If this column is an identity column, the increment for this column.
        /// </param>
        /// <param name="isRowGuid">
        /// If this column is an identity column, whether this column is a Row GUID column.
        /// </param>
        public SqlColumnInformation(bool key, bool identity, string name, string dataType, int size, int scale, int precision, bool nulls, string defaultValue, int identitySeed, int identityIncrement, bool isRowGuid) {
			this.key                 = key;
			this.identity            = identity;
			this.name                = name;
			this.dataType            = dataType;
			this.size                = size;
			this.scale               = scale;
			this.precision           = precision;
			this.nulls               = nulls;
			this.defaultValue        = defaultValue;
			this.identitySeed        = identitySeed;
			this.identityIncrement   = identityIncrement;
			this.isRowGuid           = isRowGuid;
		}


        /// <summary>
        /// Indicates whether this column is part of the primary key.
        /// </summary>
        [
        DefaultValue(false),
        SqlAdminDescription("SqlColumnInformation_Key")
        ]
        public bool Key {
            get {
                return key;
            }
            set {
                key = value;
            }
        }
 
        /// <summary>
        /// True if the column is an identity column.
        /// </summary>
        [
        DefaultValue(false),
        SqlAdminDescription("SqlColumnInformation_Identity")
        ]
        public bool Identity {
            get {
                return identity;
            }
            set {
                identity = value;
            }
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        [
        SqlAdminDescription("SqlColumnInformation_Name")
        ]
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        /// <summary>
        /// The data type of this column.
        /// </summary>
        [
        DefaultValue("char"),
        Editor(typeof(SqlAdmin.DataTypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
        SqlAdminDescription("SqlColumnInformation_DataType")
        ]
        public string DataType {
            get {
                return dataType;
            }
            set {
                dataType = value;
            }
        }

        /// <summary>
        /// return Column DbType
        /// </summary>
        public System.Data.DbType ColumnDbType
        {
            get
            {
                if (SqlDatabase.SqlDbTypeDictionary.ContainsKey(dataType))
                {
                    return SqlDatabase.SqlDbTypeDictionary[dataType];
                }
                else
                    return DbType.String;


            }
        }

    

        /// <summary>
        /// The size of this column.
        /// </summary>
        [
        DefaultValue(10),
        SqlAdminDescription("SqlColumnInformation_Size")
        ]
        public int Size {
            get {
                return size;
            }
            set {
                size = value;
            }
        }

        /// <summary>
        /// The maximum number of digits that can appear to the right of the decimal point for values of this column.
        /// </summary>
        [
        DefaultValue(0),
        SqlAdminDescription("SqlColumnInformation_Scale")
        ]
        public int Scale {
            get {
                return scale;
            }
            set {
                scale = value;
            }
        }

        /// <summary>
        /// The maximum number of digits for values of this column.
        /// </summary>
        [
        DefaultValue(0),
        SqlAdminDescription("SqlColumnInformation_Precision")
        ]
        public int Precision {
            get {
                return precision;
            }
            set {
                precision = value;
            }
        }

        /// <summary>
        /// True if a column can contain null values.
        /// </summary>
        [
        DefaultValue(true),
        SqlAdminDescription("SqlColumnInformation_Nulls")
        ]
        public bool Nulls {
            get {
                return nulls;
            }
            set {
                nulls = value;
            }
        }      

        /// <summary>
        /// The default for this column whenever a row with a null value for this column is inserted into the table.
        /// Defaults that contain strings must be enclosed in single quotes, e.g. 'hello'.
        /// </summary>
        [
        DefaultValue(""),
        SqlAdminDescription("SqlColumnInformation_DefaultValue")
        ]
        public string DefaultValue {
            get {
                return defaultValue;
            }
            set {
                defaultValue = value;
            }
        }

        /// <summary>
        /// The seed value of an identity column. This option applies only to columns whose Identity option is set to True.
        /// </summary>
        [
        DefaultValue(0),
        SqlAdminDescription("SqlColumnInformation_IdentitySeed")
        ]
        public int IdentitySeed {
            get {
                return identitySeed;
            }
            set {
                identitySeed = value;
            }
        }

        /// <summary>
        /// The increment value of an identity column. This option applies only to columns whose Identity option is set to True.
        /// </summary>
        [
        DefaultValue(0),
        SqlAdminDescription("SqlColumnInformation_IdentityIncrement")
        ]
        public int IdentityIncrement {
            get {
                return identityIncrement;
            }
            set {
                identityIncrement = value;
            }
        }

        /// <summary>
        /// Indicates whether the column is used by SQL Server as a ROWGUID column.  You can set this value to True only for a column that is an identity column.
        /// </summary>
        [
        DefaultValue(false),
        SqlAdminDescription("SqlColumnInformation_IsRowGuid")
        ]
        public bool IsRowGuid {
            get {
                return isRowGuid;
            }
            set {
                isRowGuid = value;
            }
        }


        /// <summary>
        /// Creates a copy of this SqlColumnInformation object.
        /// </summary>
        /// <returns>
        /// Returns a new instance of the SqlColumnInformation class.
        /// </returns>
        public SqlColumnInformation Clone() {
            return new SqlColumnInformation(Key, Identity, Name, DataType, Size, Scale, Precision, Nulls, DefaultValue, IdentitySeed, IdentityIncrement, IsRowGuid);
        }

        /// <summary>
        /// Returns the name of this column.
        /// </summary>
        /// <returns>
        /// Returns the name of this column.
        /// </returns>
        public override string ToString() {
            return Name;
        }
    }
}
