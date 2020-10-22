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

namespace SqlAdmin {

	[Flags]
	public enum SqlPrivilegeType {

		Unknown = 0,
		Select = 1,
		Insert = 2,
		Update = 4,
		Delete = 8,
		Execute = 16,
		References = 32,
		AllObjectPrivs = 63,
		CreateTable = 128,
		CreateDatabase = 256,
		CreateView = 512,
		CreateProcedure = 1024,
		DumpDatabase = 2048,
		CreateDefault = 4096,
		DumpTransaction = 8192,
		CreateRule = 16384,
		DumpTable = 32768,
		CreateFunction = 0x00010000,
		AllDatabasePrivs = 0x0001ff80,

	}
}
