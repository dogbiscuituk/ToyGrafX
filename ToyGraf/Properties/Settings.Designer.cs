﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToyGraf.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ToyGraf Files (*.tgxf)|*.tgxf|ToyGraf Templates (*.tgxt)|*.tgxt|All Files (*.*)|*" +
            ".*")]
        public string FileFilter {
            get {
                return ((string)(this["FileFilter"]));
            }
            set {
                this["FileFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Options_OpenInNewWindow {
            get {
                return ((bool)(this["Options_OpenInNewWindow"]));
            }
            set {
                this["Options_OpenInNewWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Options_GroupUndo {
            get {
                return ((bool)(this["Options_GroupUndo"]));
            }
            set {
                this["Options_GroupUndo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Images (*.bmp;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.gif;*.jpeg;*.jpg;*.png|All files " +
            "(*.*)|*.*")]
        public string ImageFilter {
            get {
                return ((string)(this["ImageFilter"]));
            }
            set {
                this["ImageFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FilesFolderPath {
            get {
                return ((string)(this["FilesFolderPath"]));
            }
            set {
                this["FilesFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TemplatesFolderPath {
            get {
                return ((string)(this["TemplatesFolderPath"]));
            }
            set {
                this["TemplatesFolderPath"] = value;
            }
        }
    }
}
