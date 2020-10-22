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
using System.Globalization;
using System.Resources;

namespace SqlAdmin {
    /// <summary>
    /// Summary description for AwcDescriptionAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SqlAdminDescriptionAttribute : DescriptionAttribute {
        public SqlAdminDescriptionAttribute(string description) : base(description) {
        }

        private bool replaced = false;

        public override string Description {
            get {
                if (!replaced) {
                    replaced = true;
                    DescriptionValue = SR.GetString(base.Description);
                }
                return base.Description;
            }
        }

    }


    internal sealed class SR {
        static SR loader = null;
        ResourceManager resources;

        private SR() {
            resources = new System.Resources.ResourceManager("SqlAdmin.SqlAdmin", this.GetType().Module.Assembly);
        }

        private static SR GetLoader() {
            if (loader == null) {
                lock(typeof(SR)) {
                    if (loader == null) {
                        loader = new SR();
                    }
                }
            }

            return loader;
        }

        public static string GetString(string name) {
            return GetString(null, name);
        }

        public static string GetString(CultureInfo culture, string name) {
            SR sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetString(name, culture);
        }

        public static object GetObject(string name) {
            return GetObject(null, name);
        }

        public static object GetObject(CultureInfo culture, string name) {
            SR sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetObject(name, culture);
        }
    }
}
