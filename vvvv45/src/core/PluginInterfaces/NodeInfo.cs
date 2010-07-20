﻿using System;
using System.Runtime.InteropServices;
using System.Drawing;

using VVVV.Core.Model;

namespace VVVV.PluginInterfaces.V1
{
    #region INodeInfo
	/// <summary>
	/// Interface for the <see cref="VVVV.PluginInterfaces.V1.INodeInfo">INodeInfo</see>. Also see <a href="http://www.vvvv.org/tiki-index.php?page=Conventions.NodeAndPinNaming" target="_blank">VVVV Naming Conventions</a>.
	/// </summary>
	[Guid("581998D6-ED08-4E73-821A-46AFF59C78BD"),
	 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INodeInfo : IPluginInfo
	{
		/// <summary>
		/// Arguments used by the PluginFactory to create this node.
		/// </summary>
		string Arguments {get; set;}
		/// <summary>
		/// Name of the file used by the PluginFactory to create this node.
		/// </summary>
		string Filename {get; set;}
		/// <summary>
		/// The nodes unique username in the form of: Name (Category Version) where the Name can be a symbol
		/// </summary>
		string Username {get;}
		/// <summary>
		/// The nodes unique systemname in the form of: Name (Category Version)
		/// </summary>
		string Systemname {get;}
		/// <summary>
		/// The node type. Set by the PluginFactory.
		/// </summary>
		TNodeType Type {get; set;}
		/// <summary>
		/// Reference to the <see cref="VVVV.HDE.Interfaces.IExecutable">IExecutable</see> which was used to create this node. Set by the PluginFactory.
		/// </summary>
		IExecutable Executable {get; set;}
	}
	#endregion INodeInfo
	
	#region NodeInfo	
	/// <summary>
	/// Helper Class that implements the <see cref="VVVV.PluginInterfaces.V1.INodeInfo">INodeInfo</see> interface.
	/// </summary>
	[Guid("36F845F4-A486-49EC-9A0C-CB254FF2B297")]
	public class NodeInfo: PluginInfo, INodeInfo
	{
		private string FArguments = "";
		private string FFilename = "";
		private TNodeType FType = TNodeType.Plugin;
		private IExecutable FExcecutable = null;
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public NodeInfo ()
		{  
		}
		
		/// <summary>
		/// Creates a new NodeInfo from an existing <see cref="VVVV.PluginInterfaces.V1.IPluginInfo">IPluginInfo</see>.
		/// </summary>
		/// <param name="PluginInfo"></param>
		public NodeInfo (IPluginInfo Info)
		{
		    this.Name = Info.Name;
		    this.Category = Info.Category;
		    this.Version = Info.Version;
		    this.Shortcut = Info.Shortcut;
			this.Author = Info.Author;
			this.Help = Info.Help;
			this.Tags = Info.Tags;
			this.Bugs = Info.Bugs;
			this.Credits = Info.Credits;
			this.Warnings = Info.Warnings;

			this.Namespace = Info.Namespace;
			this.Class = Info.Class;
			this.InitialBoxSize = Info.InitialBoxSize;
			this.InitialComponentMode = Info.InitialComponentMode;
			this.InitialWindowSize = Info.InitialWindowSize;
		}
		
		/// <summary>
		/// Arguments used by the PluginFactory to create this node.
		/// </summary>
		public string Arguments
		{
			get {return FArguments;}
			set {FArguments = value;}
		}
		
		/// <summary>
		/// Name of the file used by the PluginFactory to create this node.
		/// </summary>
		public string Filename 
		{
			get {return FFilename;}
			set {FFilename = value;}
		}
		
		/// <summary>
		/// The nodes unique username in the form of: Name (Category Version) where the Name can be a symbol
		/// </summary>
		public string Username 
		{
			get 
			{
			    if (string.IsNullOrEmpty(this.Version))
					return this.Name + " (" + this.Category + ")";
				else
					return this.Name + " (" + this.Category + " " + this.Version + ")";
			}
		}
		
		/// <summary>
		/// The nodes unique username in the form of: Name (Category Version)
		/// </summary>
		public string Systemname 
		{
			get 
			{
			    if (string.IsNullOrEmpty(this.Version))
					return this.Name + " (" + this.Category + ")";
				else
					return this.Name + " (" + this.Category + " " + this.Version + ")";
			}
		}
		
		/// <summary>
		/// The node type. Set by the PluginFactory.
		/// </summary>
		public TNodeType Type 
		{
			get {return FType;}
			set {FType = value;}
		}
		
		/// <summary>
		/// Reference to the <see cref="VVVV.HDE.Interfaces.IExecutable">IExecutable</see> which was used to create this node. Set by the PluginFactory.
		/// </summary>
		public IExecutable Executable 
		{
			get {return FExcecutable;}
			set {FExcecutable = value;}
		}
	}
	#endregion NodeInfo
}

